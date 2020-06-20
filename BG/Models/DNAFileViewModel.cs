using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BG.Models
{
    public class DNAFileViewModel
    {
        [Required(ErrorMessage = "Please enter stone ID")]
        [Display(Name = "Stone ID")]
        public string StoneID { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Upload H&A Images")]
        public HttpPostedFileBase[] Images { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Upload V360 File")]
        public HttpPostedFileBase[] JSONFile { get; set; }

        //[Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Upload Certy")]
        public HttpPostedFileBase[] PDFFile { get; set; }
    }
}