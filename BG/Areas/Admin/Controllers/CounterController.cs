using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Areas.Admin.Controllers
{
    public class CounterController : Controller
    {
        // GET: Admin/Counter
        public ActionResult Index()
        {
            return View();
        }
    }
}