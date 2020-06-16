using BG_Application.CustomDTO;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BG.Models;

namespace BG.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!CurrentUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var DB = new BG_DBEntities();
            var model = new HomeViewModel();
            model.Shape = DB.ShapeMsts.Where(x => x.Active == true).Select(c => new Shape()
            {
                ShapeCode = c.ShapeCode,
                ShapeName = c.ShapeName,
                ShapeAliasName = c.ShapeAliasName
            }).ToList();
            model.Color = DB.ColorMsts.Where(x => x.Active == true).Select(c => new Color()
            {
                ColorCode = c.ColorCode,
                ColorName = c.ColorName,
                ColorAliasName = c.ColorAliasName
            }).ToList();
            model.FancyColor = DB.FancyColorMsts.Where(x => x.Active == true).Select(c => new FancyColor()
            {
                FancyColorCode = c.FancyColorCode,
                FancyColorName = c.FancyColorName
            }).ToList();
            model.Lab = DB.CertificateMsts.Where(x => x.Active == true).Select(c => new Certificate()
            {
                CertificateCode = c.CertificateCode,
                CertiificateName = c.CertificateName
            }).ToList();
            model.Clarity = DB.PurityMsts.Where(x => x.Active == true).Select(c => new Purity()
            {
                PurityAliasName = c.PurityAliasName,
                PurityCode = c.PurityCode,
                PurityName = c.PurityName
            }).ToList();
            model.Cut = DB.CutMsts.Where(x => x.Active == true).Select(c => new Cut()
            {
                CutCode = c.CutCode,
                CutAliasName = c.CutAliasName,
                CutName = c.CutName
            }).ToList();
            model.Polish = DB.PolishMsts.Where(x => x.Active == true).Select(c => new Polish()
            {
                PolishCode = c.PolishCode,
                PolishAliasName = c.PolishAliasName,
                PolishName = c.PolishName
            }).ToList();
            model.Symmetry = DB.SymmetryMsts.Where(x => x.Active == true).Select(c => new Symmetry()
            {
                SymmetryCode = c.SymmetryCode,
                SymmetryAliasName = c.SymmetryAliasName,
                SymmetryName = c.SymmetryName
            }).ToList();
            model.Hearts_Arrows = DB.HAMsts.Where(x => x.Active == true).Select(c => new HA()
            {
                HAAliasName = c.HAAliasName,
                HACode = c.HACode,
                HAName = c.HAName
            }).ToList();
            model.SBlack = DB.SBlackInclusionMsts.Where(x => x.Active == true).Select(c => new SBlackInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.SWhite = DB.SWhiteInclusionMsts.Where(x => x.Active == true).Select(c => new SWhiteInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.CBlack = DB.CBlackInclusionMsts.Where(x => x.Active == true).Select(c => new CBlackInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.CWhite = DB.CWhiteInclusionMsts.Where(x => x.Active == true).Select(c => new CWhiteInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.TableInclusion = DB.OTableInclusionMsts.Where(x => x.Active == true).Select(c => new TableInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.CrownInclusion = DB.OCrownInclusionMsts.Where(x => x.Active == true).Select(c => new CrownInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.PavilionInclusion = DB.OPavilionInclusionMsts.Where(x => x.Active == true).Select(c => new PavilionInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.KetToSymbol = DB.DiamondStocks.Select(x => x.KeytoSymbol.Trim()).Distinct().ToList();
            model.Comments = DB.DiamondStocks.Select(x => x.Comments.Trim()).Distinct().ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Stock(SearchStockViewModel model)
        {
            var Data = new List<DiamondStockViewModel>();
            var Stock = GetStocks();
            if (model.Shape != null && model.Shape.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Shape.Contains((int)x.ShapeCode)).ToList());
            }
            if (model.CaretFrom != null && model.CaretTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Cts >= model.CaretFrom && x.Cts <= model.CaretTo).ToList());
            }
            if (model.PriceFrom != null && model.PriceTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Rap >= model.PriceFrom && x.Rap <= model.PriceTo).ToList());
            }
            if (model.RapOffFrom != null && model.RapOffTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Disc >= model.RapOffFrom && x.Disc <= model.RapOffTo).ToList());
            }
            if (model.Color != null && model.Color.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Color.Contains((int)x.ColorCode)).ToList());
            }
            if (model.Clarity != null && model.Clarity.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Clarity.Contains((int)x.PurityCode)).ToList());
            }
            if (model.Cut != null && model.Cut.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Cut.Contains((int)x.CutCode)).ToList());
            }
            if (model.Polish != null && model.Polish.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Polish.Contains((int)x.PolishCode)).ToList());
            }
            if (model.Symmetry != null && model.Symmetry.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Symmetry.Contains((int)x.SymmetryCode)).ToList());
            }
            if (model.Lab != null && model.Lab.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.Lab.Contains((int)x.CertificateCode)).ToList());
            }
            if (model.KeyToSymbol != null && model.KeyToSymbol.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.KeyToSymbol.Contains(x.KeytoSymbol)).ToList());
            }
            if (model.ReportComment != null && model.ReportComment.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.ReportComment.Contains(x.Comments)).ToList());
            }

            return View();
        }

        protected List<DiamondStockViewModel> GetStocks()
        {
            var DB = new BG_DBEntities();
            return DB.DiamondStocks.Where(x => x.Sale != true).Select(y => new DiamondStockViewModel()
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
        }
        //[Route("stock")]
        //public ActionResult Stock()
        //{
        //    return View();
        //}

    }
}