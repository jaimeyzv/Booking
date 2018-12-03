﻿using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IronSharp.IronMQ
{
    public class Alert
    {
        public Alert() : this(AlertType.Fixed, AlertDirection.Asc, null, null)
        {
        }

        public Alert(AlertType type, AlertDirection direction, int? trigger, string queue)
        {
            Type = type;
            Direction = direction;
            Trigger = trigger;
            Queue = queue;
        }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("snooze", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Snooze { get; set; }

        [JsonProperty("queue", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Queue { get; set; }

        [JsonProperty("trigger", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Trigger { get; set; }

        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Include)]
        public AlertType Type { get; set; }

        [JsonProperty("direction", DefaultValueHandling = DefaultValueHandling.Include)]
        public AlertDirection Direction { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("status_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        protected int? Code { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode
        {
            get { return (HttpStatusCode) Code.GetValueOrDefault(200); }
        }
    }
}