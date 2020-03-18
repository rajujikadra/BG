using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Newtonsoft.Json;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    [RoutePrefix("sales-person")]
    public class SalesPersonController : Controller
    {
        // GET: Admin/SalesPerson
        [Route]
        [AuthorizeEntryPermission(Permission = "Sales Persons")]
        public ActionResult Index()
        {
            var model = new List<ApplicationUserViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.get_sales_persons).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        #region get sales person menu permission
        [HttpGet]
        [Route("salespersonMenu")]
        public ActionResult GetAllSalesPersonMenu(string UserID)
        {
            var DB = new BG_DBEntities();
            var User = DB.AspNetUsers.Where(x => x.Id == UserID).Select(y => new ApplicationUserViewModel() { FirstName = y.FirstName, LastName = y.LastName }).FirstOrDefault();
            ViewBag.SalesPersonName = User.FirstName + " " + User.LastName;
            ViewBag.SalesPersonID = UserID;
            var model = new List<SalesPersonMenuPermissionViewModel>();
            model = DB.MainMenuMsts.Select(x => new SalesPersonMenuPermissionViewModel()
            {
                MenuID = x.MainMenuMstID,
                MenuName = x.MainMenuName,
                IsDisplay = x.UserMenuPermissionMsts.Any(c => c.MainMenuMstId == x.MainMenuMstID && c.UserId == UserID)
            }).ToList();
            var SubMenu = DB.MenuMsts.Select(x => new SalesPersonMenuPermissionViewModel()
            {
                MenuID = x.MenuMstId,
                MenuName = x.MenuName,
                IsDisplay = x.UserMenuPermissionMsts.Any(c => c.MenuMstId == x.MenuMstId && c.UserId == UserID)
            }).ToList();
            model.AddRange(SubMenu);
            return PartialView("_MenuPermissions", model);
        }
        #endregion
        #region set meniu permission to sales person
        public ActionResult SetMenuPerimission(string UserID, string[] MenuNames)
        {
            var DB = new BG_DBEntities();
            if (MenuNames != null)
            {
                MenuNames = MenuNames.Select(s => s.ToLowerInvariant().Trim()).ToArray();
                var MainMenuIDs = DB.MainMenuMsts.Where(x => MenuNames.Contains(x.MainMenuName.ToLower().Trim())).Select(y => y.MainMenuMstID).ToList();
                var SubMenuIDs = DB.MenuMsts.Where(x => MenuNames.Contains(x.MenuName.ToLower().Trim())).Select(y => y.MenuMstId).ToList();

                var AlreadyMainMenu = DB.UserMenuPermissionMsts.Where(x => x.MenuMstId == null && x.UserId == UserID).ToList();
                AlreadyMainMenu = AlreadyMainMenu.Where(x => !MainMenuIDs.Contains((int)x.MainMenuMstId)).ToList();
                DB.UserMenuPermissionMsts.RemoveRange(AlreadyMainMenu);
                DB.SaveChanges();

                var AlreadySubMenu = DB.UserMenuPermissionMsts.Where(x => x.MenuMstId != null && x.UserId == UserID).ToList();
                AlreadySubMenu = AlreadySubMenu.Where(x => !SubMenuIDs.Contains((int)x.MenuMstId)).ToList();
                DB.UserMenuPermissionMsts.RemoveRange(AlreadySubMenu);
                DB.SaveChanges();

                foreach (var m in MainMenuIDs)
                {
                    var MainMenu = DB.UserMenuPermissionMsts.FirstOrDefault(x => x.MainMenuMstId == m && x.UserId == UserID);
                    if (MainMenu == null)
                    {
                        var obj = new UserMenuPermissionMst { MainMenuMstId = m, UserId = UserID, MenuMstId = null };
                        DB.UserMenuPermissionMsts.Add(obj);
                        DB.SaveChanges();
                    }
                }
                foreach (var s in SubMenuIDs)
                {
                    var SubMenu = DB.UserMenuPermissionMsts.FirstOrDefault(x => x.MenuMstId == s && x.UserId == UserID);
                    if (SubMenu == null)
                    {
                        var obj = new UserMenuPermissionMst
                        {
                            MenuMstId = s,
                            UserId = UserID,
                            MainMenuMstId = DB.MenuMsts.FirstOrDefault(x => x.MenuMstId == s).MainMenuMstId
                        };
                        DB.UserMenuPermissionMsts.Add(obj);
                        DB.SaveChanges();
                    }
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var AllMenus = DB.UserMenuPermissionMsts.Where(x => x.UserId == UserID).ToList();
                DB.UserMenuPermissionMsts.RemoveRange(AllMenus);
                DB.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}