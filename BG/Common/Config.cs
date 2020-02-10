using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BG.Common
{
    public static class Config
    {
        public static readonly string API = "http://localhost:56718/";
        public static readonly string TokenURL = "Token";
        public static readonly string TokenType = "bearer";


        // API URL
        public static readonly string logout = "api/Account/Logout";
    }
}