using System;
using System.Collections.Generic;
using System.Dynamic;
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

        #region get broker stock
        [HttpGet]
        [Route("get-stock/{Email}")]
        public IHttpActionResult GetStocks(string Email)
        {
            try
            {
                var queryResult = _IBroker_Repository.GetStock();
                string userid = _IBroker_Repository.GetUserIdByEmail(Email);
                if (!string.IsNullOrEmpty(userid))
                {
                    List<string> Columns = _IBroker_Repository.GetBrokerColumnByUserId(userid);
                    var results = GetWhatClientWants(Columns, queryResult);
                    return Ok(results);
                }
                else
                {
                    return BadRequest("No stocks available right now.");
                }               
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        private Dictionary<string, Func<DiamondStockViewModel, object>> propertyReaders = new Dictionary<string, Func<DiamondStockViewModel, object>> {
            {"StoneID", x => x.StoneID },
            {"CTS", x => x.Cts },
            {"Location", x => x.Location},
            {"ReportNo", x => x.ReportNo },
            {"Certificate", x => x.CertificateName },
            {"Shape", x=>x.ShapeName },
            {"Size", x=>x.Size },
            {"Color", x=>x.ColorName},
            {"Purity", x=>x.Purity },
            {"Cut", x=>x.Cut },
            {"Polish", x=>x.Polish },
            {"Symmetry", x=>x.Symmetry },
            {"Flou", x=>x.Flou },
            {"RAP", x=>x.Rap},
            {"Discount", x=>x.Disc },
            {"Asking", x=>x.Asking },
            {"Amount", x=>x.Amount},
            {"SPer", x=>x.SPer },
            {"SRate", x=>x.SRate },
            {"SAmt", x=>x.SAmount },
            {"Length", x=>x.Length },
            {"Width", x=>x.Width },
            {"Depth", x=>x.Depth },
            {"DepthPer", x=>x.DepthPer },
            {"TablePer", x=>x.TablePer },
            {"CrownAngle", x=>x.CrownAngle },
            {"CrownHeight", x => x.CrownHeight },
            {"PavAngle", x=>x.PavAngle },
            {"PavHeight", x=>x.PavHeight },
            {"KeyToSymbol", x=>x.KeytoSymbol },
            {"EyeClean", x=>x.EyeClean },
            {"Girdle", x=>x.Girdle },
            {"Culet", x=>x.Culet },
            {"Star", x=>x.Star },
            {"Lower", x=>x.Lower },
            {"Milky", x=>x.Milky },
            {"HA", x=>x.HA },
            {"Inscription", x=>x.Inscription },
            {"Comment", x=>x.Comments }
        };
        public List<dynamic> GetWhatClientWants(List<string> propertyNames, List<DiamondStockViewModel> queryResult)
        {
            // make sure your queryResult is in-memory collection here. Body of this select cannot be executed in the database
            return queryResult.Select(t =>
            {
                var expando = new ExpandoObject();
                var expandoDict = expando as IDictionary<string, object>;

                foreach (var propertyName in propertyNames)
                {
                    expandoDict.Add(propertyName, propertyReaders[propertyName](t));
                }

                return (dynamic)expando;
            }).ToList();
        }
    }
}
