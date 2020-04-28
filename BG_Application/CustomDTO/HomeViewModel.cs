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
        public List<HA> Hearts_Arrows { get; set; }
        public List<string> KetToSymbol { get; set; }
        public List<string> Comments { get; set; }
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
}
