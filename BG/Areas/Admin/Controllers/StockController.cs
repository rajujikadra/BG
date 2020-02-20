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
    [RoutePrefix("stock")]
    public class StockController : Controller
    {
        // GET: Admin/Stock
        [Route]
        public ActionResult Index()
        {
            var model = new List<DiamondStockViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.get_stock).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<DiamondStockViewModel>>(resultContent);
            }
            return View(model);
        }
    }
}