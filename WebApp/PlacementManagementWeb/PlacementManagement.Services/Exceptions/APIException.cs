using System;
using System.Net;

namespace PlacementManagement.Services.Exceptions
{
    /// <summary>
    /// Represents errors that occur while calling Http requests
    /// </summary>
    public class APIException : Exception
    {
        public APIException()
        {
        }

        public HttpStatusCode StatusCode { get; set; }

        public APIException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}