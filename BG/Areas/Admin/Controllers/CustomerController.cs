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
using Microsoft.Ajax.Utilities;
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
            if (User.IsInRole(EnumTypes.RoleList.ADMIN.ToString()))
            {
                using (var httpClient = ApiHelper.GetHttpClient())
                {
                    var result = httpClient.GetAsync(Config.Register_customers).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        model = JsonConvert.DeserializeObject<List<ApplicationUserViewModel>>(resultContent);
                    }
                }
            }
            else
            {
                var DB = new BG_DBEntities();
                string CurrentUserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
                model = (from a in DB.AssignSalesPersonMsts
                         where a.SalesPersonID == CurrentUserID && a.Active == true
                         select new ApplicationUserViewModel()
                         {
                             EmailConfirmed = a.AspNetUser1.EmailConfirmed,
                             Id = a.AspNetUser1.Id,
                             FirstName = a.AspNetUser1.FirstName,
                             LastName = a.AspNetUser1.LastName,
                             Email = a.AspNetUser1.Email,
                             CompanyAddress = a.AspNetUser1.CompanyAddress,
                             CompanyCityId = a.AspNetUser1.CompanyCityId,
                             CompanyName = a.AspNetUser1.CompanyName,
                             CompanyZipcode = a.AspNetUser1.CompanyZipcode,
                             CompanyCityName = a.AspNetUser1.CityMst.CityName,
                             ContactPerson = a.AspNetUser1.ContactPerson,
                             Mobile = a.AspNetUser1.Mobile,
                             RefBusiness = a.AspNetUser1.RefBusiness,
                             RefMobile = a.AspNetUser1.RefMobile,
                             RefName = a.AspNetUser1.RefName,
                             UserCityName = a.AspNetUser1.CityMst1.CityName,
                             Active = a.AspNetUser1.Active,
                             UserGSTNO = a.AspNetUser1.UserGSTNO,
                             SalesPersonName = a.AspNetUser2.FirstName + " " + a.AspNetUser2.LastName
                         }).DistinctBy(v => v.Id).ToList();
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
        #region Assign Sales person modal
        [ActionName("GetSalesPerson")]
        [Route("GetSalesPerson")]
        public ActionResult GetSalesPerson()
        {
            var model = new List<SalesPersons>();
            var DB = new BG_DBEntities();
            string RoleId = DB.AspNetRoles.FirstOrDefault(x => x.Name.Equals(EnumTypes.RoleList.SALESPERSON.ToString())).Id;
            if (!string.IsNullOrEmpty(RoleId))
            {
                model = DB.AspNetUsers.Where(x => x.Active == true && x.EmailConfirmed == true && x.AspNetRoles.Any(c => c.Id == RoleId)).Select(y => new SalesPersons()
                {
                    SalesPersonID = y.Id,
                    SalesPersonName = (y.FirstName + " " + y.LastName).Trim().ToUpper()
                }).OrderBy(v => v.SalesPersonName).ToList();
            }
            return PartialView("_AssignSalesPersonModal", model);
        }
        #endregion

        #region Change sales person 
        [ActionName("ChangeSalesPerson")]
        [Route("ChangeSalesPerson")]
        public ActionResult ChangeSalesPerson(string[] CustomerEmail, string SalesPersonID)
        {
            try
            {
                var DB = new BG_DBEntities();
                string CurrentUserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
                if (CustomerEmail.Count() > 0)
                {
                    foreach (var i in CustomerEmail)
                    {
                        var Old = DB.AssignSalesPersonMsts.Where(x => x.CustomerID == i).ToList();
                        if (Old.Count() > 0)
                        {
                            Old.ForEach(x => x.Active = false);
                            DB.SaveChanges();
                        }
                        var obj = new AssignSalesPersonMst
                        {
                            Active = true,
                            CreatedDate = DateTime.Now,
                            CreatedBy = CurrentUserID,
                            SalesPersonID = SalesPersonID,
                            CustomerID = i
                        };
                        DB.AssignSalesPersonMsts.Add(obj);
                        DB.SaveChanges();
                    }
                }
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