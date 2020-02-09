using BG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;

namespace BG.Helper
{
    public class ApiHelper
    {
        private static HttpClient GetHttpClient()
        {
            var myHttpClient = new HttpClient();
            string token = null;
            var user = HttpContext.Current.User as ClaimsPrincipal;
            if (user?.Identity != null && user.Identity.IsAuthenticated)
                token = user.FindFirst("AcessToken").Value;
            myHttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["API_URL"]);
            if (!string.IsNullOrEmpty(token))
                myHttpClient.DefaultRequestHeaders.Add("Authorization", token);
            return myHttpClient;
        }
        public static Token Login(LoginViewModel model)
        {
            using (var httpClient = GetHttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", model.UserName),
                    new KeyValuePair<string, string>("password", model.Password)
                });

                var result = httpClient.PostAsync("Token", content).Result;

                var resultContent = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Token>(resultContent);
            }
        }
    }
}