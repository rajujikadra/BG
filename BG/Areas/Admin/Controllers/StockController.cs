using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            var Data = (dynamic)null;
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = (dynamic)null;
                if (User.IsInRole(EnumTypes.RoleList.ADMIN.ToString()))
                {
                    result = httpClient.GetAsync(Config.get_stock).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<List<DiamondStockViewModel>>(resultContent);
                    }
                }
                else
                {

                    result = httpClient.GetAsync(Config.get_broker_Columns + "/" + User.Identity.Name + "/").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                         Data = JsonConvert.DeserializeObject<List<dynamic>>(resultContent);
                    }
                }

            }
            return View(model);
        }
    }
}