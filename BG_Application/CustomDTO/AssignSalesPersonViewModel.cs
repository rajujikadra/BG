using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class AssignSalesPersonViewModel
    {
        public int AssignID { get; set; }
        public string CustomerID { get; set; }
        public string SalesPersonID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Active { get; set; }
    }

    public class SalesPersons
    {
        public string SalesPersonID { get; set; }
        public string SalesPersonName { get; set; }
    }
}
