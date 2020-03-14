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
                    var DB = new BG_DBEntities();
                    string ID = DB.AspNetUsers.FirstOrDefault(x => x.Email.Trim() == User.Identity.Name.Trim()).Id;
                    ViewBag.BrokerColumns = GetBrokerColumn(ID);
                    result = httpClient.GetAsync(Config.get_broker_stocks + "/" + User.Identity.Name + "/").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        Data = JsonConvert.DeserializeObject<List<DiamondStockViewModel>>(resultContent);
                        ViewBag.StockDatas = Data;
                    }
                }

            }
            return View(model);
        }

        public List<string> GetBrokerColumn(string UserID)
        {
            var DB = new BG_DBEntities();
            var Columns = DB.BrokerColumnMappingMsts.Where(x => x.UserId == UserID).OrderBy(c => c.Sort).ToList();
            return Columns.Select(x => x.BrokerColumnName.ColumnName).ToList();
        }
    }
}