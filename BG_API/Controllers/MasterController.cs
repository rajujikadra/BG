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

        [HttpPost]
        [Route("save-color-master")]
        public IHttpActionResult AddEditColorMaster(ColorViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsColorExist(model.ColorName, model.ColorCode))
                {
                    bool status = _IMaster_Repository.InsertColorMaster(model);
                    if (status)
                        return Ok(model.ColorCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.ColorName + " color is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }

        [HttpDelete]
        [Route("delete-color-master/{ID}")]
        public IHttpActionResult DeleteColorMaster(int ID)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteColorMaster(ID);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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

        [HttpPost]
        [Route("save-certificate-master")]
        public IHttpActionResult AddEditCertificateMaster(CertificateViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsCertificateExist(model.CertificateName, model.CertificateCode))
                {
                    bool status = _IMaster_Repository.InsertCertificateMaster(model);
                    if (status)
                        return Ok(model.CertificateCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.CertificateName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-certificate-master/{CertificateCode}")]
        public IHttpActionResult DeleteCertificateMaster(int CertificateCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteCertificate(CertificateCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [Route("cut-master")]
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

        [HttpPost]
        [Route("save-cut-master")]
        public IHttpActionResult AddEditCutMaster(CutViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsCutExist(model.CutName, model.CutCode))
                {
                    bool status = _IMaster_Repository.InsertCutMaster(model);
                    if (status)
                        return Ok(model.CutCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.CutName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-cut-master/{CutCode}")]
        public IHttpActionResult DeleteCutMaster(int CutCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteCut(CutCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-fancy-color-master")]
        public IHttpActionResult AddEditFancyColorMaster(FancyColorViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsFancyColorExist(model.FancyColorName, model.FancyColorCode))
                {
                    bool status = _IMaster_Repository.InsertFancyColorMaster(model);
                    if (status)
                        return Ok(model.FancyColorCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.FancyColorName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-fancy-color-master/{FancyColorCode}")]
        public IHttpActionResult DeleteFancyColorMaster(int FancyColorCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteFancyColor(FancyColorCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-fancy-ot-master")]
        public IHttpActionResult AddEditFancyOTMaster(FancyOTViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsFancyOTExist(model.FancyOTName, model.FancyOTCode))
                {
                    bool status = _IMaster_Repository.InsertFancyOTMaster(model);
                    if (status)
                        return Ok(model.FancyOTCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.FancyOTName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-fancy-ot-master/{FancyOTCode}")]
        public IHttpActionResult DeleteFancyOTMaster(int FancyOTCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteFancyOT(FancyOTCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-flou-master")]
        public IHttpActionResult AddEditFlouMst(FlouViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsFlouExist(model.FlouName, model.FlouCode))
                {
                    bool status = _IMaster_Repository.InsertFlouMaster(model);
                    if (status)
                        return Ok(model.FlouCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.FlouName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-flou-master/{FlouCode}")]
        public IHttpActionResult DeleteFlouMaster(int FlouCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteFlou(FlouCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-ha-master")]
        public IHttpActionResult AddEditHAMaster(HAViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsHAExis(model.HAName, model.HACode))
                {
                    bool status = _IMaster_Repository.InsertHAMaster(model);
                    if (status)
                        return Ok(model.HACode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.HAName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-ha-master/{HACode}")]
        public IHttpActionResult DeleteHAMaster(int HACode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteHA(HACode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-party-master")]
        public IHttpActionResult AddEditPartyMaster(PartyViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsPartyExist(model.PartyCode, model.PartyName, model.MobNo1, model.MobNo2))
                {
                    bool status = _IMaster_Repository.InsertPartyMaster(model);
                    if (status)
                        return Ok(model.PartyCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.PartyName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-party-master/{PartyCode}")]
        public IHttpActionResult DeletePartyMaster(int PartyCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteParty(PartyCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-purity-master")]
        public IHttpActionResult AddEditPurityMaster(PurityViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsPurityExist(model.PurityName, model.PurityCode))
                {
                    bool status = _IMaster_Repository.InsertPurityMaster(model);
                    if (status)
                        return Ok(model.PurityCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.PurityName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-purity-master/{PurityCode}")]
        public IHttpActionResult DeletePurityMaster(int PurityCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeletePurity(PurityCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-shap-master")]
        public IHttpActionResult AddEditShapMaster(ShapViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsShapExist(model.ShapeName, model.ShapeCode))
                {
                    bool status = _IMaster_Repository.InsertShapMaster(model);
                    if (status)
                        return Ok(model.ShapeCode != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.ShapeName + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-shap-master/{PartyCode}")]
        public IHttpActionResult DeleteShapMaster(int ShapeCode)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteShap(ShapeCode);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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
        [HttpPost]
        [Route("save-size-master")]
        public IHttpActionResult AddEditSizeMaster(SizeViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsSizeExist(model.SizeMstID, (decimal)model.FromSize, (decimal)model.ToSize))
                {
                    bool status = _IMaster_Repository.InsertSizeMaster(model);
                    if (status)
                        return Ok(model.SizeMstID != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.FromSize + "-" + model.ToSize + " certificate is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-size-master/{SizeMstID}")]
        public IHttpActionResult DeleteSizeMaster(int SizeMstID)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteSize(SizeMstID);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region stock-master
        [HttpGet]
        [Route("stock-master")]
        public IHttpActionResult GetAllStock()
        {
            try
            {
                var Stock = _IMaster_Repository.GetAllStock();
                return Ok(Stock);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-stock-master")]
        public IHttpActionResult AddEditStockMaster(DiamondStockViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsStockExist(model.StockMSTID, model.StoneID))
                {
                    bool status = _IMaster_Repository.InsertStockMaster(model);
                    if (status)
                        return Ok(model.StockMSTID != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.StoneID + " diamond stock is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }

        [HttpDelete]
        [Route("delete-stock-master/{StonID}")]
        public IHttpActionResult DeleteStockMaster(int StonID)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteStock(StonID);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
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

        #region SBlack Inclusion
        [HttpGet]
        [Route("side-black-inclusion")]
        public IHttpActionResult GetAllSBlackInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllSideBlackInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-side-black-inclusion-master")]
        public IHttpActionResult AddEditSBlackMaster(SBlackInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsSBlackInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertSBlackInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-side-black-inclusion-master/{Code}")]
        public IHttpActionResult DeleteSBlackMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteSBlackInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region SWhite Inclusion
        [HttpGet]
        [Route("side-white-inclusion")]
        public IHttpActionResult GetAllSWhiteInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllSideWhiteInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-side-white-inclusion-master")]
        public IHttpActionResult AddEditSWhiteMaster(SWhiteInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsSWhiteInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertSWhiteInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-side-white-inclusion-master/{Code}")]
        public IHttpActionResult DeleteSWhiteMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteSWhiteInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region CBlack Inclusion
        [HttpGet]
        [Route("center-black-inclusion")]
        public IHttpActionResult GetAllCBlackInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllCenterBlackInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-center-black-inclusion-master")]
        public IHttpActionResult AddEditCBlackMaster(CBlackInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsCBlackInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertCBlackInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-center-black-inclusion-master/{Code}")]
        public IHttpActionResult DeleteCBlackMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteCBlackInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region CWhite Inclusion
        [HttpGet]
        [Route("center-white-inclusion")]
        public IHttpActionResult GetAllCWhiteInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllCenterWhiteInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-center-white-inclusion-master")]
        public IHttpActionResult AddEditCWhiteMaster(CWhiteInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsCWhiteInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertCWhiteInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-center-white-inclusion-master/{Code}")]
        public IHttpActionResult DeleteCWhiteMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteCWhiteInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region OTable Inclusion
        [HttpGet]
        [Route("open-table-inclusion")]
        public IHttpActionResult GetAllOtableInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllOpenTableInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-opem-table-inclusion-master")]
        public IHttpActionResult AddEditOtableMaster(OTableInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsOTableInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertOTableInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-open-table-inclusion-master/{Code}")]
        public IHttpActionResult DeleteOtablMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteOTableInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region OCrown Inclusion
        [HttpGet]
        [Route("open-crown-inclusion")]
        public IHttpActionResult GetAllOCrownInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllOpenCrownInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-opem-crown-inclusion-master")]
        public IHttpActionResult AddEditOCrownMaster(OCrownInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsOCrownInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertOCrownInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-open-crown-inclusion-master/{Code}")]
        public IHttpActionResult DeleteOCrownMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteOCrownInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion

        #region OCrown Inclusion
        [HttpGet]
        [Route("open-pavilion-inclusion")]
        public IHttpActionResult GetAllOPavilionInclusionMst()
        {
            try
            {
                var FColor = _IMaster_Repository.GetAllOpenPavilionInclusion();
                return Ok(FColor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("save-opem-pavilion-inclusion-master")]
        public IHttpActionResult AddEditOPavilionMaster(OPavilionInclusionViewModel model)
        {
            try
            {
                if (!_IMaster_Repository.IsOPavilionInclusionExist(model.Name, model.Code))
                {
                    bool status = _IMaster_Repository.InsertOPavilionInclusionMaster(model);
                    if (status)
                        return Ok(model.Code != 0 ? "Successfully updated" : "Successfully added");
                    else
                        return BadRequest("Opps! Something problem in your data");
                }
                else
                {
                    return BadRequest(model.Name + " is already exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        [HttpDelete]
        [Route("delete-open-pavilion-inclusion-master/{Code}")]
        public IHttpActionResult DeleteOPavilionMaster(int Code)
        {
            try
            {
                bool status = _IMaster_Repository.DeleteOPavilionInclusion(Code);
                if (status)
                    return Ok("Successfully deleted");
                else
                    return BadRequest("Opps! Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest("Opps! Something went wrong");
            }
        }
        #endregion
    }
}
