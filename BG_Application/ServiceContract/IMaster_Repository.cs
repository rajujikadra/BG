using BG_Application.CustomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.ServiceContract
{
    public interface IMaster_Repository
    {
        List<ColorViewModel> GetAllColorMaster();
        List<CertificateViewModel> GetAllCertificateMaster();
        List<CompanyViewModel> GetAllCompanyMaster();
        List<CutViewModel> GetAllCutMaster();
        List<FancyColorViewModel> GetAllFancyColorMaster();
        List<FancyOTViewModel> GetAllFancyOTMaster();
        List<FlouViewModel> GetAllFlouMaster();
        List<HAViewModel> GetAllHAMaster();
        List<PartyViewModel> GetAllPartyMaster();
        List<PurityViewModel> GetAllPurityMaster();
        List<ShapViewModel> GetAllShapMaster();
        List<SizeViewModel> GetAllSizeMaster();
        List<TypeViewModel> GetAllTypeMaster();


        bool InsertColorMaster(ColorViewModel model);
        bool IsColorExist(string ColorName, int ColorCode);
        bool DeleteColorMaster(int ID);

        bool InsertCertificateMaster(CertificateViewModel model);
        bool IsCertificateExist(string CertificateName, int CertificateCode);
        bool DeleteCertificate(int CertificateCode);

        bool InsertCutMaster(CutViewModel model);
        bool IsCutExist(string CutName, int CutCode);
        bool DeleteCut(int CutCode);

        bool InsertFancyColorMaster(FancyColorViewModel model);
        bool IsFancyColorExist(string FancyColorName, int FancyColorCode);
        bool DeleteFancyColor(int FancyColorCode);

        bool InsertFancyOTMaster(FancyOTViewModel model);
        bool IsFancyOTExist(string FancyOTName, int FancyOTCode);
        bool DeleteFancyOT(int FancyOTCode);

        bool InsertFlouMaster(FlouViewModel model);
        bool IsFlouExist(string FlouName, int FlouCode);
        bool DeleteFlou(int FlouCode);

        bool InsertHAMaster(HAViewModel model);
        bool IsHAExis(string HAName, int HACode);
        bool DeleteHA(int HACode);

        bool InsertPartyMaster(PartyViewModel model);
        bool IsPartyExist(int PartyCode, string PartyName, string MobNo1, string MobNo2);
        bool DeleteParty(int PartyCode);

        bool InsertPurityMaster(PurityViewModel model);
        bool IsPurityExist(string PurityName, int PurityCode);
        bool DeletePurity(int PurityCode);

        bool InsertShapMaster(ShapViewModel model);
        bool IsShapExist(string ShapName, int ShapCode);
        bool DeleteShap(int ShapCode);

        bool InsertSizeMaster(SizeViewModel model);
        bool IsSizeExist(int SizeMstId, decimal FromSize, decimal ToSize);
        bool DeleteSize(int SizeMstId);
    }
}
