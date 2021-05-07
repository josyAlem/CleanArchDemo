using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CleanArch.Application.Common
{
    public class ResponseObject
    {
        public ResponseObject(string msg,HttpStatusCode statusCode=HttpStatusCode.NoContent)
        {
            this.Message = msg;
            this.StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
