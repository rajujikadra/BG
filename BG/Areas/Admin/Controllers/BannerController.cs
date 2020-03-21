using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    public class BannerController : Controller
    {
        // GET: Admin/Banner
        [Route("banner")]
        [AuthorizeEntryPermission(Permission = "Banner")]
        public ActionResult Index()
        {
            var DB = new BG_DBEntities();
            var model = DB.BannerMsts.Select(x => new BannerViewModel()
            {
                Active = x.Active,
                Title = x.Title,
                UploadDate = x.UploadDate,
                ImageName = x.ImageName,
                ImageID = x.ImageID
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBanner(BannerViewModel model)
        {
            try
            {
                var DB = new BG_DBEntities();
                model.ImageString = model.ImageString.Split(',')[1];  // remove data:image/png;base64,
                byte[] ImageFile = null;
                if (model.ImageString != null && !string.IsNullOrEmpty(model.ImageString))
                {
                    ImageFile = Convert.FromBase64String(model.ImageString);
                }
                if (ImageFile != null)
                {
                    string filePath = HttpContext.Server.MapPath(string.Format("~/Content/slider/" + model.ImageName + ""));
                    System.IO.File.WriteAllBytes(filePath, ImageFile);
                }

                var obj = new BannerMst
                {
                    Active = true,
                    ImageName = model.ImageName,
                    Title = model.Title,
                    UploadDate = DateTime.Now
                };
                DB.BannerMsts.Add(obj);
                DB.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #region active in-active banner
        [HttpGet]
        [Route("ActiveInactiveBanner")]
        public ActionResult ActiveInactiveBanner(int ImageID, bool Status)
        {
            try
            {
                var DB = new BG_DBEntities();
                var Image = DB.BannerMsts.FirstOrDefault(x => x.ImageID == ImageID);
                if (Image != null)
                {
                    Image.Active = Status ? true : false;
                    DB.SaveChanges();
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}