using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(BG.Startup))]

namespace BG
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(40),
                SlidingExpiration = true,
                CookieSecure = CookieSecureOption.SameAsRequest,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}