using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace PlacementManagement.API.Utils
{
    public static class HttpUtils
    {
        public static HttpResponseMessage GetHttpResponse(HttpStatusCode statusCode, string message)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                ReasonPhrase = message
            };
        }
    }
}