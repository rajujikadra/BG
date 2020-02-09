using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BG.Helper
{
    public class Token
    {
        public string expires_in { get; set; }

        public string access_token { get; set; }

        public string token_type { get; set; }

        public string userName { get; set; }

        public string email { get; set; }

        public string role { get; set; }

        public string id { get; set; }
    }
}