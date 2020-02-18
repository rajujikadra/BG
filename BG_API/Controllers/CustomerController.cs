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
        [Route("new-customers")]
        public IHttpActionResult GetAllColorMst()
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
    }
}
