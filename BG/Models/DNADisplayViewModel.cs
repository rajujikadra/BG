using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BG.Models
{
    public class DNADisplayViewModel
    {
        public string StoneID { get; set; }
        public string CaratWeight { get; set; }
        public string Color { get; set; }
        public int? ColorCode { get; set; }
        public string Shape { get; set; }
        public int? ShapeCode { get; set; }
        public string Clarity { get; set; }
        public int? PurityCode { get; set; }
        public string Cut { get; set; }
        public int? CutCode { get; set; }
        public List<string> JSONString { get; set; }
        public List<string> ImageNames { get; set; }
        public string PDFFileName { get; set; }
        public List<RelatedStone> RelatedStone { get; set; }
    }

    public class RelatedStone
    {
        public string StoneID { get; set; }
        public string CaratWeight { get; set; }
        public string Color { get; set; }
        public int? ColorCode { get; set; }
        public string Shape { get; set; }
        public int? ShapeCode { get; set; }
        public string Clarity { get; set; }
        public int? PurityCode { get; set; }
        public string Cut { get; set; }
        public int? CutCode { get; set; }
    }
}