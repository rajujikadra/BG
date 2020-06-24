using BG_Application.CustomDTO;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BG.Models;
using Microsoft.Ajax.Utilities;

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
            model.Fluorescence = DB.FlouMsts.Where(x => x.Active == true).Select(c => new Fluorescence()
            {
                FlouCode = c.FlouCode,
                FlouAliasName = c.FlouAliasName,
                FlouName = c.FlouName
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
            model.GridleInclusion = DB.OGirdleInclusionMsts.Where(x => x.Active == true).Select(c => new GridleInclusion()
            {
                Code = c.Code,
                AliasName = c.AliasName,
                Name = c.Name
            }).ToList();
            model.Size = DB.SizeMsts.Where(x => x.Active == true).Select(y => new Size()
            {
                SizeMstID = y.SizeMstID,
                FromSize = y.FromSize,
                ToSize = y.ToSize
            }).ToList();
            model.KetToSymbol = DB.DiamondStocks.Select(x => x.KeytoSymbol.Trim()).Distinct().ToList();
            model.Comments = DB.DiamondStocks.Select(x => x.Comments.Trim()).Distinct().ToList();
            model.EyeClean = DB.DiamondStocks.Select(x => x.EyeClean.Trim()).Distinct().ToList();
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
            #region Search by SHPAE
            if (model.Shape != null && model.Shape.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.ShapeCode != null && model.Shape.Contains((int)x.ShapeCode)).ToList());
            }
            #endregion
            #region Search by CARET
            if (model.CaretFrom != null && model.CaretTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Cts >= model.CaretFrom && x.Cts <= model.CaretTo).ToList());
            }
            #endregion
            #region Search by PRICE
            if (model.PriceFrom != null && model.PriceTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Rap >= model.PriceFrom && x.Rap <= model.PriceTo).ToList());
            }
            #endregion
            #region Search by RAP OFF
            if (model.RapOffFrom != null && model.RapOffTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Disc >= model.RapOffFrom && x.Disc <= model.RapOffTo).ToList());
            }
            #endregion
            #region Search by MULTISIZE
            if (model.MultiSize != null && model.MultiSize.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.SizeCode != null && model.MultiSize.Contains((int)x.SizeCode)).ToList());
            }
            #endregion
            #region Search by COLOR
            if (model.Color != null && model.Color.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.ColorCode != null && model.Color.Contains((int)x.ColorCode)).ToList());
            }
            #endregion
            #region Search by CLARITY
            if (model.Clarity != null && model.Clarity.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.PurityCode != null && model.Clarity.Contains((int)x.PurityCode)).ToList());
            }
            #endregion
            #region Search by CUT
            if (model.Cut != null && model.Cut.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.CutCode != null && model.Cut.Contains((int)x.CutCode)).ToList());
            }
            #endregion
            #region Search by POLISH
            if (model.Polish != null && model.Polish.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.PolishCode != null && model.Polish.Contains((int)x.PolishCode)).ToList());
            }
            #endregion
            #region Search by SYMMETRY
            if (model.Symmetry != null && model.Symmetry.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.SymmetryCode != null && model.Symmetry.Contains((int)x.SymmetryCode)).ToList());
            }
            #endregion
            #region Search by LAB
            if (model.Lab != null && model.Lab.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.CertificateCode != null && model.Lab.Contains((int)x.CertificateCode)).ToList());
            }
            #endregion
            #region Search by KEY TO SYMBOL
            if (model.KeyToSymbol != null && model.KeyToSymbol.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.KeyToSymbol.Contains(x.KeytoSymbol)).ToList());
            }
            #endregion
            #region Search by REPORT COMMENTS
            if (model.ReportComment != null && model.ReportComment.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => model.ReportComment.Contains(x.Comments)).ToList());
            }
            #endregion
            #region Search by COLOR SHADE
            if (model.ColorShade != null && model.ColorShade.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.FancyColorCode != null && model.ColorShade.Contains((int)x.FancyColorCode)).ToList());
            }
            #endregion
            #region Search by BGM 
            if (!string.IsNullOrEmpty(model.BGM))
            {
                Data.AddRange(Stock.Where(x => !string.IsNullOrEmpty(x.BGM) && x.BGM.Trim().ToLower().Contains(model.BGM.Trim().ToLower())).ToList());
            }
            #endregion
            #region Search by FLUORESCENCE
            if (model.Fluorescence != null && model.Fluorescence.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.FlouCode != null && model.Fluorescence.Contains((int)x.FlouCode)).ToList());
            }
            #endregion
            #region Search by HEARTS & ARROWS
            if (model.HA != null && model.HA.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.HA != null && model.HA.Contains((int)x.HA)).ToList());
            }
            #endregion
            #region Search by PARAMETERS
            // Search by DIAMETER
            if (!string.IsNullOrEmpty(model.DiameterFrom) && model.DiameterFrom != null)
            {
                Data.AddRange(Stock.Where(x => !string.IsNullOrEmpty(x.Diameter) && x.Diameter.Trim().ToLower().Contains(model.DiameterFrom.Trim().ToLower())).ToList());
            }
            // Search by RATIO
            if (model.RatioFrom != null && model.RatioTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Ratio >= model.RatioFrom && x.Ratio <= model.RatioTo).ToList());
            }
            // Search by TOTAL DEPTH
            if (model.DepthFrom != null && model.DepthTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Depth >= model.DepthFrom && x.Depth <= model.DepthTo).ToList());
            }
            // Search by TABLE
            if (model.TableFrom != null && model.TableTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Table >= model.TableFrom && x.Table <= model.TableTo).ToList());
            }
            // Search by LENGTH
            if (model.LengthFrom != null && model.LengthTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Length >= model.LengthFrom && x.Length <= model.LengthTo).ToList());
            }
            // Search by WIDTH
            if (model.WidthFrom != null && model.WidthTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Width >= model.WidthFrom && x.Width <= model.WidthTo).ToList());
            }
            // Search by GIRDLE
            if (model.FromGirdle != null && model.ToGirdle != null)
            {
                Data.AddRange(Stock.Where(x => x.Girdle >= model.FromGirdle && x.Girdle <= model.ToGirdle).ToList());
            }
            // Search by PAVILION ANGLE
            if (model.PavilionAngleFrom != null && model.PavilionAngleTo != null)
            {
                Data.AddRange(Stock.Where(x => x.PavAngle >= model.PavilionAngleFrom && x.PavAngle <= model.PavilionAngleTo).ToList());
            }
            // Search by PAVILION HEIGHT
            if (model.PavilionHeightFrom != null && model.PavilionHeightTo != null)
            {
                Data.AddRange(Stock.Where(x => x.PavHeight >= model.PavilionHeightFrom && x.PavHeight <= model.PavilionHeightTo).ToList());
            }
            // Search by CROWN ANGLE
            if (model.CrownAngleFrom != null && model.CrownAngleTo != null)
            {
                Data.AddRange(Stock.Where(x => x.CrownAngle >= model.CrownAngleFrom && x.CrownAngle <= model.CrownAngleTo).ToList());
            }
            // Search by CROWN HEIGHT
            if (model.CrownHeightFrom != null && model.CrownHeightTo != null)
            {
                Data.AddRange(Stock.Where(x => x.CrownHeight >= model.CrownHeightFrom && x.CrownHeight <= model.CrownHeightTo).ToList());
            }
            // Search by STAR LENGTH
            if (model.StarLengthFrom != null && model.StarLengthTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Star >= model.StarLengthFrom && x.Star <= model.StarLengthTo).ToList());
            }
            // Search by LOWER HALF
            if (model.LowerHalfFrom != null && model.LowerHalfTo != null)
            {
                Data.AddRange(Stock.Where(x => x.Lower >= model.LowerHalfFrom && x.Lower <= model.LowerHalfTo).ToList());
            }
            // Search by CULET
            if (model.FromCulet != null && model.ToCulet != null)
            {
                Data.AddRange(Stock.Where(x => x.Culet >= model.FromCulet && x.Culet <= model.ToCulet).ToList());
            }
            #endregion
            #region Search by EYE CLEAN
            if (model.EyeClean != null && model.EyeClean.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => !string.IsNullOrEmpty(x.EyeClean) && model.EyeClean.Contains(x.EyeClean)).ToList());
            }
            #endregion
            #region Search by SIDE WHITE INCLUSION
            if (model.SWhiteInclusion != null && model.SWhiteInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.SWhite != null && model.SWhiteInclusion.Contains((int)x.SWhite)).ToList());
            }
            #endregion
            #region Search by CENTER WHITE INCLUSION
            if (model.CWhiteInclusion != null && model.CWhiteInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.CWhite != null && model.CWhiteInclusion.Contains((int)x.CWhite)).ToList());
            }
            #endregion
            #region Search by SIDE BLACK INCLUSION
            if (model.SBlackInclusion != null && model.SBlackInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.SBlack != null && model.SBlackInclusion.Contains((int)x.SBlack)).ToList());
            }
            #endregion
            #region Search by CENTER BLACK INCLUSION
            if (model.CBlackInclusion != null && model.CBlackInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.CBlack != null && model.CBlackInclusion.Contains((int)x.CBlack)).ToList());
            }
            #endregion
            #region Search by TABLE INCLUSION
            if (model.TableInclusion != null && model.TableInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.TOInclusion != null && model.TableInclusion.Contains((int)x.TOInclusion)).ToList());
            }
            #endregion 
            #region Search by CROWN INCLUSION
            if (model.CrownInclusion != null && model.CrownInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.COInclusion != null && model.CrownInclusion.Contains((int)x.COInclusion)).ToList());
            }
            #endregion 
            #region Search by PAVILION INCLUSION
            if (model.PavilionInclusion != null && model.PavilionInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.POInclusion != null && model.PavilionInclusion.Contains((int)x.POInclusion)).ToList());
            }
            #endregion 
            #region Search by GIRDLE INCLUSION
            if (model.GridleInclusion != null && model.GridleInclusion.Count() > 0)
            {
                Data.AddRange(Stock.Where(x => x.GOInclusion != null && model.GridleInclusion.Contains((int)x.GOInclusion)).ToList());
            }
            #endregion
            #region Search by PACKET / CERTIFICATE NO. 
            if (!string.IsNullOrEmpty(model.Radio))
            {
                if (model.Radio.Trim().ToLower().Equals(@"Packet".Trim().ToLower()))
                {
                    if (model.SearchArea != null && model.SearchArea.Count() > 0)
                    {
                        Data.AddRange(Stock.Where(x => !string.IsNullOrEmpty(x.StoneID) && model.SearchArea.Contains(x.StoneID)).ToList());
                    }
                }
                else if (model.Radio.Trim().ToLower().Equals(@"Certificate".Trim().ToLower()))
                {
                    if (model.SearchArea != null && model.SearchArea.Count() > 0)
                    {
                        Data.AddRange(Stock.Where(x => !string.IsNullOrEmpty(x.ReportNo) && model.SearchArea.Contains(x.ReportNo)).ToList());
                    }
                }
            }
            Data = Data.DistinctBy(x => x.StoneID).ToList();
            if (Data.Count() > 500)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            #endregion
            return View();
        }

        #region Get All stocks
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
                CBlack = y.CBlack,
                SBlack = y.SBlack,
                CWhite = y.CWhite,
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
                FancyColorCode = y.FancyColorCode,
                BGM = y.BGM,
                Diameter = y.Diameter,
                Ratio = y.Ratio,
                Table = y.Table,
                TOInclusion = y.TOInclusion,
                COInclusion = y.COInclusion,
                POInclusion = y.POInclusion,
                GOInclusion = y.GOInclusion,
                CertificateName = DB.CertificateMsts.FirstOrDefault(c => c.CertificateCode == y.CertificateCode).CertificateName,
                ShapeName = DB.ShapeMsts.FirstOrDefault(c => c.ShapeCode == y.ShapeCode).ShapeAliasName,
                Size = DB.SizeMsts.FirstOrDefault(c => c.SizeMstID == y.SizeCode).SizeAlias,
                ColorName = DB.ColorMsts.FirstOrDefault(c => c.ColorCode == y.ColorCode).ColorAliasName,
                Cut = DB.CutMsts.FirstOrDefault(c => c.CutCode == y.CutCode).CutAliasName,
                Flou = DB.FlouMsts.FirstOrDefault(c => c.FlouCode == y.FlouCode).FlouAliasName,
                Polish = DB.PolishMsts.FirstOrDefault(c => c.PolishCode == y.PolishCode).PolishAliasName,
                Purity = DB.PurityMsts.FirstOrDefault(c => c.PurityCode == y.PurityCode).PurityAliasName,
                Symmetry = DB.SymmetryMsts.FirstOrDefault(c => c.SymmetryCode == y.SymmetryCode).SymmetryAliasName,
                FancyColorName = DB.FancyColorMsts.FirstOrDefault(c => c.FancyColorCode == y.FancyColorCode).FancyColorName
            }).ToList();
        }
        #endregion
        //[Route("stock")]
        //public ActionResult Stock()
        //{
        //    return View();
        //}

    }
}