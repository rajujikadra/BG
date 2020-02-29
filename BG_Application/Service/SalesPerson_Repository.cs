using BG_Application.CustomDTO;
using BG_Application.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.Service
{
    public class SalesPerson_Repository : ISalesPerson_Repository, IDisposable
    {
        private BG_Application.Data.BG_DBEntities DB;
        public SalesPerson_Repository(BG_Application.Data.BG_DBEntities _DB)
        {
            DB = _DB;
        }
        public List<ApplicationUserViewModel> GetSalesPersons()
        {
            string RoleID = DB.AspNetRoles.FirstOrDefault(x => x.Name.Equals(EnumTypes.RoleList.SALESPERSON.ToString())).Id;
            return DB.AspNetUsers.Where(x => x.Active == true && x.EmailConfirmed == true && x.AspNetRoles.Any(c => c.Id == RoleID)).Select(y => new ApplicationUserViewModel()
            {
                Id = y.Id,
                FirstName = y.FirstName,
                LastName = y.LastName,
                Email = y.Email,
                CompanyAddress = y.CompanyAddress,
                CompanyCityId = y.CompanyCityId,
                CompanyName = y.CompanyName,
                CompanyZipcode = y.CompanyZipcode,
                CompanyCityName = y.CityMst.CityName,
                ContactPerson = y.ContactPerson,
                Mobile = y.Mobile,
                RefBusiness = y.RefBusiness,
                RefMobile = y.RefMobile,
                RefName = y.RefName,
                UserCityName = y.CityMst1.CityName,
                Active = y.Active,
                UserGSTNO = y.UserGSTNO
            }).OrderBy(v => v.FirstName).ToList();
        }





        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DB.Dispose();
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
