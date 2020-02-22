using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
using BG_Application.Data;
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
            var menu = DB.MainMenuMsts.Where(x => x.Active == true).Select(y => new MenuViewModel()
            {
                MainMenuName = y.MainMenuName,
                URL = y.URL,
                Icon = y.Icon,
                MainMenuMstID = y.MainMenuMstID,
                Active = y.Active,
                SubMenu = y.MenuMsts.Where(v => v.Active == true).Select(c => new SubMenuViewModel()
                {
                    MenuName = c.MenuName,
                    URL = c.URL,
                    Active = c.Active,
                    Icon = c.Icon,
                    MenuMstId = c.MenuMstId
                }).ToList()
            }).ToList();
            return PartialView("_MenuPartial", menu);
        }
        #endregion
    }
}