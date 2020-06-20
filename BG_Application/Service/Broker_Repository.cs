using BG_Application.CustomDTO;
using BG_Application.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.Service
{
    public class Broker_Repository : IBroker_Repository, IDisposable
    {
        private BG_Application.Data.BG_DBEntities DB;
        public Broker_Repository(BG_Application.Data.BG_DBEntities _DB)
        {
            DB = _DB;
        }
        public List<ApplicationUserViewModel> GetBrokerList()
        {
            string RoleID = DB.AspNetRoles.FirstOrDefault(x => x.Name.Equals(EnumTypes.RoleList.BROKER.ToString())).Id;
            return DB.AspNetUsers.Where(x => x.Active == true && x.AspNetRoles.Any(c => c.Id == RoleID)).Select(y => new ApplicationUserViewModel()
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
            }).OrderBy(x => x.FirstName).ToList();
        }

        public List<BrokerColumnsViewModel> GetBrokerColumn()
        {
            return (from c in DB.BrokerColumnNames
                    join m in DB.BrokerColumnMappingMsts on c.ColumnId equals m.ColumnId into Col
                    from Column in Col.DefaultIfEmpty()
                    select new BrokerColumnsViewModel()
                    {
                        BrokerName = Column.AspNetUser.FirstName + " " + Column.AspNetUser.LastName,
                        ColumnName = Column.BrokerColumnName.ColumnName,
                        IsDisplay = Column != null ? true : false,
                        UserId = Column.UserId
                    }).ToList();

        }

        public List<DiamondStockViewModel> GetStock()
        {
            return DB.DiamondStocks.Where(x => x.Sale != true && x.Hold != true && x.Inquiry != true).Select(y => new DiamondStockViewModel()
            {
                StockMSTID = y.StockMSTID,
                StoneID = y.StoneID,
                Cts = y.Cts,
                Location = y.Location,
                ReportNo = y.ReportNo,
                CertificateCode = y.CertificateCode,
                ShapeCode = y.ShapeCode,
                SizeCode = y.SizeCode,
                ColorCode = y.ColorCode,
                PurityCode = y.PurityCode,
                CutCode = y.CutCode,
                PolishCode = y.PolishCode,
                SymmetryCode = y.SymmetryCode,
                FlouCode = y.FlouCode,
                Rap = y.Rap,
                Disc = y.Disc,
                Asking = y.Asking,
                Amount = y.Amount,
                SPer = y.SPer,
                SRate = y.SRate,
                SAmount = y.SAmount,
                Length = y.Length,
                Width = y.Width,
                Depth = y.Depth,
                DepthPer = y.DepthPer,
                TablePer = y.TablePer,
                CrownAngle = y.CrownAngle,
                CrownHeight = y.CrownHeight,
                PavAngle = y.PavAngle,
                PavHeight = y.PavHeight,
                KeytoSymbol = y.KeytoSymbol,
                VideoLink = y.VideoLink,
                EyeClean = y.EyeClean,
                Comments = y.Comments,
                Girdle = y.Girdle,
                Culet = y.Culet,
                Star = y.Star,
                Lower = y.Lower,
                Milky = y.Milky,
                CBlack = y.CBlack,
                SBlack = y.SBlack,
                CWhite = y.CWhite,
                SWhite = y.SWhite,
                HA = y.HA,
                ResultVerify = y.ResultVerify,
                ReportDate = y.ReportDate,
                Inscription = y.Inscription,
                Sale = y.Sale,
                Broker = y.Broker,
                Hold = y.Hold,
                Basket = y.Basket,
                Inquiry = y.Inquiry,
                FancyColorCode = y.FancyColorCode,
                BGM = y.BGM,
                Diameter = y.Diameter,
                Ratio = y.Ratio,
                Table = y.Table,
                TOInclusion = y.TOInclusion,
                COInclusion = y.COInclusion,
                POInclusion = y.POInclusion,
                GOInclusion = y.GOInclusion,
                CertificateName = DB.CertificateMsts.FirstOrDefault(c => c.CertificateCode == y.CertificateCode).CertificateName,
                ShapeName = DB.ShapeMsts.FirstOrDefault(c => c.ShapeCode == y.ShapeCode).ShapeAliasName,
                Size = DB.SizeMsts.FirstOrDefault(c => c.SizeMstID == y.SizeCode).SizeAlias,
                ColorName = DB.ColorMsts.FirstOrDefault(c => c.ColorCode == y.ColorCode).ColorAliasName,
                Cut = DB.CutMsts.FirstOrDefault(c => c.CutCode == y.CutCode).CutAliasName,
                Flou = DB.FlouMsts.FirstOrDefault(c => c.FlouCode == y.FlouCode).FlouAliasName,
                Polish = DB.PolishMsts.FirstOrDefault(c => c.PolishCode == y.PolishCode).PolishAliasName,
                Purity = DB.PurityMsts.FirstOrDefault(c => c.PurityCode == y.PurityCode).PurityAliasName,
                Symmetry = DB.SymmetryMsts.FirstOrDefault(c => c.SymmetryCode == y.SymmetryCode).SymmetryAliasName,
                FancyColorName = DB.FancyColorMsts.FirstOrDefault(c => c.FancyColorCode == y.FancyColorCode).FancyColorName
            }).ToList();
        }
        public string GetUserIdByEmail(string Email)
        {
            var user = DB.AspNetUsers.FirstOrDefault(x => x.Email == Email);
            if (user != null)
            {
                return user.Id;
            }
            return string.Empty;
        }
        public List<string> GetBrokerColumnByUserId(string UserID)
        {
            return DB.BrokerColumnMappingMsts.Where(x => x.UserId == UserID).OrderBy(b => b.Sort).Select(y => y.BrokerColumnName.ColumnName).ToList();
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
