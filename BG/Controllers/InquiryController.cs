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
            return View();
        }
    }
}