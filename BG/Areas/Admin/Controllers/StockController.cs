using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;


namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    [RoutePrefix("stock")]
    public class StockController : Controller
    {
        // GET: Admin/Stock
        [Route]
        public ActionResult Index()
        {
            var DB = new BG_DBEntities();
            var queryResult = DB.DiamondStocks.Select(y => new DiamondStockViewModel()
            {
                StockMSTID = y.StockMSTID,
                StoneID = y.StoneID,
                Cts = y.Cts,
                Location = y.Location,
                ReportNo = y.ReportNo,
                CertificateCode = y.CertificateCode,
                ShapeCode = y.ShapeCode,
                SizeCode = y.SizeCode,
                ColorCode = y.ColorCode,
                PurityCode = y.PurityCode,
                CutCode = y.CutCode,
                PolishCode = y.PolishCode,
                SymmetryCode = y.SymmetryCode,
                FlouCode = y.FlouCode,
                Rap = y.Rap,
                Disc = y.Disc,
                Asking = y.Asking,
                Amount = y.Amount,
                SPer = y.SPer,
                SRate = y.SRate,
                SAmount = y.SAmount,
                Length = y.Length,
                Width = y.Width,
                Depth = y.Depth,
                DepthPer = y.DepthPer,
                TablePer = y.TablePer,
                CrownAngle = y.CrownAngle,
                CrownHeight = y.CrownHeight,
                PavAngle = y.PavAngle,
                PavHeight = y.PavHeight,
                KeytoSymbol = y.KeytoSymbol,
                VideoLink = y.VideoLink,
                EyeClean = y.EyeClean,
                Comments = y.Comments,
                Girdle = y.Girdle,
                Culet = y.Culet,
                Star = y.Star,
                Lower = y.Lower,
                Milky = y.Milky,
                TBlack = y.TBlack,
                SBlack = y.SBlack,
                TWhite = y.TWhite,
                SWhite = y.SWhite,
                HA = y.HA,
                ResultVerify = y.ResultVerify,
                ReportDate = y.ReportDate,
                Inscription = y.Inscription,
                Sale = y.Sale,
                Broker = y.Broker,
                Hold = y.Hold,
                Basket = y.Basket,
                Inquiry = y.Inquiry,
                CertificateName = DB.CertificateMsts.FirstOrDefault(c => c.CertificateCode == y.CertificateCode).CertificateName,
                ShapeName = DB.ShapeMsts.FirstOrDefault(c => c.ShapeCode == y.ShapeCode).ShapeAliasName,
                Size = DB.SizeMsts.FirstOrDefault(c => c.SizeMstID == y.SizeCode).SizeAlias,
                ColorName = DB.ColorMsts.FirstOrDefault(c => c.ColorCode == y.ColorCode).ColorAliasName,
                Cut = DB.CutMsts.FirstOrDefault(c => c.CutCode == y.CutCode).CutAliasName,
                Flou = DB.FlouMsts.FirstOrDefault(c => c.FlouCode == y.FlouCode).FlouAliasName,
                Polish = DB.PolishMsts.FirstOrDefault(c => c.PolishCode == y.PolishCode).PolishAliasName,
                Purity = DB.PurityMsts.FirstOrDefault(c => c.PurityCode == y.PurityCode).PurityAliasName,
                Symmetry = DB.SymmetryMsts.FirstOrDefault(c => c.SymmetryCode == y.SymmetryCode).SymmetryAliasName
            }).ToList();
            string userid = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
            List<string> Columns = DB.BrokerColumnMappingMsts.Where(x => x.UserId == userid).Select(y => y.BrokerColumnName.ColumnName).ToList();
            var results = GetWhatClientWants(Columns, queryResult);
            var model = new List<DiamondStockViewModel>();

            using (var httpClient = ApiHelper.GetHttpClient())
            {
                var result = httpClient.GetAsync(Config.get_stock).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<List<DiamondStockViewModel>>(resultContent);
                }
            }
            return View(model);
        }
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
            {"Inscription", x=>x.Inscription   }

            //{"StockMSTID", x =>x.StockMSTID },
            //{"StoneID", x => x.StoneID },
            //{"CTS", x => x.Cts },
            //{"Location", x => x.Location },
            //{"ReportNo", x => x.ReportNo },
            //{"CertificateCode", x => x.CertificateCode },
            //{"ShapeCode", x => x.ShapeCode },
            //{"SizeCode", x => x.SizeCode },
            //{"ColorCode", x => x.ColorCode },
            //{"PurityCode", x => x.PurityCode },
            //{"CutCode", x => x.CutCode },
            //{"PolishCode", x => x.PolishCode },
            //{"SymmetryCode", x => x.SymmetryCode },
            //{"FlouCode", x => x.FlouCode },
            //{"Rap", x => x.Rap },
            //{"Disc", x => x.Disc },
            //{"Asking", x => x.Asking },
            //{"Amount", x => x.Amount },
            //{"SPer", x => x.SPer },
            //{"SRate", x => x.SRate },
            //{"SAmount", x => x.SAmount },
            //{"Length", x => x.Length },
            //{"Width", x => x.Width },
            //{"Depth", x => x.Depth },
            //{"DepthPer", x => x.DepthPer },
            //{"TablePer", x => x.TablePer },
            //{"CrownAngle", x => x.CrownAngle },
            //{"CrownHeight", x => x.CrownHeight },
            //{"PavAngle", x => x.PavAngle },
            //{"PavHeight", x => x.PavHeight },
            //{"KeytoSymbol", x => x.KeytoSymbol },
            //{"VideoLink", x => x.VideoLink },
            //{"EyeClean", x => x.EyeClean },
            //{"Comments", x => x.Comments },
            //{"Girdle", x => x.Girdle },
            //{"Culet", x => x.Culet },
            //{"Star", x => x.Star },
            //{"Lower", x => x.Lower },
            //{"Milky", x => x.Milky },
            //{"TBlack", x => x.TBlack },
            //{"SBlack", x => x.SBlack },
            //{"TWhite", x => x.TWhite },
            //{"SWhite", x => x.SWhite },
            //{"HA", x => x.HA },
            //{"ResultVerify", x => x.ResultVerify },
            //{"ReportDate", x => x.ReportDate },
            //{"Inscription", x => x.Inscription },
            //{"Sale", x => x.Sale },
            //{"Broker", x => x.Broker },
            //{"Hold", x => x.Hold },
            //{"Basket", x => x.Basket },
            //{"Inquiry", x => x.Inquiry },
            //{"CertificateName", x => x.CertificateName },
            //{"ShapeName", x => x.ShapeName },
            //{"Size", x => x.Size },
            //{"ColorName", x => x.ColorName },
            //{"Cut", x => x.Cut },
            //{"Flou", x => x.Flou },
            //{"Polish", x => x.Polish },
            //{"Purity", x => x.Purity },
            //{"Symmetry", x => x.Symmetry }
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