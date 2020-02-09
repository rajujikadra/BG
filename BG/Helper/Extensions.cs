using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BG.Helper
{
    public static class Extensions
    {
        public static GenericResponse<T> SetErrorMessages<T>(this GenericResponse<T> status, Controller controller)
        {
            List<string> msgList = new List<string>();
            foreach (var item in controller.ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    if (string.IsNullOrEmpty(error.ErrorMessage) && error.Exception != null)
                        msgList.Add(error.Exception.Message);
                    else
                        msgList.Add(error.ErrorMessage);
                }
            }
            status.StatusCode = HttpStatusCode.NotAcceptable;
            status.Messages = msgList;
            return status;
        }
        public static DefaultResponse AsDefault<T>(this GenericResponse<T> status)
        {
            return status as DefaultResponse;
        }
    }
}