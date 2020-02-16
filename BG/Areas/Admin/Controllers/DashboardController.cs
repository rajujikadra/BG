using BG.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}