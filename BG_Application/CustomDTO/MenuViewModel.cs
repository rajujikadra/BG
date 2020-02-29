using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class MenuViewModel
    {
        public int? MainMenuMstID { get; set; }
        public string MainMenuName { get; set; }
        public string Icon { get; set; }
        public Nullable<int> SortId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string URL { get; set; }
        public List<SubMenuViewModel> SubMenu { get; set; }
    }
    public class SubMenuViewModel
    {
        public int MenuMstId { get; set; }
        public Nullable<int> MainMenuMstId { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> SortId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
