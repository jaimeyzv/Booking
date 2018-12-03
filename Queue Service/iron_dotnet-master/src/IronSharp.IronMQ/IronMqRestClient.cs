﻿using System.Collections.Generic;
using System.Threading;
using IronSharp.Core;
using IronSharp.Core.Attributes;
using System;

namespace IronSharp.IronMQ
{
    public class IronMqRestClient
    {
        private readonly IronClientConfig _config;
        private MqRestClient _restClient;
        public ITokenContainer TokenContainer { get; set; }

        internal IronMqRestClient(IronClientConfig config)
        {
            _config = LazyInitializer.EnsureInitialized(ref config);
             
            if (_config.Keystone != null)
            {
                if (_config.KeystoneKeysExist())
                {
                    TokenContainer = new KeystoneContainer(_config.Keystone);
                }
                else
                {
                    throw new IronSharpException("Keystone keys missing");
                }
            } 
            else 
            {
                TokenContainer = new IronTokenContainer(_config.Token);
            }    
                
            _restClient = new MqRestClient(TokenContainer);
            
            if (string.IsNullOrEmpty(Config.Host))
            {
                Config.Host = IronMqCloudHosts.DEFAULT;
            }

            if (config.ApiVersion == default (int))
            {
                config.ApiVersion = 3;
            }
        }

        public IronClientConfig Config
        {
            get { return _config; }
        }

        public string EndPoint
        {
            get { return "/projects/{Project ID}/queues"; }
        }

        public QueueClient<T> Queue<T>()
        {
            return new QueueClient<T>(this, QueueNameAttribute.GetName<T>());
        }

        public QueueClient Queue(string name)
        {
            return new QueueClient(this, name);
        }

        /// <summary>
        /// Get a list of all queues in a project.
        /// By default, 30 queues are listed at a time.
        /// To see more, use the page parameter or the per_page parameter.
        /// Up to 100 queues may be listed on a single page.
        /// </summary>
        /// <param name="filter"> </param>
        /// <returns> </returns>
        public IEnumerable<QueueInfo> Queues(MqPagingFilter filter = null)
        {
            var queuesInfo = _restClient.Get<QueuesInfo>(_config, EndPoint, filter).Result;
            return queuesInfo == null ? null : queuesInfo.Queues;
        }
    }
}