using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BG_Application.CustomDTO;
using BG_Application.Service;
using BG_Application.ServiceContract;

namespace BG_API.Controllers
{
    [Authorize]
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private ICustomer_Repository _ICustomer_Repository;
        public CustomerController()
        {
            this._ICustomer_Repository = new Customer_Repository(new BG_Application.Data.BG_DBEntities());
        }

        #region get new customers
        [HttpGet]
        [Route("new")]
        public IHttpActionResult GetAllNewCutomer()
        {
            try
            {
                var users = _ICustomer_Repository.GetInActiveCustomers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region get register customers
        [HttpGet]
        [Route("register")]
        public IHttpActionResult GetAllRegisterCustomer()
        {
            try
            {
                var users = _ICustomer_Repository.GetRegisterCustomers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region get customer details
        [HttpGet]
        [Route("details/{UserId}")]
        public IHttpActionResult GetCustomerDetails(string UserId)
        {
            try
            {
                var users = _ICustomer_Repository.GetCustomerDetails(UserId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region customer deactivate
        [HttpGet]
        [Route("deactivate/{Email}/")]
        public IHttpActionResult DeactivateCustomer(string Email)
        {
            try
            {
                return Ok(_ICustomer_Repository.CustomerDeactivate(Email));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region customer activate
        [HttpGet]
        [Route("activate/{Email}")]
        public IHttpActionResult ActivateCustomer(string Email)
        {
            try
            {
                return Ok(_ICustomer_Repository.CustomerActivate(Email));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region new customer activate
        [HttpGet]
        [Route("new-customer-activate/{Email}")]
        public IHttpActionResult NewCustomerActivate(string Email)
        {
            try
            {
                return Ok(_ICustomer_Repository.NewCustomerActivate(Email));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
