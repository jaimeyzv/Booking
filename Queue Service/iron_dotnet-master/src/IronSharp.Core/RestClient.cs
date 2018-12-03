﻿using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Common.Logging;
using IronSharp.Core.Abstract;
using IronSharp.Core.Types;

namespace IronSharp.Core
{
    public class RestClient: IRequestHelpersContainer
    {
        private HttpClient httpClient;

        public RestClient()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Generates the Uri for the specified request.
        /// </summary>
        /// <param name="config">The project id and other config values</param>
        /// <param name="request">The request endpoint and query parameters</param>
        /// <param name="token">(optional) The token to use for the building the request uri if different than the Token specified in the config.</param>
        public Uri BuildRequestUri(IronClientConfig config, IRestClientRequest request, string token = null)
        {
            if (string.IsNullOrEmpty(token))
            {
                token = config.Token;
            }
            SetOathQueryParameterIfRequired(request, token);
            return BuildUri(config, request.EndPoint, request.Query);
        }

        public RestResponse<T> Delete<T>(IronClientConfig config, string endPoint, NameValueCollection query = null, Object payload = null) where T : class
        {
            var requestBuilder = new HttpRequestMessageBuilder(config, this, new RestClientRequest
            {
                EndPoint = endPoint,
                Query = query,
                Method = HttpMethod.Delete
            });

            IronSharpConfig sharpConfig = config.SharpConfig;

            if (payload != null)
            {
                requestBuilder.Payload = payload;
            }

            return new RestResponse<T>(AttemptRequest(sharpConfig, requestBuilder));
        }

        public Task<HttpResponseMessage> Execute(IronClientConfig config, IRestClientRequest request)
        {
            var requestBuilder = new HttpRequestMessageBuilder(config, this, new RestClientRequest
            {
                EndPoint = request.EndPoint,
                Query = request.Query,
                Method = request.Method,
                Content = request.Content
            });

            return httpClient.SendAsync(requestBuilder.Build());
        }

        public RestResponse<T> Get<T>(IronClientConfig config, string endPoint, NameValueCollection query = null) where T : class
        {
            var requestBuilder = new HttpRequestMessageBuilder(config, this, new RestClientRequest
            {
                EndPoint = endPoint,
                Query = query,
                Method = HttpMethod.Get
            });

            return new RestResponse<T>(AttemptRequest(config.SharpConfig, requestBuilder));
        }

        public RestResponse<T> Post<T>(IronClientConfig config, string endPoint, object payload = null, NameValueCollection query = null) where T : class
        {
            var requestBuilder = new HttpRequestMessageBuilder(config, this, new RestClientRequest
            {
                EndPoint = endPoint,
                Query = query,
                Method = HttpMethod.Post
            });

            IronSharpConfig sharpConfig = config.SharpConfig;

            if (payload != null)
            {
                requestBuilder.Payload = payload;
            }

            return new RestResponse<T>(AttemptRequest(sharpConfig, requestBuilder));
        }

        public RestResponse<T> Put<T>(IronClientConfig config, string endPoint, object payload, NameValueCollection query = null) where T : class
        {
            var requestBuilder = new HttpRequestMessageBuilder(config, this, new RestClientRequest
            {
                EndPoint = endPoint,
                Query = query,
                Method = HttpMethod.Put
            });

            IronSharpConfig sharpConfig = config.SharpConfig;

            if (payload != null)
            {
                requestBuilder.Payload = payload;
            }

            return new RestResponse<T>(AttemptRequest(sharpConfig, requestBuilder));
        }

        public RestResponse<T> Patch<T>(IronClientConfig config, string endPoint, object payload, NameValueCollection query = null) where T : class
        {
            var requestBuilder = new HttpRequestMessageBuilder(config, this, new RestClientRequest
            {
                EndPoint = endPoint,
                Query = query,
                Method = new HttpMethod("PATCH")
            });

            IronSharpConfig sharpConfig = config.SharpConfig;

            if (payload != null)
            {
                requestBuilder.Payload = payload;
            }

            return new RestResponse<T>(AttemptRequest(sharpConfig, requestBuilder));
        }

        private HttpResponseMessage AttemptRequest(IronSharpConfig sharpConfig, HttpRequestMessageBuilder requestBuilder, int attempt = 0)
        {
            var request = requestBuilder.Build();
            if (attempt > HttpClientOptions.RetryLimit)
            {
                throw new MaximumRetryAttemptsExceededException(request, HttpClientOptions.RetryLimit);
            }

            ILog logger = LogManager.GetLogger<RestClient>();

            if (logger.IsDebugEnabled)
            {
                using (var sw = new StringWriter())
                {
                    sw.WriteLine("{0} {1}", request.Method, request.RequestUri);
                    if (request.Content != null)
                    {
                        sw.WriteLine(request.Content.ReadAsStringAsync().Result);
                    }
                    logger.Debug(sw.ToString());
                }
            }

            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            if (logger.IsDebugEnabled)
            {
                if (response.Content != null)
                {
                    logger.Debug(response.Content.ReadAsStringAsync().Result);
                }
            }

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            if (HttpClientOptions.EnableRetry && IsRetriableStatusCode(response))
            {
                attempt++;

                ExponentialBackoff.Sleep(sharpConfig.BackoffFactor, attempt);

                return AttemptRequest(sharpConfig, requestBuilder, attempt);
            }

            return response;
        }

        private HttpRequestMessage BuildRequest(IronClientConfig config, IRestClientRequest request)
        {
            SetOathQueryParameterIfRequired(request, config.Token);
            var httpRequest = new HttpRequestMessage
            {
                Content = request.Content,
                RequestUri = BuildUri(config, request.EndPoint, request.Query),
                Method = request.Method
            };

            HttpRequestHeaders headers = httpRequest.Headers;
            SetOauthHeaderIfRequired(config, request, headers);
            headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            headers.Accept.Add(new MediaTypeWithQualityHeaderValue(request.Accept));

            return httpRequest;
        }

        public Uri BuildUri(IronClientConfig config, string path, NameValueCollection query)
        {
            if (path.StartsWith("/"))
            {
                path = path.Substring(1);
            }

            string queryString = "";

            if (query != null && query.Count > 0)
            {
                NameValueCollection httpValueCollection = HttpUtility.ParseQueryString("");

                httpValueCollection.Add(query);

                queryString = httpValueCollection.ToString();
            }

            var scheme = String.IsNullOrEmpty(config.Scheme) ? Uri.UriSchemeHttps : config.Scheme;
            var uriBuilder = new UriBuilder(scheme, config.Host)
            {
                Path = string.Format("{0}/{1}", config.ApiVersion, path.Replace("{Project ID}", config.ProjectId)),
                Query = queryString
            };
            if (config.Port.HasValue)
                uriBuilder.Port = config.Port.Value;

            return uriBuilder.Uri;
        }

        private bool IsRetriableStatusCode(HttpResponseMessage response)
        {
            return response != null && response.StatusCode == HttpStatusCode.ServiceUnavailable;
        }

        public void SetOathQueryParameterIfRequired(IRestClientRequest request, string token)
        {
            if (request.AuthTokenLocation != AuthTokenLocation.Querystring) return;

            request.Query = request.Query ?? new NameValueCollection();
            request.Query["oauth"] = token;
        }

        public virtual void SetOauthHeaderIfRequired(IronClientConfig config, IRestClientRequest request, HttpRequestHeaders headers)
        {
            if (request.AuthTokenLocation == AuthTokenLocation.Header)
            {
                headers.Authorization = new AuthenticationHeaderValue("OAuth", config.Token);
            }
        }
    }
}