using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;


namespace BG.Models
{
    public class AuthorizeEntryPermission : AuthorizeAttribute
    {

        public string Permission { get; set; }
        public AuthorizeEntryPermission()
        {
        }
        public AuthorizeEntryPermission(string Permission)
        {
            this.Permission = Permission;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string CurrentUserEmail = httpContext.User.Identity.Name;
            Permission = Permission.Replace("_", " ");
            //var ID = HttpContext.Current.Request.RequestContext.RouteData.Values["Id"];
            //check your permissions
            var DB = new BG_DBEntities();
            string UserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == CurrentUserEmail).Id;
            bool IsAccess = DB.UserMenuPermissionMsts.Any(x => x.MainMenuMst.MainMenuName.ToLower().Trim().Equals(Permission.ToLower().Trim()) && x.UserId == UserID);
            if (!IsAccess)
            {
                return DB.UserMenuPermissionMsts.Any(x => x.MenuMst.MenuName.ToLower().Trim().Equals(Permission.ToLower().Trim()) && x.UserId == UserID);
            }
            else
            {
                return true;
            }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
                // ** IMPORTANT **
                // Since we're performing authorization at the action level, the authorization code runs
                // after the output caching module. In the worst case this could allow an authorized user
                // to cause the page to be cached, then an unauthorized user would later be served the
                // cached page. We work around this by telling proxies not to cache the sensitive page,
                // then we hook our custom authorization code into the caching mechanism so that we have
                // the final say on whether a page should be served from the cache.
                HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
            }
            else
            {
                //handle no permission
                filterContext.Result = new RedirectResult("~/Error");
            }
        }
        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        }
    }
}