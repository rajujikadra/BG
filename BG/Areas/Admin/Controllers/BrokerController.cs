using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
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
    }
}