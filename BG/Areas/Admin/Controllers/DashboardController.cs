using BG.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Newtonsoft.Json;

namespace BG.Areas.Admin.Controllers
{
    [RouteArea("Admin", AreaPrefix = "admin")]
    [RoutePrefix("dashboard")]
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        [Route]
        public ActionResult Index()
        {
            if (!CurrentUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            var DB = new BG_DBEntities();
            string UserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
            ViewBag.IsMenuPErmission = DB.UserMenuPermissionMsts.Any(x => x.UserId == UserID);
            var model = new AdminDashboardViewModel();
            if (User.IsInRole(EnumTypes.RoleList.ADMIN.ToString()))
            {
                using (var httpClient = ApiHelper.GetHttpClient())
                {
                    var result = httpClient.GetAsync(Config.dashboard).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<AdminDashboardViewModel>(resultContent);
                    }
                }
            }
            else if (User.IsInRole(EnumTypes.RoleList.SALESPERSON.ToString()))
            {
                string CurrentUserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
                model.TilesCount.Customers_Count = DB.AssignSalesPersonMsts.Count(x => x.SalesPersonID == CurrentUserID && x.Active == true);
            }           
            return View(model);
        }
    }
}