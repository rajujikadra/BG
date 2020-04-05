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
}
