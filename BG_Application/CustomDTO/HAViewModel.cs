﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class HAViewModel
    {
        public int HACode { get; set; }
        public string HAName { get; set; }
        public string HAAliasName { get; set; }
        public Nullable<int> SortID { get; set; }
        public Nullable<int> Logid { get; set; }
        public string Pcid { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
