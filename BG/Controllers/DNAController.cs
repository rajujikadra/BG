using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BG.Controllers
{
    [Authorize]
    public class DNAController : Controller
    {
        // GET: DNA
        [Route("dna-report/{StoneID}")]
        public ActionResult Index(string StoneID)
        {
            return View();
        }
    }
}