using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BG
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }
        //protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.Request.RawUrl.Contains("/Error"))
        //        return;
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        string URL = HttpContext.Current.Request.RawUrl;
        //        if (URL.Contains("admin"))
        //        {
        //            var DB = new BG_DBEntities();
        //            string ID = DB.AspNetUsers.FirstOrDefault(x => x.Email.Trim() == User.Identity.Name.Trim()).Id;
        //            if (!string.IsNullOrEmpty(ID))
        //            {
        //                var MainMenuURL = DB.UserMenuPermissionMsts.Where(x => x.UserId == ID && x.MainMenuMst.Active == true).Select(y => y.MainMenuMst.URL.Trim().ToLower()).Distinct().ToList();
        //                var MenuURL = DB.UserMenuPermissionMsts.Where(x => x.UserId == ID && x.MenuMst.Active == true).Select(y => y.MenuMst.URL.Trim().ToLower()).Distinct().ToList();
        //                MainMenuURL.AddRange(MenuURL);
        //                MainMenuURL.Add("/");
        //                MainMenuURL.Add("/Account/LogOff".ToLower());
        //                MainMenuURL.Add("/admin/customers/new");
        //                MainMenuURL.Add("/admin/customers/register");
        //                MainMenuURL.Add("/admin/sales-person");
        //                bool IsMenuAccess = MainMenuURL.Contains(URL.ToLower().Trim());
        //                if (!IsMenuAccess)
        //                {
        //                    HttpContext.Current.Response.Redirect("~/Error");
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
