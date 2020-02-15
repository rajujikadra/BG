using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_DataModel.DataModel;
using BG_Application.CustomDTO;

namespace BG_Application.Applications
{
    public class MasterApplication
    {
        private readonly BG_DBEntities _DB;
        public MasterApplication()
        {
            _DB = new BG_DBEntities();
        }


        #region Color Master
        public List<ColorViewModel> GetAllColorMaster()
        {
            return _DB.ColorMsts.Where(x => x.Active == true).Select(y => new ColorViewModel()
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
        #endregion

        #region Certificate Master
        public List<CertificateViewModel> GetAllCertificateMaster()
        {
            return _DB.CertificateMsts.Where(x => x.Active == true).Select(y => new CertificateViewModel()
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
        #endregion


        #region Company Master
        public List<CompanyViewModel> GetAllCompanyMaster()
        {
            return _DB.CompanyMsts.Where(x => x.Active == true).Select(y => new CompanyViewModel()
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
        #endregion


        #region Cut Master
        public List<CutViewModel> GetAllCutMaster()
        {
            return _DB.CutMsts.Where(x => x.Active == true).Select(y => new CutViewModel()
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
        #endregion

        #region Fancy Master
        public List<FancyColorViewModel> GetAllFancyColorMaster()
        {
            return _DB.FancyColorMsts.Where(x => x.Active == true).Select(y => new FancyColorViewModel()
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
        #endregion


        #region Fancy OT Master
        public List<FancyOTViewModel> GetAllFancyOTMaster()
        {
            return _DB.FancyOTMsts.Where(x => x.Active == true).Select(y => new FancyOTViewModel()
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
        #endregion

        #region Flou Master
        public List<FlouViewModel> GetAllFlouMaster()
        {
            return _DB.FlouMsts.Where(x => x.Active == true).Select(y => new FlouViewModel()
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
        #endregion


        #region HA Master
        public List<HAViewModel> GetAllHAMaster()
        {
            return _DB.HAMsts.Where(x => x.Active == true).Select(y => new HAViewModel()
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
        #endregion

        #region Party Master
        public List<PartyViewModel> GetAllPartyMaster()
        {
            return _DB.PartyMsts.Where(x => x.Active.Equals(1)).Select(y => new PartyViewModel()
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
        #endregion

        #region Purity Master
        public List<PurityViewModel> GetAllPurityMaster()
        {
            return _DB.PurityMsts.Where(x => x.Active == true).Select(y => new PurityViewModel()
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
        #endregion

        #region Shap Master
        public List<ShapViewModel> GetAllShapMaster()
        {
            return _DB.ShapeMsts.Where(x => x.Active == true).Select(y => new ShapViewModel()
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
        #endregion

        #region Size Master
        public List<SizeViewModel> GetAllSizeMaster()
        {
            return _DB.SizeMsts.Where(x => x.Active == true).Select(y => new SizeViewModel()
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
        #endregion

        #region Type Master
        public List<TypeViewModel> GetAllTypeMaster()
        {
            return _DB.Database.SqlQuery<TypeViewModel>("SELECT * FROM TypeMst").ToList();
        }
        #endregion
    }
}
