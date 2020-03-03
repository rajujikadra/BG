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
using Microsoft.AspNet.Identity;
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
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
                }
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
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
                }
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
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<ApplicationUserViewModel>(resultContent);
                }
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
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<bool>(resultContent);
                }
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
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<bool>(resultContent);
                }
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
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<bool>(resultContent);
                }
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Assign Sales person modal
        [ActionName("GetAllSalesPerson")]
        [Route("GetAllSalesPerson")]
        public ActionResult GetAllSalesPerson(string Email)
        {
            ViewBag.CustomerID = Email;
            var model = new List<SalesPersons>();
            var DB = new BG_DBEntities();
            var user = DB.AspNetUsers.FirstOrDefault(x => x.Email == Email);
            ViewBag.UserName = user != null ? user.FirstName.Trim().ToUpper() + " " + user.LastName.Trim().ToUpper() : "";
            string RoleId = DB.AspNetRoles.FirstOrDefault(x => x.Name.Equals(EnumTypes.RoleList.SALESPERSON.ToString())).Id;
            if (!string.IsNullOrEmpty(RoleId))
            {
                model = DB.AspNetUsers.Where(x => x.Active == true && x.EmailConfirmed == true && x.AspNetRoles.Any(c => c.Id == RoleId)).Select(y => new SalesPersons()
                {
                    SalesPersonID = y.Id,
                    SalesPersonName = (y.FirstName + " " + y.LastName).Trim().ToUpper()
                }).OrderBy(v => v.SalesPersonName).ToList();
            }
            return PartialView("_AssignSalesPerson", model);
        }
        #endregion
        #region assign sales person
        [ActionName("AssignSalesPersons")]
        [Route("AssignSalesPersons")]
        public ActionResult AssignSalesPersons(string CustomerEmail, string SalesPersonID)
        {
            try
            {
                var DB = new BG_DBEntities();
                string CurrentUserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
                string CustomerID = DB.AspNetUsers.FirstOrDefault(x => x.Email == CustomerEmail).Id;
                var obj = new AssignSalesPersonMst
                {
                    Active = true,
                    CreatedDate = DateTime.Now,
                    CreatedBy = CurrentUserID,
                    SalesPersonID = SalesPersonID,
                    CustomerID = CustomerID
                };
                DB.AssignSalesPersonMsts.Add(obj);
                DB.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}