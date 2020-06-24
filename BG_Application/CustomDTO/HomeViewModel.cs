using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class HomeViewModel
    {
        public List<Shape> Shape { get; set; }
        public List<Color> Color { get; set; }
        public List<Cut> Cut { get; set; }
        public List<Polish> Polish { get; set; }
        public List<Symmetry> Symmetry { get; set; }
        public List<FancyColor> FancyColor { get; set; }
        public List<Purity> Clarity { get; set; }
        public List<Certificate> Lab { get; set; }
        public List<Fluorescence> Fluorescence { get; set; }
        public List<HA> Hearts_Arrows { get; set; }
        public List<SBlackInclusion> SBlack { get; set; }
        public List<SWhiteInclusion> SWhite { get; set; }
        public List<CBlackInclusion> CBlack { get; set; }
        public List<CWhiteInclusion> CWhite { get; set; }
        public List<TableInclusion> TableInclusion { get; set; }
        public List<CrownInclusion> CrownInclusion { get; set; }
        public List<PavilionInclusion> PavilionInclusion { get; set; }
        public List<GridleInclusion> GridleInclusion { get; set; }
        public List<Size> Size { get; set; }
        public List<string> KetToSymbol { get; set; }
        public List<string> Comments { get; set; }
        public List<string> EyeClean { get; set; }
    }

    public class Shape
    {
        public int ShapeCode { get; set; }
        public string ShapeName { get; set; }
        public string ShapeAliasName { get; set; }
    }
    public class Color
    {
        public int ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorAliasName { get; set; }
    }
    public class FancyColor
    {
        public int FancyColorCode { get; set; }
        public string FancyColorName { get; set; }
    }
    public class Fluorescence
    {
        public int FlouCode { get; set; }
        public string FlouName { get; set; }
        public string FlouAliasName { get; set; }
    }
    public class Cut
    {
        public int CutCode { get; set; }
        public string CutName { get; set; }
        public string CutAliasName { get; set; }
    }
    public class Polish
    {
        public int PolishCode { get; set; }
        public string PolishName { get; set; }
        public string PolishAliasName { get; set; }
    }
    public class Symmetry
    {
        public int SymmetryCode { get; set; }
        public string SymmetryName { get; set; }
        public string SymmetryAliasName { get; set; }
    }
    public class Purity
    {
        public int PurityCode { get; set; }
        public string PurityName { get; set; }
        public string PurityAliasName { get; set; }
    }
    public class Certificate
    {
        public int CertificateCode { get; set; }
        public string CertiificateName { get; set; }
    }
    public class HA
    {
        public int HACode { get; set; }
        public string HAName { get; set; }
        public string HAAliasName { get; set; }
    }
    public class SBlackInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class SWhiteInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class CBlackInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class CWhiteInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class TableInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class CrownInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class PavilionInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class GridleInclusion
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
    }
    public class Size
    {
        public int SizeMstID { get; set; }
        public Nullable<decimal> FromSize { get; set; }
        public Nullable<decimal> ToSize { get; set; }
    }
}
