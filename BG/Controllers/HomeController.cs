using BG_Application.CustomDTO;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!CurrentUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[ChildActionOnly]
        //public PartialViewResult GetMenu()
        //{
        //    var DB = new BG_DBEntities();
        //    var menu = DB.MainMenuMsts.Where(x => x.Active == true).Select(y => new MenuViewModel()
        //    {
        //        MainMenuName = y.MainMenuName,
        //        URL = y.URL,
        //        Icon = y.Icon,
        //        MainMenuMstID = y.MainMenuMstID,
        //        Active = y.Active,
        //        SubMenu = y.MenuMsts.Where(v => v.Active == true).Select(c => new SubMenuViewModel()
        //        {
        //            MenuName = c.MenuName,
        //            URL = c.URL,
        //            Active = c.Active,
        //            Icon = c.Icon,
        //            MenuMstId = c.MenuMstId
        //        }).ToList()
        //    }).ToList();
        //    return PartialView("_MenuPartial", menu);
        //}
    }
}