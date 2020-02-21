using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class EnumTypes
    {
        public enum CustomerType
        {
            New,
            Register
        }

        public enum RoleList
        {
            ADMIN,
            SALESPERSON,
            BROKER,
            USER,
            SITE
        }
    }
}
