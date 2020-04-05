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
            return View();
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