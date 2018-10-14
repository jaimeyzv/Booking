using Payment.Infrastructure.Interfaces.Wrappers;
using Stamping.Api.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Payment.Infrastructure.Wrappers
{
    public class ApiResponseWrapper : IApiResponseWrapper
    {
        public HttpResponseMessage Response(HttpStatusCode httpStatusCode, object viewModel)
        {
            ApiResponse response = BuildReponse(httpStatusCode, viewModel);
            HttpResponseMessage httpResponseMessage = BuildHttpResponseMessage(response);

            return httpResponseMessage;
        }

        private static ApiResponse BuildReponse(HttpStatusCode httpStatusCode, object viewModel)
        {
            return new ApiResponse()
            {
                Date = String.Format("{0:M/d/yyyy HH:mm:ss}", DateTime.Now),
                HttpStatusCode = httpStatusCode,
                ReasonPhrase = httpStatusCode.ToString(),
                Response = viewModel
            };
        }

        private static HttpResponseMessage BuildHttpResponseMessage(ApiResponse response)
        {
            return new HttpResponseMessage()
            {
                StatusCode = response.HttpStatusCode,
                ReasonPhrase = response.HttpStatusCode.ToString(),
                Content = new ObjectContent<ApiResponse>(response, new JsonMediaTypeFormatter(), @"application/json")
            };
        }
    }
}