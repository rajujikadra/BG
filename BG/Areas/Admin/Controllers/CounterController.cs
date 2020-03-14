using BG.Helper;
using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    public class CounterController : Controller
    {
        // GET: Admin/Counter
        public ActionResult Index()
        {
            var DB = new BG_DBEntities();
            ViewBag.Country = DB.CountryMsts.Where(v => v.Active == true).Select(x => new CountryViewModel()
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName
            }).OrderBy(c => c.CountryName).ToList();
            ViewBag.State = new List<SelectListItem>();
            ViewBag.City = new List<SelectListItem>();
            ViewBag.RoleList = Enum.GetValues(typeof(EnumTypes.RoleList)).Cast<EnumTypes.RoleList>().Select(x => new SelectListViewModel() { Text = x.ToString(), Value = x.ToString() }).ToList();
            var MenuModel = new List<SalesPersonMenuPermissionViewModel>();
            MenuModel = DB.MainMenuMsts.Select(x => new SalesPersonMenuPermissionViewModel()
            {
                MenuID = x.MainMenuMstID,
                MenuName = x.MainMenuName
            }).ToList();
            var SubMenu = DB.MenuMsts.Select(x => new SalesPersonMenuPermissionViewModel()
            {
                MenuID = x.MenuMstId,
                MenuName = x.MenuName
            }).ToList();
            MenuModel.AddRange(SubMenu);
            ViewBag.Menus = MenuModel;
            ViewBag.Columns = DB.BrokerColumnNames.Select(x => new BrokerColumnsViewModel()
            {
                ColumnName = x.ColumnName,
                ColumnId = x.ColumnId
            }).ToList();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddCounters(CounterViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new DefaultResponse().SetErrorMessages(this).AsDefault(), JsonRequestBehavior.AllowGet);
            return null;
        }

        public ActionResult GetStates(int CountryId)
        {
            var DB = new BG_DBEntities();
            var State = DB.StateMsts.Where(x => x.CountryId == CountryId && x.Active == true).Select(y => new StateViewModel()
            {
                StateId = y.StateId,
                StateName = y.StateName
            }).OrderBy(c => c.StateName).ToList();
            return Json(State, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity(int StateId)
        {
            var DB = new BG_DBEntities();
            var City = DB.CityMsts.Where(x => x.StateId == StateId && x.Active == true).Select(y => new CityViewModel()
            {
                CityId = y.CityId,
                CityName = y.CityName
            }).OrderBy(c => c.CityName).ToList();
            return Json(City, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenuPermission()
        {
            var DB = new BG_DBEntities();
            var model = new List<SalesPersonMenuPermissionViewModel>();
            model = DB.MainMenuMsts.Select(x => new SalesPersonMenuPermissionViewModel()
            {
                MenuID = x.MainMenuMstID,
                MenuName = x.MainMenuName
            }).ToList();
            var SubMenu = DB.MenuMsts.Select(x => new SalesPersonMenuPermissionViewModel()
            {
                MenuID = x.MenuMstId,
                MenuName = x.MenuName
            }).ToList();
            model.AddRange(SubMenu);
            return PartialView("_MenuPermission", model);
        }
        public ActionResult GetBrokerColumn()
        {
            var DB = new BG_DBEntities();
            var model = new List<BrokerColumnsViewModel>();
            model = DB.BrokerColumnNames.Select(x => new BrokerColumnsViewModel()
            {
                ColumnName = x.ColumnName,
                ColumnId = x.ColumnId
            }).ToList();
            return PartialView("_ColumnPermission", model);
        }

        public ActionResult Register(CounterViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new DefaultResponse().SetErrorMessages(this).AsDefault(), JsonRequestBehavior.AllowGet);
            try
            {
                bool IsSuccess = ApiHelper.CounterRegister(model);
                if (IsSuccess)
                {
                    var DB = new BG_DBEntities();
                    string ID = DB.AspNetUsers.FirstOrDefault(x => x.Email.Trim() == model.Email.Trim()).Id;
                    if (!string.IsNullOrEmpty(ID))
                    {
                        var MenuNames = JsonConvert.DeserializeObject<List<string>>(model.MenuNames);
                        var Columns = JsonConvert.DeserializeObject<List<BrokerColumnsViewModel>>(model.ColumnName);
                        if (MenuNames.Count() > 0)
                        {
                            bool status = AddMenuPermission(ID, MenuNames);
                        }
                        if (Columns.Count() > 0)
                        {
                            bool status = AddColumnPermission(ID, Columns);
                        }
                    }
                }
                return Json(new DefaultResponse(HttpStatusCode.OK, ""), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new DefaultResponse(HttpStatusCode.NotFound, "Invalid email or password."));
            }
        }

        public bool AddColumnPermission(string UserID, List<BrokerColumnsViewModel> BrokerColumn)
        {
            int?[] BrokerID = null;
            if (BrokerColumn.Count() > 0 && BrokerColumn != null)
                BrokerID = BrokerColumn.Select(x => (int?)x.ColumnId).ToArray();
            if (BrokerID != null)
            {
                var DB = new BG_DBEntities();
                var BrkCol = DB.BrokerColumnMappingMsts.Where(x => x.UserId == UserID).ToList();
                BrkCol = BrkCol.Where(x => !BrokerID.Contains((int)x.ColumnId)).ToList();
                DB.BrokerColumnMappingMsts.RemoveRange(BrkCol);
                DB.SaveChanges();
                foreach (var c in BrokerColumn)
                {
                    var Col = DB.BrokerColumnMappingMsts.FirstOrDefault(x => x.UserId == UserID && x.ColumnId == c.ColumnId);
                    if (Col == null)
                    {
                        var obj = new BrokerColumnMappingMst { ColumnId = c.ColumnId, Sort = c.Sort ?? c.ColumnId, UserId = UserID };
                        DB.BrokerColumnMappingMsts.Add(obj);
                        DB.SaveChanges();
                    }
                    else
                    {
                        Col.Sort = c.Sort ?? c.ColumnId;
                        DB.SaveChanges();
                    }
                }
                return true;
            }
            return false;
        }
        public bool AddMenuPermission(string UserID, List<string> MenuNames)
        {
            var DB = new BG_DBEntities();
            if (MenuNames != null)
            {
                MenuNames = MenuNames.Select(s => s.ToLowerInvariant().Trim()).ToList();
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
                return true;
            }
            return false;
        }
    }
}