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
    }
}
