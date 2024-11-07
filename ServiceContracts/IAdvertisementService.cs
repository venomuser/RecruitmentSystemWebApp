using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IAdvertisementService
    {
        Task<AdvertisementResponse> AddAdvertisement(AdvertisementAddRequest? adReqest);
        Task<AdvertisementResponse> UpdateAvertisementByCompany(AdvertisementCompanyUpdateDTO companyAdUpdate);
        Task<AdvertisementResponse> UpdateAdvertisementByAdmin(AdvertisementAdminUpdateDTO adminAdUpdate);
        Task<bool> RemoveAdvertisement(Guid adID);
        Task<List<AdvertisementResponse>> GetVerifiedAdvertisements();
        Task<List<AdvertisementResponse>> GetNotVerifiedAdvertisements();
        Task<List<AdvertisementResponse>> GetAdvertisementsByCompanyID(Guid companyID);
        Task<List<AdvertisementResponse>> GetSearchedAdvertisements(string? searchTerm);
        Task<List<AdvertisementResponse>> GetFilteredAdvertisements(List<AdvertisementResponse> adList, List<int?> salaries,
            List<long?> cities, List<CooperationTypeOptions?> cooperations);
    }
}
