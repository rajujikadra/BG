using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class SalesPersonMenuPermissionViewModel
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public bool IsDisplay { get; set; }
    }
}
