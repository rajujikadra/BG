using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
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

        [Route("color-master")]
        public ActionResult GetAllColorMst()
        {
            var model = new List<ColorViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.color_master).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<ColorViewModel>>(resultContent);
            }
            return View(model);
        }
    }
}