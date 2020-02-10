using BG.Common;
using BG.EnumFile;
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
        public static string GetToken()
        {
            var myHttpClient = new HttpClient();
            string token = string.Empty;
            var user = HttpContext.Current.User as ClaimsPrincipal;
            if (user?.Identity != null && user.Identity.IsAuthenticated)
                token = user.FindFirst("AcessToken").Value;
            return token;
        }
        private static HttpClient GetHttpClient()
        {
            var myHttpClient = new HttpClient();
            string token = null;
            var user = HttpContext.Current.User as ClaimsPrincipal;
            if (user?.Identity != null && user.Identity.IsAuthenticated)
                token = user.FindFirst("AcessToken").Value;
            myHttpClient.BaseAddress = new Uri(Config.API);
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
                    new KeyValuePair<string, string>(EnumType.Token.grant_type.ToString(), "password"),
                    new KeyValuePair<string, string>(EnumType.Token.username.ToString(), model.UserName),
                    new KeyValuePair<string, string>(EnumType.Token.password.ToString(), model.Password)
                });

                var result = httpClient.PostAsync(Config.TokenURL, content).Result;

                var resultContent = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Token>(resultContent);
            }
        }
    }
}