using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class CompanyViewModel
    {
        public int CompanyMstId { get; set; }
        public int CompanyCode { get; set; }
        public Nullable<System.DateTime> Cdate { get; set; }
        public string CompanyName { get; set; }
        public string AlName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhNo1 { get; set; }
        public string PhNo2 { get; set; }
        public string FaxNo { get; set; }
        public string MobNo { get; set; }
        public string Email { get; set; }
        public string GST { get; set; }
        public string CST { get; set; }
        public string LST { get; set; }
        public string PAN { get; set; }
        public string TAN { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public Nullable<System.DateTime> TDate { get; set; }
        public Nullable<int> Logid { get; set; }
        public string Pcid { get; set; }
        public Nullable<System.DateTime> Sdate { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string CPATH { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
