using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class BrokerColumnsViewModel
    {
        public int BrokerColumnMappingID { get; set; }
        public string UserId { get; set; }
        public string BrokerName { get; set; }
        public string ColumnName { get; set; }
        public bool IsDisplay { get; set; }
        public int ColumnId { get; set; }
        public int? Sort { get; set; }
    }
}
