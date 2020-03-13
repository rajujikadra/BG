using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    public class BrokerController : Controller
    {
        // GET: Admin/Broker
        public ActionResult Index()
        {
            return View();
        }

        #region get brokers
        [HttpGet]
        [Route("broker")]
        public ActionResult GetAllBrokers(string active)
        {
            var model = new List<ApplicationUserViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.get_broker).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
                }
            }
            return View(model);
        }
        #endregion

        #region get broker columns
        [HttpGet]
        [Route("brokercolumn")]
        public ActionResult GetAllBrokerColumn(string UserID)
        {
            var DB = new BG_DBEntities();
            var User = DB.AspNetUsers.Where(x => x.Id == UserID).Select(y => new ApplicationUserViewModel() { FirstName = y.FirstName, LastName = y.LastName }).FirstOrDefault();
            ViewBag.BrokerName = User.FirstName + " " + User.LastName;
            ViewBag.BrokerID = UserID;
            var model = new List<BrokerColumnsViewModel>();
            model = DB.BrokerColumnNames.Select(x => new BrokerColumnsViewModel()
            {
                ColumnName = x.ColumnName,
                ColumnId = x.ColumnId,
                IsDisplay = x.BrokerColumnMappingMsts.Count(c => c.UserId == UserID) > 0 ? true : false,
                UserId = UserID,
                Sort = (int)x.BrokerColumnMappingMsts.FirstOrDefault(v => v.ColumnId == x.ColumnId && v.UserId == UserID).Sort
            }).ToList();
            return PartialView("_BrokerColumns", model);
        }
        #endregion

        #region set broker permission
        public ActionResult SetPerimission(string UserID, List<BrokerColumnsViewModel> BrokerColumn)
        {
            int?[] BrokerID = null;
            if (BrokerColumn.Count() > 0 && BrokerColumn != null)
                BrokerID = BrokerColumn.Select(x => (int?)x.ColumnId).ToArray();
            if (BrokerID != null)
            {
                var DB = new BG_DBEntities();
                var BrkCol = DB.BrokerColumnMappingMsts.Where(x => x.UserId == UserID).ToList();
                BrkCol = BrkCol.Where(x => !BrokerID.Contains(x.ColumnId)).ToList();
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
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}