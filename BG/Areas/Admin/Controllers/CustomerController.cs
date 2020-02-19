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
    //[RoutePrefix("customer")]
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }

        #region get new customers
        [HttpGet]
        [Route("customers/{active}")]
        public ActionResult GetNewCustomers(string active)
        {
            var model = new List<ApplicationUserViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.new_customers + "/" + active).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
            }
            return View(model);
        }
        #endregion
    }
}