using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyAddress { get; set; }
        public Nullable<int> CompanyCityId { get; set; }
        public string CompanyCityName { get; set; }
        public string CompanyStateName { get; set; }
        public string CompanyCountryName { get; set; }
        public string CompanyZipcode { get; set; }
        public string RefName { get; set; }
        public string RefMobile { get; set; }
        public string RefBusiness { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> UserCityId { get; set; }
        public string UserCityName { get; set; }
        public string UserState { get; set; }
        public string UserCountry { get; set; }
        public string Address { get; set; }
    }
}
