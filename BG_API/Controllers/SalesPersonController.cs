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
    [RoutePrefix("api/sales-person")]
    public class SalesPersonController : ApiController
    {
        private ISalesPerson_Repository _ISalesPerson_Repository;
        public SalesPersonController()
        {
            this._ISalesPerson_Repository = new SalesPerson_Repository(new BG_Application.Data.BG_DBEntities());
        }

        #region get sales person
        [HttpGet]
        [Route]
        public IHttpActionResult GetAllSalesPersons()
        {
            try
            {
                var users = _ISalesPerson_Repository.GetSalesPersons();
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
