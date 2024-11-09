using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdvertisementService : IAdvertisementService
    {

        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }


        public async Task<AdvertisementResponse?> AddAdvertisement(AdvertisementAddRequest? adReqest)
        {
            if(adReqest == null)
            {
                return null;
            }

            ValidationHelper.ModelValidation(adReqest);
            Advertisement? advertisement = adReqest.ToAdvertisement();
            advertisement.Id = Guid.NewGuid();
            advertisement.IsVerified = null;
            advertisement.EditionStatus = Guid.NewGuid();
            advertisement.NotVerificationDescription = null;

            await _advertisementRepository.CreateAdvertisement(advertisement);

            return advertisement.ToAdvertisementResponse();
            
        }

        public async Task<AdvertisementResponse?> GetAdvertisementByID(Guid? Id)
        {
            if (Id == null)
            {
                return null;
            }
            Advertisement? advertisement = await _advertisementRepository.GetAdvertisementByID(Id.Value);
            if (advertisement == null) { 
               
                return null;
            }

            return advertisement.ToAdvertisementResponse();
        }

        public async Task<List<AdvertisementResponse>> GetAdvertisementsByCompanyID(Guid companyID)
        {
            List<Advertisement> advertisements = await _advertisementRepository.GetAdvertisementsByCompanyID(companyID);
            return advertisements.Select(ad=>ad.ToAdvertisementResponse()).ToList();

        }

        public async Task<List<AdvertisementResponse>> GetFilteredAdvertisements(List<AdvertisementResponse> adList, List<int?> salaries, List<long?> cities, List<CooperationTypeOptions?> cooperations)
        {
            if (adList.Count < 1)
                return adList;

            if(salaries != null && salaries.Any())
            {
                adList = adList.Where(ad=> salaries.Contains(ad.SalaryAmountID)).ToList();
            }

            if(cities != null && cities.Any())
            {
                adList = adList.Where(ad => cities.Contains(ad.CityID)).ToList();
            }

            if(cooperations != null && cooperations.Any())
            {
                adList = adList.Where(ad=> cooperations.Contains((CooperationTypeOptions) Enum.Parse(typeof(CooperationTypeOptions)
                    ,ad.CooperationType,true))).ToList();
            }

            return adList;
        }

        public async Task<List<AdvertisementResponse>> GetNotVerifiedAdvertisements()
        {
            List<Advertisement> advertisements = await _advertisementRepository.GetNotVerifiedAdvertisements();
            return advertisements.Select(ad => ad.ToAdvertisementResponse()).ToList();
        }

        public async Task<List<AdvertisementResponse>> GetSearchedAdvertisements(List<AdvertisementResponse> adList, string? searchTerm)
        {
            if (searchTerm == null)
                return adList;
            if (adList.Count < 1)
                return adList;
            List<AdvertisementResponse> searchedAdList = adList.Where(ad=>ad.Title.Contains(searchTerm) || ad.Description.Contains(searchTerm)).ToList();
            return searchedAdList;
        }

        public async Task<List<AdvertisementResponse>> GetVerifiedAdvertisements()
        {
            List<Advertisement> advertisements = await _advertisementRepository.GetVerifiedAdvertisements();
            return advertisements.Select(ad => ad.ToAdvertisementResponse()).ToList();
        }

        public async Task<bool> RemoveAdvertisement(Guid? adID)
        {
            if (adID == null)
                return false;
            Advertisement? advertisement = await _advertisementRepository.GetAdvertisementByID(adID.Value);
            if(advertisement == null) return false;
            bool isDeleted = await _advertisementRepository.DeleteAdvertisement(adID.Value);
            return isDeleted;
        }

        public async Task<AdvertisementResponse?> UpdateAdvertisementByAdmin(AdvertisementAdminUpdateDTO? adminAdUpdate)
        {
            if(adminAdUpdate == null) return null;

            ValidationHelper.ModelValidation(adminAdUpdate);

          Advertisement? advertisement = await _advertisementRepository.GetAdvertisementByID(adminAdUpdate.AdvertisementID);
            if(advertisement == null) return null;
            advertisement.IsVerified = adminAdUpdate.IsVerified;
            advertisement.NotVerificationDescription = adminAdUpdate.NoVerificationDescription;

            await _advertisementRepository.UpdateAdvertisement(advertisement);
            return advertisement.ToAdvertisementResponse();
        }

        public async Task<AdvertisementResponse?> UpdateAvertisementByCompany(AdvertisementCompanyUpdateDTO? companyAdUpdate)
        {
            if (companyAdUpdate == null) return null;

            ValidationHelper.ModelValidation(companyAdUpdate);

            Advertisement? advertisement = await _advertisementRepository.GetAdvertisementByID(companyAdUpdate.AdvertisementID);
            if (advertisement == null) return null;
            advertisement.IsVerified = null;
            advertisement.NotVerificationDescription = null;
            advertisement.Title = companyAdUpdate.Title; advertisement.LeastAcademicDegree = companyAdUpdate.AcademicDegree.ToString();
            advertisement.LeastYearsOfExperience = companyAdUpdate.LeastYearsOfExperience;
            advertisement.SalaryID = companyAdUpdate.SalaryAmountID; advertisement.CityId = companyAdUpdate.CityID;
            advertisement.Description = companyAdUpdate.Description; advertisement.Gender = companyAdUpdate.Gender.ToString();
            advertisement.TypeOfCooperation = companyAdUpdate.CooperationType.ToString();
            advertisement.JobCategoryId = companyAdUpdate.JobCategoryID; advertisement.MilitaryServiceStatus = companyAdUpdate.MilitaryServiceStatus;
            advertisement.EditionStatus = companyAdUpdate.EditionStatus;

            await _advertisementRepository.UpdateAdvertisement(advertisement);
            return advertisement.ToAdvertisementResponse();
        }
    }
}
