using BG.Models;
using BG_Application.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
            var DB = new BG_DBEntities();
            var Stone = DB.DiamondStocks.Where(x => x.StoneID.Trim().ToLower().Equals(StoneID.Trim().ToLower())).Select(y => new DNADisplayViewModel()
            {
                StoneID = y.StoneID,
                CaratWeight = y.Cts.ToString(),
                Clarity = DB.PurityMsts.FirstOrDefault(b => b.PurityCode == y.PurityCode).PurityName,
                PurityCode = y.PurityCode,
                Color = DB.ColorMsts.FirstOrDefault(b => b.ColorCode == y.ColorCode).ColorName,
                ColorCode = y.ColorCode,
                Cut = DB.CutMsts.FirstOrDefault(b => b.CutCode == y.CutCode).CutName,
                CutCode = y.CutCode,
                Shape = DB.ShapeMsts.FirstOrDefault(b => b.ShapeCode == y.ShapeCode).ShapeName,
                ShapeCode = y.ShapeCode
            }).FirstOrDefault();

            if (Stone != null)
            {
                Stone.RelatedStone = DB.DiamondStocks.Where(x => x.PurityCode == Stone.PurityCode && x.ColorCode == Stone.ColorCode && x.CutCode == Stone.CutCode && x.ShapeCode == Stone.ShapeCode).Select(y => new RelatedStone()
                {
                    StoneID = y.StoneID,
                    CaratWeight = y.Cts.ToString(),
                    Clarity = DB.PurityMsts.FirstOrDefault(b => b.PurityCode == y.PurityCode).PurityName,
                    PurityCode = y.PurityCode,
                    Color = DB.ColorMsts.FirstOrDefault(b => b.ColorCode == y.ColorCode).ColorName,
                    ColorCode = y.ColorCode,
                    Cut = DB.CutMsts.FirstOrDefault(b => b.CutCode == y.CutCode).CutName,
                    CutCode = y.CutCode,
                    Shape = DB.ShapeMsts.FirstOrDefault(b => b.ShapeCode == y.ShapeCode).ShapeName,
                    ShapeCode = y.ShapeCode
                }).ToList();
            }
            FileInfo pdfFiles = GetFiles(Server.MapPath(@"~/DNAReports/" + StoneID), "pdf").ToList().FirstOrDefault();
            if (pdfFiles != null)
                Stone.PDFFileName = pdfFiles.Name;
            List<FileInfo> JPG_images = GetFiles(Server.MapPath(@"~/DNAReports/" + StoneID), "jpg").ToList();
            List<FileInfo> PNG_images = GetFiles(Server.MapPath(@"~/DNAReports/" + StoneID), "png").ToList();
            List<FileInfo> JPEG_images = GetFiles(Server.MapPath(@"~/DNAReports/" + StoneID), "jpeg").ToList();
            Stone.ImageNames = new List<string>();
            if (JPG_images.Count() > 0 && JPG_images != null)
                Stone.ImageNames = JPG_images.Select(c => c.Name).ToList();
            if (PNG_images.Count() > 0 && PNG_images != null)
                Stone.ImageNames.AddRange(PNG_images.Select(c => c.Name).ToList());
            if (JPEG_images.Count() > 0 && JPEG_images != null)
                Stone.ImageNames.AddRange(JPEG_images.Select(c => c.Name).ToList());
            List<FileInfo> JSON_FIle = GetFiles(Server.MapPath(@"~/DNAReports/" + StoneID), "json").ToList();
            Stone.JSONString = new List<string>();
            if (JSON_FIle.Count() > 0 && JSON_FIle != null)
            {
                foreach (var i in JSON_FIle)
                {
                    Stone.JSONString.Add(System.IO.File.ReadAllText(Server.MapPath(@"~/DNAReports/" + StoneID) + "/" + i.Name));
                }
            }

            return View(Stone);
        }
        public static IEnumerable<FileInfo> GetFiles(string path, string extension)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                string search = string.Format("*.{0}", extension);
                FileInfo[] files = di.GetFiles(search);
                foreach (FileInfo fi in files)
                {
                    yield return fi;
                }
            }
        }
    }
}





