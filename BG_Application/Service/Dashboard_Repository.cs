using BG_Application.CustomDTO;
using BG_Application.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.Service
{
    public class Dashboard_Repository : IDashboard_Repository, IDisposable
    {
        private BG_Application.Data.BG_DBEntities DB;
        public Dashboard_Repository(BG_Application.Data.BG_DBEntities _DB)
        {
            DB = _DB;
        }
        public AdminDashboardViewModel GetAdminDashboard()
        {
            var model = new AdminDashboardViewModel();
            model.TilesCount.NewCustomers_Count = DB.AspNetUsers.Count(x => x.Active == false);
            string RoleID = DB.AspNetRoles.FirstOrDefault(x => x.Name.Equals(EnumTypes.RoleList.USER.ToString())).Id;
            model.TilesCount.Customers_Count = DB.AspNetUsers.Count(x => x.Active == true && x.AspNetRoles.Any(c => c.Id == RoleID));
            string SalesPerson_RoleID = DB.AspNetRoles.FirstOrDefault(x => x.Name.Trim().ToUpper().Equals(EnumTypes.RoleList.SALESPERSON.ToString().Trim().ToUpper())).Id;
            model.TilesCount.SalesPerson_Count = DB.AspNetUsers.Count(x => x.Active == true && x.EmailConfirmed == true && x.AspNetRoles.Any(c => c.Id == SalesPerson_RoleID));
            return model;
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
