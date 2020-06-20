using BG_Application.CustomDTO;
using BG_Application.Data;
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

        public List<SBlackInclusionViewModel> GetAllSideBlackInclusion()
        {
            return DB.SBlackInclusionMsts.Select(y => new SBlackInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<SWhiteInclusionViewModel> GetAllSideWhiteInclusion()
        {
            return DB.SWhiteInclusionMsts.Select(y => new SWhiteInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<OTableInclusionViewModel> GetAllOpenTableInclusion()
        {
            return DB.OTableInclusionMsts.Select(y => new OTableInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<OCrownInclusionViewModel> GetAllOpenCrownInclusion()
        {
            return DB.OCrownInclusionMsts.Select(y => new OCrownInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<GOInclusionViewModel> GetAllOpenGirdleInclusion()
        {
            return DB.OGirdleInclusionMsts.Select(y => new GOInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public bool InsertOGirdleInclusionMaster(GOInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.OGirdleInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new OGirdleInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.OGirdleInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsOGirdleInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.OGirdleInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.OGirdleInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteOGirdleInclusion(int ID)
        {
            try
            {
                var data = DB.OGirdleInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<OPavilionInclusionViewModel> GetAllOpenPavilionInclusion()
        {
            return DB.OPavilionInclusionMsts.Select(y => new OPavilionInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<CBlackInclusionViewModel> GetAllCenterBlackInclusion()
        {
            return DB.CBlackInclusionMsts.Select(y => new CBlackInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public List<CWhiteInclusionViewModel> GetAllCenterWhiteInclusion()
        {
            return DB.CWhiteInclusionMsts.Select(y => new CWhiteInclusionViewModel()
            {
                Code = y.Code,
                Active = y.Active,
                AliasName = y.AliasName,
                Name = y.Name,
                CompanyCode = y.CompanyCode,
                Logid = y.Logid,
                Pcid = y.Pcid,
                Sdate = y.Sdate,
                SortID = y.SortID
            }).ToList();
        }

        public bool InsertSBlackInclusionMaster(SBlackInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.SBlackInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new SBlackInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.SBlackInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsSBlackInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.SBlackInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.SBlackInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteSBlackInclusion(int ID)
        {
            try
            {
                var data = DB.SBlackInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertCBlackInclusionMaster(CBlackInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.CBlackInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new CBlackInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.CBlackInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsCBlackInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.CBlackInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.CBlackInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteCBlackInclusion(int ID)
        {
            try
            {
                var data = DB.CBlackInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertCWhiteInclusionMaster(CWhiteInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.CWhiteInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new CWhiteInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.CWhiteInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsCWhiteInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.CWhiteInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.CWhiteInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteCWhiteInclusion(int ID)
        {
            try
            {
                var data = DB.CWhiteInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertOTableInclusionMaster(OTableInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.OTableInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new OTableInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.OTableInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsOTableInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.OTableInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.OTableInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteOTableInclusion(int ID)
        {
            try
            {
                var data = DB.OTableInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertOCrownInclusionMaster(OCrownInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.OCrownInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new OCrownInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.OCrownInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsOCrownInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.OCrownInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.OCrownInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteOCrownInclusion(int ID)
        {
            try
            {
                var data = DB.OCrownInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertOPavilionInclusionMaster(OPavilionInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.OPavilionInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new OPavilionInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.OPavilionInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsOPavilionInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.OPavilionInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.OPavilionInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteOPavilionInclusion(int ID)
        {
            try
            {
                var data = DB.OPavilionInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        public bool InsertSWhiteInclusionMaster(SWhiteInclusionViewModel model)
        {
            try
            {
                if (model.Code != 0)
                {
                    var data = DB.SWhiteInclusionMsts.FirstOrDefault(x => x.Code == model.Code);
                    if (data != null)
                    {
                        data.Name = model.Name.ToUpper();
                        data.AliasName = model.AliasName.ToUpper();
                        data.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new SWhiteInclusionMst
                    {
                        Active = model.Active,
                        AliasName = model.AliasName.ToUpper(),
                        Name = model.Name.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.SWhiteInclusionMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsSWhiteInclusionExist(string Name, int Code)
        {
            if (Code > 0)
                return DB.SWhiteInclusionMsts.Any(x => x.Code != Code && x.Name.ToUpper().Equals(Name.ToUpper()));
            else
                return DB.SWhiteInclusionMsts.Any(x => x.Name.ToUpper().Equals(Name.ToUpper()));
        }

        public bool DeleteSWhiteInclusion(int ID)
        {
            try
            {
                var data = DB.SWhiteInclusionMsts.FirstOrDefault(x => x.Code == ID);
                if (data != null)
                {
                    data.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsColorExist(string ColorName, int ColorCode)
        {
            if (ColorCode > 0)
                return DB.ColorMsts.Any(x => x.ColorCode != ColorCode && x.ColorName.ToUpper().Equals(ColorName.ToUpper()));
            else
                return DB.ColorMsts.Any(x => x.ColorName.ToUpper().Equals(ColorName.ToUpper()));
        }
        public bool DeleteColorMaster(int ID)
        {
            try
            {
                var Color = DB.ColorMsts.FirstOrDefault(x => x.ColorCode == ID);
                if (Color != null)
                {
                    Color.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertColorMaster(ColorViewModel model)
        {
            try
            {
                if (model.ColorCode != 0)
                {
                    var color = DB.ColorMsts.FirstOrDefault(x => x.ColorCode == model.ColorCode);
                    if (color != null)
                    {
                        color.ColorName = model.ColorName.ToUpper();
                        color.ColorAliasName = model.ColorAliasName.ToUpper();
                        color.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new ColorMst
                    {
                        Active = model.Active,
                        ColorAliasName = model.ColorAliasName.ToUpper(),
                        ColorName = model.ColorName.ToUpper(),
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.ColorMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InsertCertificateMaster(CertificateViewModel model)
        {
            try
            {
                if (model.CertificateCode != 0)
                {
                    var certificate = DB.CertificateMsts.FirstOrDefault(x => x.CertificateCode == model.CertificateCode);
                    if (certificate != null)
                    {
                        certificate.CertificateName = model.CertificateName;
                        certificate.Active = model.Active ?? true;
                        certificate.SortID = model.SortID ?? certificate.SortID;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new CertificateMst
                    {
                        CertificateName = model.CertificateName,
                        CompanyCode = 1,
                        SortID = model.SortID,
                        Active = model.Active,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        Logid = model.Logid
                    };
                    DB.CertificateMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsCertificateExist(string CertificateName, int CertificateCode)
        {
            if (CertificateCode > 0)
                return DB.CertificateMsts.Any(x => x.CertificateCode != CertificateCode && x.CertificateName.Trim().ToUpper().Equals(CertificateName.Trim().ToUpper()));
            else
                return DB.CertificateMsts.Any(x => x.CertificateName.Trim().ToUpper().Equals(CertificateName.Trim().ToUpper()));
        }

        public bool DeleteCertificate(int CertificateCode)
        {
            try
            {
                var certificate = DB.CertificateMsts.FirstOrDefault(x => x.CertificateCode == CertificateCode);
                if (certificate != null)
                {
                    certificate.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InsertCutMaster(CutViewModel model)
        {
            try
            {
                if (model.CutCode != 0)
                {
                    var Cut = DB.CutMsts.FirstOrDefault(x => x.CutCode == model.CutCode);
                    if (Cut != null)
                    {
                        Cut.CutAliasName = model.CutAliasName;
                        Cut.CutName = model.CutName;
                        Cut.SortID = model.SortID;
                        Cut.Active = model.Active ?? true;
                    }
                }
                else
                {
                    var obj = new CutMst
                    {
                        Active = model.Active,
                        CompanyCode = 1,
                        CutAliasName = model.CutAliasName,
                        CutName = model.CutName,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.CutMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsCutExist(string CutName, int CutCode)
        {
            if (CutCode > 0)
                return DB.CutMsts.Any(x => x.CutCode != CutCode && x.CutName.Trim().ToUpper().Equals(CutName.Trim().ToUpper()));
            else
                return DB.CutMsts.Any(x => x.CutName.Trim().ToUpper().Equals(CutName.Trim().ToUpper()));
        }
        public bool DeleteCut(int CutCode)
        {
            try
            {
                var Cut = DB.CutMsts.FirstOrDefault(x => x.CutCode == CutCode);
                if (Cut != null)
                {
                    Cut.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertFancyColorMaster(FancyColorViewModel model)
        {
            try
            {
                if (model.CompanyCode != 0)
                {
                    var FancyColor = DB.FancyColorMsts.FirstOrDefault(x => x.FancyColorCode == model.FancyColorCode);
                    if (FancyColor != null)
                    {
                        FancyColor.FancyColorName = model.FancyColorName;
                        FancyColor.SortID = model.SortID;
                        FancyColor.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new FancyColorMst
                    {
                        CompanyCode = 1,
                        FancyColorName = model.FancyColorName,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID,
                        Active = model.Active,
                    };
                    DB.FancyColorMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsFancyColorExist(string FancyColorName, int FancyColorCode)
        {
            if (FancyColorCode != 0)
                return DB.FancyColorMsts.Any(x => x.FancyColorCode != FancyColorCode && x.FancyColorName.Trim().ToUpper().Equals(FancyColorName.Trim().ToUpper()));
            else
                return DB.FancyColorMsts.Any(x => x.FancyColorName.Trim().ToUpper().Equals(FancyColorName.Trim().ToUpper()));
        }
        public bool DeleteFancyColor(int FancyColorCode)
        {
            try
            {
                var FancyColor = DB.FancyColorMsts.FirstOrDefault(x => x.FancyColorCode == FancyColorCode);
                if (FancyColor != null)
                {
                    FancyColor.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertFancyOTMaster(FancyOTViewModel model)
        {
            try
            {
                if (model.FancyOTCode != 0)
                {
                    var FancyOT = DB.FancyOTMsts.FirstOrDefault(x => x.FancyOTCode == model.FancyOTCode);
                    if (FancyOT != null)
                    {
                        FancyOT.FancyOTName = model.FancyOTName;
                        FancyOT.SortID = model.SortID;
                        FancyOT.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new FancyOTMst
                    {
                        Active = model.Active,
                        CompanyCode = 1,
                        FancyOTName = model.FancyOTName,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.FancyOTMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsFancyOTExist(string FancyOTName, int FancyOTCode)
        {
            if (FancyOTCode != 0)
                return DB.FancyOTMsts.Any(x => x.FancyOTCode != FancyOTCode && x.FancyOTName.Trim().ToUpper().Equals(FancyOTName.Trim().ToUpper()));
            else
                return DB.FancyOTMsts.Any(x => x.FancyOTName.Trim().ToUpper().Equals(FancyOTName.Trim().ToUpper()));
        }
        public bool DeleteFancyOT(int FancyOTCode)
        {
            try
            {
                var FancyOT = DB.FancyOTMsts.FirstOrDefault(x => x.FancyOTCode == FancyOTCode);
                if (FancyOT != null)
                {
                    FancyOT.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertFlouMaster(FlouViewModel model)
        {
            try
            {
                if (model.FlouCode != 0)
                {
                    var Flou = DB.FlouMsts.FirstOrDefault(x => x.FlouCode == model.FlouCode);
                    if (Flou != null)
                    {
                        Flou.Active = model.Active ?? true;
                        Flou.FlouAliasName = model.FlouAliasName;
                        Flou.FlouName = model.FlouName;
                        Flou.SortID = model.SortID;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new FlouMst
                    {
                        Active = model.Active,
                        CompanyCode = 1,
                        FlouAliasName = model.FlouAliasName,
                        FlouName = model.FlouName,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.FlouMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsFlouExist(string FlouName, int FlouCode)
        {
            if (FlouCode != 0)
                return DB.FlouMsts.Any(x => x.FlouCode != FlouCode && x.FlouName.Trim().ToUpper().Equals(FlouName.Trim().ToUpper()));
            else
                return DB.FlouMsts.Any(x => x.FlouName.Trim().ToUpper().Equals(FlouName.Trim().ToUpper()));
        }
        public bool DeleteFlou(int FlouCode)
        {
            try
            {
                var Flou = DB.FlouMsts.FirstOrDefault(x => x.FlouCode == FlouCode);
                if (Flou != null)
                {
                    Flou.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertHAMaster(HAViewModel model)
        {
            try
            {
                if (model.HACode != 0)
                {
                    var HA = DB.HAMsts.FirstOrDefault(x => x.HACode == model.HACode);
                    if (HA != null)
                    {
                        HA.HAAliasName = model.HAAliasName;
                        HA.HAName = model.HAName;
                        HA.SortID = model.SortID;
                        HA.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new HAMst
                    {
                        Active = model.Active,
                        CompanyCode = 1,
                        HAAliasName = model.HAAliasName,
                        HAName = model.HAName,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.HAMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsHAExis(string HAName, int HACode)
        {
            if (HACode != 0)
                return DB.HAMsts.Any(x => x.HACode != HACode && x.HAName.Trim().ToUpper().Equals(HAName.Trim().ToUpper()));
            else
                return DB.HAMsts.Any(x => x.HAName.Trim().ToUpper().Equals(HAName.Trim().ToUpper()));
        }
        public bool DeleteHA(int HACode)
        {
            try
            {
                var HA = DB.HAMsts.FirstOrDefault(x => x.HACode == HACode);
                if (HA != null)
                {
                    HA.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteParty(int PartyCode)
        {
            try
            {
                var Party = DB.PartyMsts.FirstOrDefault(x => x.PartyCode == PartyCode);
                if (Party != null)
                {
                    Party.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsPartyExist(int PartyCode, string PartyName, string MobNo1, string MobNo2)
        {
            if (PartyCode != 0)
                return DB.PartyMsts.Any(x => x.PartyCode != PartyCode && x.PartyName.Trim().ToUpper().Equals(PartyName.Trim().ToUpper()) && x.MobNo1.Equals(MobNo1) && x.MobNo2.Equals(MobNo1));
            else
                return DB.PartyMsts.Any(x => x.PartyName.Trim().ToUpper().Equals(PartyName.Trim().ToUpper()) && x.MobNo1.Equals(MobNo1) && x.MobNo2.Equals(MobNo1));
        }
        public bool InsertPartyMaster(PartyViewModel model)
        {
            try
            {
                if (model.PartyCode != 0)
                {
                    var party = DB.PartyMsts.FirstOrDefault(x => x.PartyCode == model.PartyCode);
                    if (party != null)
                    {
                        party.PartyName = model.PartyName;
                        party.Add1 = model.Add1;
                        party.Add2 = model.Add2;
                        party.Add3 = model.Add3;
                        party.City = model.City;
                        party.PhNo1 = model.PhNo1;
                        party.PhNo2 = model.PhNo2;
                        party.MobNo1 = model.MobNo1;
                        party.MobNo2 = model.MobNo2;
                        party.FaxNo = model.FaxNo;
                        party.Email = model.Email;
                        party.PanNo = model.PanNo;
                        party.SortID = model.SortID;
                        party.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new PartyMst
                    {
                        Active = model.Active,
                        Add1 = model.Add1,
                        Add2 = model.Add2,
                        Add3 = model.Add3,
                        City = model.City,
                        CompanyCode = 1,
                        Email = model.Email,
                        FaxNo = model.FaxNo,
                        Logid = model.Logid,
                        MobNo1 = model.MobNo1,
                        MobNo2 = model.MobNo2,
                        PanNo = model.PanNo,
                        PartyName = model.PartyName,
                        Pcid = model.Pcid,
                        PhNo1 = model.PhNo1,
                        PhNo2 = model.PhNo2,
                        Sdate = DateTime.Now,
                        SortID = model.SortID
                    };
                    DB.PartyMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePurity(int PurityCode)
        {
            try
            {
                var Purity = DB.PurityMsts.FirstOrDefault(x => x.PurityCode == PurityCode);
                if (Purity != null)
                {
                    Purity.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsPurityExist(string PurityName, int PurityCode)
        {
            if (PurityCode != 0)
                return DB.PurityMsts.Any(x => x.PurityCode != PurityCode && x.PurityName.Trim().ToUpper().Equals(PurityName.Trim().ToUpper()));
            else
                return DB.PurityMsts.Any(x => x.PurityName.Trim().ToUpper().Equals(PurityName.Trim().ToUpper()));
        }
        public bool InsertPurityMaster(PurityViewModel model)
        {
            try
            {
                if (model.PurityCode != 0)
                {
                    var purity = DB.PurityMsts.FirstOrDefault(x => x.PurityCode == model.PurityCode);
                    if (purity != null)
                    {
                        purity.PurityAliasName = model.PurityAliasName;
                        purity.PurityName = model.PurityName;
                        purity.SortID = model.SortID;
                        purity.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new PurityMst
                    {
                        Active = model.Active,
                        SortID = model.SortID,
                        Sdate = DateTime.Now,
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        PurityAliasName = model.PurityAliasName,
                        PurityName = model.PurityName
                    };
                    DB.PurityMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteShap(int ShapCode)
        {
            try
            {
                var Shap = DB.ShapeMsts.FirstOrDefault(x => x.ShapeCode == ShapCode);
                if (Shap != null)
                {
                    Shap.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsShapExist(string ShapName, int ShapCode)
        {
            if (ShapCode != 0)
                return DB.ShapeMsts.Any(x => x.ShapeCode != ShapCode && x.ShapeName.Trim().ToUpper().Equals(ShapName.Trim().ToUpper()));
            else
                return DB.ShapeMsts.Any(x => x.ShapeName.Trim().ToUpper().Equals(ShapName.Trim().ToUpper()));
        }
        public bool InsertShapMaster(ShapViewModel model)
        {
            try
            {
                if (model.ShapeCode != 0)
                {
                    var shap = DB.ShapeMsts.FirstOrDefault(x => x.ShapeCode == model.ShapeCode);
                    if (shap != null)
                    {
                        shap.ShapeName = model.ShapeName;
                        shap.ShapeAliasName = model.ShapeAliasName;
                        shap.SortID = model.SortID;
                        shap.Active = model.Active ?? true;
                        DB.SaveChanges();
                    }
                }
                else
                {
                    var obj = new ShapeMst
                    {
                        Active = model.Active,
                        CompanyCode = 1,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        ShapeAliasName = model.ShapeAliasName,
                        ShapeName = model.ShapeName,
                        SortID = model.SortID
                    };
                    DB.ShapeMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSize(int SizeMstId)
        {
            try
            {
                var Size = DB.SizeMsts.FirstOrDefault(x => x.SizeMstID == SizeMstId);
                if (Size != null)
                {
                    Size.Active = false;
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsSizeExist(int SizeMstId, decimal FromSize, decimal ToSize)
        {
            if (SizeMstId != 0)
                return DB.SizeMsts.Any(x => x.SizeMstID != SizeMstId && x.FromSize == FromSize && x.ToSize == ToSize || (x.FromSize >= FromSize && x.ToSize >= ToSize));
            else
                return DB.SizeMsts.Any(x => x.FromSize == FromSize && x.ToSize == ToSize || (x.FromSize >= FromSize && x.ToSize >= ToSize));
        }
        public bool InsertSizeMaster(SizeViewModel model)
        {
            try
            {
                var Size = DB.SizeMsts.FirstOrDefault(x => x.SizeMstID == model.SizeMstID);
                if (Size != null)
                {
                    Size.FromSize = model.FromSize;
                    Size.ToSize = model.ToSize;
                    Size.SortID = model.SortID;
                    Size.Active = model.Active ?? true;
                    Size.SizeAlias = model.SizeAlias;
                    DB.SaveChanges();
                }
                else
                {
                    var obj = new SizeMst
                    {
                        CompanyCode = 1,
                        Active = model.Active,
                        FromSize = model.FromSize,
                        Logid = model.Logid,
                        Pcid = model.Pcid,
                        Sdate = DateTime.Now,
                        SizeAlias = model.SizeAlias,
                        SortID = model.SortID,
                        ToSize = model.ToSize
                    };
                    DB.SizeMsts.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<DiamondStockViewModel> GetAllStock()
        {
            return DB.DiamondStocks.Where(x => x.Sale != true).Select(y => new DiamondStockViewModel()
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

        public bool InsertStockMaster(DiamondStockViewModel model)
        {
            try
            {
                if (model.StockMSTID != 0)
                {
                    var Stock = DB.DiamondStocks.FirstOrDefault(x => x.StockMSTID == model.StockMSTID);
                    if (Stock != null)
                    {
                        Stock.SizeCode = model.SizeCode;
                        Stock.StoneID = model.StoneID;
                        Stock.SWhite = model.SWhite;
                        Stock.SymmetryCode = model.SymmetryCode;
                        Stock.TablePer = model.TablePer;
                        Stock.CBlack = model.CBlack;
                        Stock.CWhite = model.CWhite;
                        Stock.VideoLink = model.VideoLink;
                        Stock.Width = model.Width;
                        Stock.Star = model.Star;
                        Stock.Amount = model.Amount;
                        Stock.Asking = model.Asking;
                        Stock.Basket = model.Basket;
                        Stock.Broker = model.Broker;
                        Stock.CertificateCode = model.CertificateCode;
                        Stock.ColorCode = model.ColorCode;
                        Stock.Comments = model.Comments;
                        Stock.CrownAngle = model.CrownAngle;
                        Stock.CrownHeight = model.CrownHeight;
                        Stock.Cts = model.Cts;
                        Stock.Culet = model.Culet;
                        Stock.CutCode = model.CutCode;
                        Stock.Depth = model.Depth;
                        Stock.DepthPer = model.DepthPer;
                        Stock.Disc = model.Disc;
                        Stock.EyeClean = model.EyeClean;
                        Stock.FlouCode = model.FlouCode;
                        Stock.Girdle = model.Girdle;
                        Stock.HA = model.HA;
                        Stock.Hold = model.Hold;
                        Stock.Inquiry = model.Inquiry;
                        Stock.Inscription = model.Inscription;
                        Stock.KeytoSymbol = model.KeytoSymbol;
                        Stock.Length = model.Length;
                        Stock.Location = model.Location;
                        Stock.Lower = model.Lower;
                        Stock.Milky = model.Milky;
                        Stock.PavAngle = model.PavAngle;
                        Stock.PavHeight = model.PavHeight;
                        Stock.PolishCode = model.PolishCode;
                        Stock.PurityCode = model.PurityCode;
                        Stock.Rap = model.Rap;
                        Stock.ReportDate = model.ReportDate;
                        Stock.ReportNo = model.ReportNo;
                        Stock.ResultVerify = model.ResultVerify;
                        Stock.Sale = model.Sale;
                        Stock.SAmount = model.SAmount;
                        Stock.SBlack = model.SBlack;
                        Stock.ShapeCode = model.ShapeCode;
                        Stock.SPer = model.SPer;
                        Stock.SRate = model.SRate;
                        Stock.FancyColorCode = model.FancyColorCode;
                        Stock.BGM = model.BGM;
                        Stock.Diameter = model.Diameter;
                        Stock.Ratio = model.Ratio;
                        Stock.Table = model.Table;
                        Stock.TOInclusion = model.TOInclusion;
                        Stock.COInclusion = model.COInclusion;
                        Stock.POInclusion = model.POInclusion;
                        Stock.GOInclusion = model.GOInclusion;
                    }
                }
                else
                {
                    var obj = new DiamondStock
                    {
                        SizeCode = model.SizeCode,
                        StoneID = model.StoneID,
                        SWhite = model.SWhite,
                        SymmetryCode = model.SymmetryCode,
                        TablePer = model.TablePer,
                        CBlack = model.CBlack,
                        CWhite = model.CWhite,
                        VideoLink = model.VideoLink,
                        Width = model.Width,
                        Star = model.Star,
                        Amount = model.Amount,
                        Asking = model.Asking,
                        Basket = model.Basket,
                        Broker = model.Broker,
                        CertificateCode = model.CertificateCode,
                        ColorCode = model.ColorCode,
                        Comments = model.Comments,
                        CrownAngle = model.CrownAngle,
                        CrownHeight = model.CrownHeight,
                        Cts = model.Cts,
                        Culet = model.Culet,
                        CutCode = model.CutCode,
                        Depth = model.Depth,
                        DepthPer = model.DepthPer,
                        Disc = model.Disc,
                        EyeClean = model.EyeClean,
                        FlouCode = model.FlouCode,
                        Girdle = model.Girdle,
                        HA = model.HA,
                        Hold = model.Hold,
                        Inquiry = model.Inquiry,
                        Inscription = model.Inscription,
                        KeytoSymbol = model.KeytoSymbol,
                        Length = model.Length,
                        Location = model.Location,
                        Lower = model.Lower,
                        Milky = model.Milky,
                        PavAngle = model.PavAngle,
                        PavHeight = model.PavHeight,
                        PolishCode = model.PolishCode,
                        PurityCode = model.PurityCode,
                        Rap = model.Rap,
                        ReportDate = model.ReportDate,
                        ReportNo = model.ReportNo,
                        ResultVerify = model.ResultVerify,
                        Sale = model.Sale,
                        SAmount = model.SAmount,
                        SBlack = model.SBlack,
                        ShapeCode = model.ShapeCode,
                        SPer = model.SPer,
                        SRate = model.SRate,
                        FancyColorCode = model.FancyColorCode,
                        BGM = model.BGM,
                        Diameter = model.Diameter,
                        Ratio = model.Ratio,
                        Table = model.Table,
                        TOInclusion = model.TOInclusion,
                        COInclusion = model.COInclusion,
                        POInclusion = model.POInclusion,
                        GOInclusion = model.GOInclusion,
                    };
                    DB.DiamondStocks.Add(obj);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsStockExist(int StockID, string StoneID)
        {
            if (StockID != 0)
                return DB.DiamondStocks.Any(x => x.StockMSTID != StockID && x.StoneID == StoneID);
            else
                return DB.DiamondStocks.Any(x => x.StoneID == StoneID);
        }
        public bool DeleteStock(int ID)
        {
            try
            {
                var Stock = DB.DiamondStocks.FirstOrDefault(x => x.StockMSTID == ID);
                if (Stock != null)
                {
                    DB.DiamondStocks.Remove(Stock);
                    DB.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
