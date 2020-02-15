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
    [RoutePrefix("api/master")]
    public class MasterController : ApiController
    {

        private IMaster_Repository _IMaster_Repository;
        public MasterController()
        {
            this._IMaster_Repository = new Master_Repository(new BG_Application.Data.BG_DBEntities());
        }

        #region Color Master
        [HttpGet]
        [Route("color-master")]
        public IHttpActionResult GetAllColorMst()
        {
            try
            {
                var colors = _IMaster_Repository.GetAllColorMaster();
                return Ok(colors);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Certificate Master
        [HttpGet]
        [Route("certificate-master")]
        public IHttpActionResult GetAllCertificateMst()
        {
            try
            {
                var Certificate = _IMaster_Repository.GetAllCertificateMaster();
                return Ok(Certificate);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Company Master
        [HttpGet]
        [Route("company-master")]
        public IHttpActionResult GetAllCompanyMst()
        {
            try
            {
                var Company = _IMaster_Repository.GetAllCompanyMaster();
                return Ok(Company);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Cut Master
        [HttpGet]
        [Route("cut_master")]
        public IHttpActionResult GetAllCutMst()
        {
            try
            {
                var Cut = _IMaster_Repository.GetAllCutMaster();
                return Ok(Cut);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Fancy Color Master
        [HttpGet]
        [Route("fancy-color-master")]
        public IHttpActionResult GetAllFancyColorMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllFancyColorMaster();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Fancy OT Master
        [HttpGet]
        [Route("fancy-ot-master")]
        public IHttpActionResult GetAllFancyOTMst()
        {
            try
            {
                var FOT = _IMaster_Repository.GetAllFancyOTMaster();
                return Ok(FOT);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Flou Master
        [HttpGet]
        [Route("flou-master")]
        public IHttpActionResult GetAllFlouMst()
        {
            try
            {
                var Flou = _IMaster_Repository.GetAllFlouMaster();
                return Ok(Flou);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region HA Master
        [HttpGet]
        [Route("ha-master")]
        public IHttpActionResult GetAllHAMst()
        {
            try
            {
                var HA = _IMaster_Repository.GetAllHAMaster();
                return Ok(HA);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Party Master
        [HttpGet]
        [Route("party-master")]
        public IHttpActionResult GetAllPartyMst()
        {
            try
            {
                var Party = _IMaster_Repository.GetAllPartyMaster();
                return Ok(Party);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Purity Master
        [HttpGet]
        [Route("purity-master")]
        public IHttpActionResult GetAllPurityMst()
        {
            try
            {
                var Purity = _IMaster_Repository.GetAllPurityMaster();
                return Ok(Purity);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Shap Master
        [HttpGet]
        [Route("shap-master")]
        public IHttpActionResult GetAllShapMst()
        {
            try
            {
                var Shap = _IMaster_Repository.GetAllShapMaster();
                return Ok(Shap);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Size Master
        [HttpGet]
        [Route("size-master")]
        public IHttpActionResult GetAllSizeMst()
        {
            try
            {
                var Size = _IMaster_Repository.GetAllSizeMaster();
                return Ok(Size);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region Type Master
        [HttpGet]
        [Route("type-master")]
        public IHttpActionResult GetAllTypeMst()
        {
            try
            {
                var Type = _IMaster_Repository.GetAllTypeMaster();
                return Ok(Type);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
