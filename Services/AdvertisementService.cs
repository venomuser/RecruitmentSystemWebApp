using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdvertisementService : IAdvertisementService
    {
        public Task<AdvertisementResponse> AddAdvertisement(AdvertisementAddRequest? adReqest)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertisementResponse> GetAdvertisementByID(Guid? Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementResponse>> GetAdvertisementsByCompanyID(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementResponse>> GetFilteredAdvertisements(List<AdvertisementResponse> adList, List<int?> salaries, List<long?> cities, List<CooperationTypeOptions?> cooperations)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementResponse>> GetNotVerifiedAdvertisements()
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementResponse>> GetSearchedAdvertisements(string? searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdvertisementResponse>> GetVerifiedAdvertisements()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAdvertisement(Guid adID)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertisementResponse> UpdateAdvertisementByAdmin(AdvertisementAdminUpdateDTO adminAdUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertisementResponse> UpdateAvertisementByCompany(AdvertisementCompanyUpdateDTO companyAdUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
