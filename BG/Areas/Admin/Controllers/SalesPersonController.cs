using BG.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Areas.Admin.Controllers
{
    public class SalesPersonController : BaseController
    {
        // GET: Admin/SalesPerson
        public ActionResult Index()
        {
            if (!CurrentUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
    }
}