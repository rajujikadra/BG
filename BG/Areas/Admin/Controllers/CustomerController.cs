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
        [Route("customers/new")]
        public ActionResult GetNewCustomers()
        {
            var model = new List<ApplicationUserViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.new_customers).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
            }
            return View(model);
        }
        #endregion

        #region get new customers
        [HttpGet]
        [Route("customers/register")]
        public ActionResult GetRegisterCustomers()
        {
            var model = new List<ApplicationUserViewModel>();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.Register_customers).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
            }
            return View(model);
        }
        #endregion

        #region customer details
        [HttpGet]
        [Route("customer/{userid}")]
        public ActionResult CustomeDetails(string userid)
        {
            var model = new ApplicationUserViewModel();
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.get_customer_detail + "/" + userid).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ApplicationUserViewModel>(resultContent);
            }
            return View(model);
        }
        #endregion

        #region deactivate customer
        [ActionName("DeactivateCustomer")]
        [Route("DeactivateCustomer")]
        public ActionResult DeactivateCustomer(string Email)
        {
            bool status = false;
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.customer_deactivate + "/" + Email + "/").Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                status = JsonConvert.DeserializeObject<bool>(resultContent);
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region deactivate customer
        [ActionName("ActivateCustomer")]
        [Route("ActivateCustomer")]
        public ActionResult ActivateCustomer(string Email)
        {
            bool status = false;
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.customer_activate + "/" + Email + "/").Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                status = JsonConvert.DeserializeObject<bool>(resultContent);
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region activate new customer
        [ActionName("ActivateNewCustomer")]
        [Route("ActivateNewCustomer")]
        public ActionResult ActivateNewCustomer(string Email)
        {
            bool status = false;
            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.new_customer_activate + "/" + Email + "/").Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;
                status = JsonConvert.DeserializeObject<bool>(resultContent);
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}