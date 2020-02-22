using BG_Application.CustomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.ServiceContract
{
    public interface IBroker_Repository
    {
        List<ApplicationUserViewModel> GetBrokerList();
        List<BrokerColumnsViewModel> GetBrokerColumn();
    }
}
