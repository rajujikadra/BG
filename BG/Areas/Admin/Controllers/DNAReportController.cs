using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]
    [RoutePrefix("DNA-Report")]
    public class DNAReportController : Controller
    {
        // GET: Admin/DNAReport
        [Route]
        [AuthorizeEntryPermission(Permission = "DNAReport")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DNAUpload(string StoneID, HttpPostedFileBase[] Images, HttpPostedFileBase[] JSONFile, HttpPostedFileBase[] PDFFile)
        {
            if (ModelState.IsValid)
            {
                //DNAReports
                string path = Server.MapPath(@"~/DNAReports");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(path))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(path);
                }
                string reportPath = Server.MapPath(@"~/DNAReports/" + StoneID);
                if (!Directory.Exists(reportPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(reportPath);
                }
                if (Images.Count() > 0)
                {
                    foreach (HttpPostedFileBase file in Images)
                    {
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerSavePath = Path.Combine(reportPath + "/" + InputFileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                        }
                    }
                }
                if (PDFFile.Count() > 0)
                {
                    foreach (HttpPostedFileBase file in PDFFile)
                    {
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerSavePath = Path.Combine(reportPath + "/" + InputFileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                        }
                    }
                }
                if (JSONFile.Count() > 0)
                {
                    foreach (HttpPostedFileBase file in JSONFile)
                    {
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerSavePath = Path.Combine(reportPath + "\\" + InputFileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}








