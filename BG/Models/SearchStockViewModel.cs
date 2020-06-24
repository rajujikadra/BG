using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BG.Models
{
    public class SearchStockViewModel
    {
        public List<int> Shape { get; set; }
        public decimal? CaretFrom { get; set; }
        public decimal? CaretTo { get; set; }
        public decimal? RapOffFrom { get; set; }
        public decimal? RapOffTo { get; set; }

        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public List<decimal> MultiSize { get; set; }

        public List<int> Color { get; set; }
        public List<int> Clarity { get; set; }
        public List<int> Cut { get; set; }
        public List<int> Polish { get; set; }
        public List<int> Symmetry { get; set; }
        public List<int> Lab { get; set; }
        public List<string> KeyToSymbol { get; set; }
        public List<string> ReportComment { get; set; }
        public List<string> EyeClean { get; set; }
        public List<int> ColorShade { get; set; }
        public string BGM { get; set; }
        public List<int> Fluorescence { get; set; }
        public List<int> HA { get; set; }
        public string DiameterFrom { get; set; }
        public decimal? DiameterTo { get; set; }
        public decimal? RatioFrom { get; set; }
        public decimal? RatioTo { get; set; }
        public decimal? DepthFrom { get; set; }
        public decimal? DepthTo { get; set; }
        public decimal? TableFrom { get; set; }
        public decimal? TableTo { get; set; }
        public decimal? LengthFrom { get; set; }
        public decimal? LengthTo { get; set; }
        public decimal? WidthFrom { get; set; }
        public decimal? WidthTo { get; set; }
        public decimal? PavilionAngleFrom { get; set; }
        public decimal? PavilionAngleTo { get; set; }
        public decimal? PavilionHeightFrom { get; set; }
        public decimal? PavilionHeightTo { get; set; }
        public decimal? CrownAngleFrom { get; set; }
        public decimal? CrownAngleTo { get; set; }
        public decimal? CrownHeightFrom { get; set; }
        public decimal? CrownHeightTo { get; set; }
        public decimal? StarLengthFrom { get; set; }
        public decimal? StarLengthTo { get; set; }
        public decimal? LowerHalfFrom { get; set; }
        public decimal? LowerHalfTo { get; set; }
        public decimal? FromGirdle { get; set; }
        public decimal? ToGirdle { get; set; }
        public decimal? FromCulet { get; set; }
        public decimal? ToCulet { get; set; }
        public List<string> SearchArea { get; set; }
        public string Radio { get; set; }
        public List<int> SWhiteInclusion { get; set; }
        public List<int> CWhiteInclusion { get; set; }
        public List<int> SBlackInclusion { get; set; }
        public List<int> CBlackInclusion { get; set; }
        public List<int> TableInclusion { get; set; }
        public List<int> PavilionInclusion { get; set; }
        public List<int> CrownInclusion { get; set; }
        public List<int> GridleInclusion { get; set; }
    }
}
