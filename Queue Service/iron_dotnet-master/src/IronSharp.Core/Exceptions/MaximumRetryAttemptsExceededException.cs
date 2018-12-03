﻿using System.Net.Http;

namespace IronSharp.Core
{
    public class MaximumRetryAttemptsExceededException : IronSharpException
    {
        private readonly HttpRequestMessage _request;

        public MaximumRetryAttemptsExceededException(HttpRequestMessage request, int maxAttempts)
            : base(string.Format("The maximum number of retry attempts ({0}) has been exceeded.", maxAttempts))
        {
            _request = request;
        }

        public HttpRequestMessage Request
        {
            get { return _request; }
        }
    }
}