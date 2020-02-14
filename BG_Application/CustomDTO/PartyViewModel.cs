using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class PartyViewModel
    {
        public int PartyCode { get; set; }
        public string PartyName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string City { get; set; }
        public string PhNo1 { get; set; }
        public string PhNo2 { get; set; }
        public string MobNo1 { get; set; }
        public string MobNo2 { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string PanNo { get; set; }
        public Nullable<int> SortID { get; set; }
        public string Active { get; set; }
        public Nullable<int> Logid { get; set; }
        public string Pcid { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public Nullable<int> TypeCode { get; set; }
    }
}
