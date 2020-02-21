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
    [RoutePrefix("api/broker")]
    public class BrokerController : ApiController
    {
        private IBroker_Repository _IBroker_Repository;
        public BrokerController()
        {
            this._IBroker_Repository = new Broker_Repository(new BG_Application.Data.BG_DBEntities());
        }

        #region get new customers
        [HttpGet]
        [Route]
        public IHttpActionResult GetAllBrokers()
        {
            try
            {
                var Brokers = _IBroker_Repository.GetBrokerList();
                return Ok(Brokers);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
