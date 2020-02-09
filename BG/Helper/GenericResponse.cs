using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BG.Helper
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
            this.Messages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Status => StatusCode.ToString();

        public T Data { get; set; }

        public List<string> Messages { get; set; }
    }
    public class DefaultResponse : GenericResponse<string>
    {
        public DefaultResponse()
        {
        }
        public DefaultResponse(HttpStatusCode statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Messages = new List<string>() { message };
        }
        public DefaultResponse(HttpStatusCode statusCode, string[] messages)
        {
            this.StatusCode = statusCode;
            this.Messages = messages.ToList();
        }
    }
}