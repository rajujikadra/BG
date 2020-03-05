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
        public List<SalesPersonListViewModel> SalesPerson { get; set; }
        public AdminDashboardViewModel()
        {
            this.TilesCount = new TilesCountViewModel();
            this.SalesPerson = new List<SalesPersonListViewModel>();
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

    public class SalesPersonListViewModel
    {
        public string SalesPersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Mobile { get; set; }
        public DateTime? RegisterDate { get; set; }

        public int TotalCustomer { get; set; }
    }
}
