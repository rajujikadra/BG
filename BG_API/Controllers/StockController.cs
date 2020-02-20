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
    [RoutePrefix("api/stock")]
    public class StockController : ApiController
    {
        private IStock_Repository _IStock_Repository;
        public StockController()
        {
            this._IStock_Repository = new Stock_Repository(new BG_Application.Data.BG_DBEntities());
        }

        #region stocks
        [HttpGet]
        [Route]
        public IHttpActionResult GetAllStock()
        {
            try
            {
                var stocks = _IStock_Repository.GetStock();
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
