using BG.Helper;
using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    public class CounterController : Controller
    {
        // GET: Admin/Counter
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
            ViewBag.RoleList = Enum.GetValues(typeof(EnumTypes.RoleList)).Cast<EnumTypes.RoleList>().Select(x => new SelectListViewModel() { Text = x.ToString(), Value = x.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddCounters(CounterViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new DefaultResponse().SetErrorMessages(this).AsDefault(), JsonRequestBehavior.AllowGet);
            return null;
        }

        public ActionResult GetStates(int CountryId)
        {
            var DB = new BG_DBEntities();
            var State = DB.StateMsts.Where(x => x.CountryId == CountryId && x.Active == true).Select(y => new StateViewModel()
            {
                StateId = y.StateId,
                StateName = y.StateName
            }).OrderBy(c => c.StateName).ToList();
            return Json(State, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity(int StateId)
        {
            var DB = new BG_DBEntities();
            var City = DB.CityMsts.Where(x => x.StateId == StateId && x.Active == true).Select(y => new CityViewModel()
            {
                CityId = y.CityId,
                CityName = y.CityName
            }).OrderBy(c => c.CityName).ToList();
            return Json(City, JsonRequestBehavior.AllowGet);
        }
    }
}