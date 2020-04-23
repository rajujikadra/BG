using BG_Application.CustomDTO;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            model.Hearts_Arrows = DB.HAMsts.Where(x => x.Active == true).Select(c => new HA
            { 
                HAAliasName = c.HAAliasName,
                HACode = c.HACode,
                HAName = c.HAName
            }).ToList();
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
    }
}