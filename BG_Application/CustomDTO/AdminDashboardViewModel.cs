using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class AdminDashboardViewModel
    {
        public TilesCountViewModel TilesCount { get; set; }
        public AdminDashboardViewModel()
        {
            this.TilesCount = new TilesCountViewModel();
        }
    }
    public class TilesCountViewModel
    {
        public int NewCustomers_Count { get; set; }
        public int Customers_Count { get; set; }
        public int SalesPerson_Count { get; set; }
        public int Inquiries_Count { get; set; }
        public int Orders_Count { get; set; }
        public int Appoinments_Count { get; set; }
    }
}
