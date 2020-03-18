﻿using System;
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
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    [RoutePrefix("master")]
    public class MasterController : Controller
    {
        // GET: Admin/Master
        public ActionResult Index()
        {
            return View();
        }

        #region color master
        [Route("color-master")]
        [AuthorizeEntryPermission(Permission = "Color")]
        public ActionResult GetAllColorMst()
        {
            var model = new List<ColorViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.color_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<ColorViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region certificate master
        [Route("certificate-master")]
        [AuthorizeEntryPermission(Permission = "Certificate")]
        public ActionResult GetAllCertificateMst()
        {
            var model = new List<CertificateViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.certificate_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<CertificateViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region cut master
        [Route("cut-master")]
        [AuthorizeEntryPermission(Permission = "Cut")]
        public ActionResult GetAllCutMst()
        {
            var model = new List<CutViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.cut_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<CutViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region purity master
        [Route("purity-master")]
        [AuthorizeEntryPermission(Permission = "Purity")]
        public ActionResult GetAllPurityMst()
        {
            var model = new List<PurityViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.purity_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<PurityViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region flou master
        [Route("flou-master")]
        [AuthorizeEntryPermission(Permission = "Flou")]
        public ActionResult GetAllFlouMst()
        {
            var model = new List<FlouViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.flou_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<FlouViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region size master
        [Route("size-master")]
        [AuthorizeEntryPermission(Permission = "Size")]
        public ActionResult GetAllSizeMst()
        {
            var model = new List<SizeViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.size_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<SizeViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region party master
        [Route("party-master")]
        [AuthorizeEntryPermission(Permission = "Party")]
        public ActionResult GetAllPartyMst()
        {
            var model = new List<PartyViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.party_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<PartyViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region fancy color master
        [Route("fancy-color-master")]
        [AuthorizeEntryPermission(Permission = "Fancy Color")]
        public ActionResult GetAllFancyColorMst()
        {
            var model = new List<FancyColorViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.fancy_color_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<FancyColorViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region fancy ot master
        [Route("fancy-ot-master")]
        [AuthorizeEntryPermission(Permission = "Fancy OT")]
        public ActionResult GetAllFancyOTMst()
        {
            var model = new List<FancyOTViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.fancy_ot_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<FancyOTViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region shape master
        [Route("shape-master")]
        [AuthorizeEntryPermission(Permission = "Shape")]
        public ActionResult GetAllShapeMst()
        {
            var model = new List<ShapViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.shape_master).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<ShapViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region menu
        [ChildActionOnly]
        public PartialViewResult GetMenu()
        {
            var DB = new BG_DBEntities();
            string UserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
            var menu = DB.UserMenuPermissionMsts.Where(x => x.UserId == UserID && x.MainMenuMst.Active == true).Select(y => new MenuViewModel()
            {
                MainMenuName = y.MainMenuMst.MainMenuName,
                URL = y.MainMenuMst.URL,
                Icon = y.MainMenuMst.Icon,
                Active = y.MainMenuMst.Active,
                MainMenuMstID = y.MainMenuMstId,
                SubMenu = DB.UserMenuPermissionMsts.Where(x => x.UserId == UserID && x.MenuMst.Active == true && x.MainMenuMstId == y.MainMenuMstId).Select(c => new SubMenuViewModel()
                {
                    MenuName = c.MenuMst.MenuName,
                    URL = c.MenuMst.URL,
                    Active = c.MenuMst.Active,
                    Icon = c.MenuMst.Icon,
                    MenuMstId = c.MenuMst.MenuMstId
                }).OrderBy(v => v.MenuMstId).ToList()
            }).DistinctBy(b => b.MainMenuName).OrderBy(v => v.MainMenuMstID).ToList();
            return PartialView("_MenuPartial", menu);
        }
        #endregion
    }
}