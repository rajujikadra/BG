using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BG.Controllers
{
    [ValidateInput(true)]
    public class BaseController : Controller
    {
        public ClaimsPrincipal CurrentUser => User as ClaimsPrincipal;
        //// GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}