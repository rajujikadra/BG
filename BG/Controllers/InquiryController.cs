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
    public class InquiryController : Controller
    {
        // GET: Inquiry
        public ActionResult Index()
        {
            var DB = new BG_DBEntities();
            ViewBag.Country = DB.CountryMsts.Where(v => v.Active == true).Select(x => new CountryViewModel()
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName
            }).OrderBy(c => c.CountryName).ToList();
            ViewBag.State = new List<SelectListItem>();
            ViewBag.City = new List<SelectListItem>();
            return View();
        }

        [HttpPost]
        public ActionResult Index(InquiryViewModel model)
        {
            var DB = new BG_DBEntities();
            string UserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;            
            var obj = new InquiryMst
            {
                InquiryName = model.InquiryName,
                Type = model.Type,
                CompanyName = model.CompanyName,
                CompanyAddress = model.CompanyAddress,
                Comments = model.Comments,
                CountryId = model.CountryId,
                StateId = model.StateId,
                CityId = model.CityId,
                UserId = UserID,
                IsResolve = false
            };
            DB.InquiryMsts.Add(obj);
            DB.SaveChanges();
            return Json(obj.InquiryId > 0 ? true : false, JsonRequestBehavior.AllowGet);
        }
    }
}