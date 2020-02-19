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
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private IDashboard_Repository _IDashboard_Repository;
        public DashboardController()
        {
            this._IDashboard_Repository = new Dashboard_Repository(new BG_Application.Data.BG_DBEntities());
        }

        #region get new customers
        [HttpGet]
        [Route]
        public IHttpActionResult AdminDashboard()
        {
            try
            {
                var model = _IDashboard_Repository.GetAdminDashboard();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
