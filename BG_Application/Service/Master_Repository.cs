using BG_Application.CustomDTO;
using BG_Application.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.Service
{
    public class Master_Repository : IMaster_Repository, IDisposable
    {
        private BG_Application.Data.BG_DBEntities DB;
        public Master_Repository(BG_Application.Data.BG_DBEntities _DB)
        {
            DB = _DB;
        }

        public List<CertificateViewModel> GetAllCertificateMaster()
        {
            return DB.CertificateMsts.Select(y => new CertificateViewModel()
            {
                Active = y.Active,
                CertificateCode = y.CertificateCode,
                CertificateName = y.CertificateName,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<ColorViewModel> GetAllColorMaster()
        {
            return DB.ColorMsts.Select(y => new ColorViewModel()
            {
                ColorCode = y.ColorCode,
                Active = y.Active,
                ColorAliasName = y.ColorAliasName,
                ColorName = y.ColorName,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<CompanyViewModel> GetAllCompanyMaster()
        {
            return DB.CompanyMsts.Select(y => new CompanyViewModel()
            {
                Active = y.Active,
                Add1 = y.Add1,
                Add2 = y.Add2,
                AlName = y.AlName,
                Cdate = y.Cdate,
                City = y.City,
                CompanyCode = y.CompanyCode,
                CompanyLogo = y.CompanyLogo,
                CompanyMstId = y.CompanyMstId,
                CompanyName = y.CompanyName,
                CPATH = y.CPATH,
                CST = y.CST,
                Email = y.Email,
                FaxNo = y.FaxNo,
                FDate = y.FDate,
                GST = y.GST,
                Logid = y.Logid,
                LST = y.LST,
                MobNo = y.MobNo,
                PAN = y.PAN,
                Pcid = y.Pcid,
                PhNo1 = y.PhNo1,
                PhNo2 = y.PhNo2,
                Sdate = y.Sdate,
                State = y.State,
                TAN = y.TAN,
                TDate = y.TDate
            }).ToList();
        }

        public List<CutViewModel> GetAllCutMaster()
        {
            return DB.CutMsts.Select(y => new CutViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                CutAliasName = y.CutAliasName,
                CutCode = y.CutCode,
                CutName = y.CutName,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<FancyColorViewModel> GetAllFancyColorMaster()
        {
            return DB.FancyColorMsts.Select(y => new FancyColorViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                FancyColorCode = y.FancyColorCode,
                FancyColorName = y.FancyColorName,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<FancyOTViewModel> GetAllFancyOTMaster()
        {
            return DB.FancyOTMsts.Select(y => new FancyOTViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                FancyOTCode = y.FancyOTCode,
                FancyOTName = y.FancyOTName,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<FlouViewModel> GetAllFlouMaster()
        {
            return DB.FlouMsts.Select(y => new FlouViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                FlouAliasName = y.FlouAliasName,
                FlouCode = y.FlouCode,
                FlouName = y.FlouName,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<HAViewModel> GetAllHAMaster()
        {
            return DB.HAMsts.Select(y => new HAViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                HAAliasName = y.HAAliasName,
                HACode = y.HACode,
                HAName = y.HAName,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<PartyViewModel> GetAllPartyMaster()
        {
            return DB.PartyMsts.Select(y => new PartyViewModel()
            {
                Active = y.Active,
                Add1 = y.Add1,
                Add2 = y.Add2,
                Add3 = y.Add3,
                City = y.City,
                CompanyCode = y.CompanyCode,
                Email = y.Email,
                FaxNo = y.FaxNo,
                Logid = y.Logid,
                MobNo1 = y.MobNo1,
                MobNo2 = y.MobNo2,
                PanNo = y.PanNo,
                PartyCode = y.PartyCode,
                PartyName = y.PartyName,
                Pcid = y.Pcid,
                PhNo1 = y.PhNo1,
                PhNo2 = y.PhNo2,
                Sdate = y.Sdate,
                SortID = y.SortID,
                TypeCode = y.TypeCode
            }).ToList();
        }

        public List<PurityViewModel> GetAllPurityMaster()
        {
            return DB.PurityMsts.Select(y => new PurityViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                PurityAliasName = y.PurityAliasName,
                PurityCode = y.PurityCode,
                PurityName = y.PurityName,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<ShapViewModel> GetAllShapMaster()
        {
            return DB.ShapeMsts.Select(y => new ShapViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                ShapeAliasName = y.ShapeAliasName,
                ShapeCode = y.ShapeCode,
                ShapeName = y.ShapeName,
                SortID = y.SortID
            }).ToList();
        }

        public List<SizeViewModel> GetAllSizeMaster()
        {
            return DB.SizeMsts.Select(y => new SizeViewModel()
            {
                Active = y.Active,
                CompanyCode = y.CompanyCode,
                FromSize = y.FromSize,
                Logid = y.Logid,
                Pcid = y.Pcid,
                SizeAlias = y.SizeAlias,
                Sdate = y.Sdate,
                SizeMstID = y.SizeMstID,
                SortID = y.SortID,
                ToSize = y.ToSize
            }).ToList();
        }

        public List<TypeViewModel> GetAllTypeMaster()
        {
            return DB.Database.SqlQuery<TypeViewModel>("SELECT * FROM TypeMst").ToList();
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
