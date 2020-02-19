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
        [Route("customers/{active}")]
        public IHttpActionResult GetAllColorMst(string active)
        {
            try
            {
                var users = _ICustomer_Repository.GetInActiveCustomers(active == EnumTypes.CustomerType.New.ToString().ToLower() ? false : true);
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
    }
}
