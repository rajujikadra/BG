using BG_Application.CustomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.ServiceContract
{
    public interface ICustomer_Repository
    {
        List<ApplicationUserViewModel> GetInActiveCustomers();
        List<ApplicationUserViewModel> GetRegisterCustomers();
        ApplicationUserViewModel GetCustomerDetails(string UserId);
        bool CustomerDeactivate(string Email);
        bool CustomerActivate(string Email);
        bool NewCustomerActivate(string Email);
    }
}
