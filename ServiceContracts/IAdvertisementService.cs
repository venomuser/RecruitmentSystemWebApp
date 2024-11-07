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
        /// <summary>
        /// Adding an Advertisement object to database
        /// </summary>
        /// <param name="adReqest">Advertisement Addition DTO</param>
        /// <returns>AdvertisementResponse object which has been added in this method</returns>
        Task<AdvertisementResponse> AddAdvertisement(AdvertisementAddRequest? adReqest);

        /// <summary>
        /// Advertisement modification that the Company has accopolished
        /// </summary>
        /// <param name="companyAdUpdate">AdvertisementUpdateDTO, specified for company</param>
        /// <returns></returns>
        Task<AdvertisementResponse> UpdateAvertisementByCompany(AdvertisementCompanyUpdateDTO companyAdUpdate);

        /// <summary>
        /// Admin can only confirm or reject the added or modified advertisement
        /// </summary>
        /// <param name="adminAdUpdate">An advertisement DTO provided for Admin to confirm or reject</param>
        /// <returns>Object of this which modified by Admin</returns>
        Task<AdvertisementResponse> UpdateAdvertisementByAdmin(AdvertisementAdminUpdateDTO adminAdUpdate);

        /// <summary>
        /// Advertisement deletion, by company exactly.
        /// </summary>
        /// <param name="adID">ID of the advertisement which is supposed to be deleted</param>
        /// <returns>True if dleted. Otherwise, false</returns>
        Task<bool> RemoveAdvertisement(Guid adID);

        /// <summary>
        /// Ultimaetely approved advertisements to be shown in the main page of the web app
        /// </summary>
        /// <returns>List of verified advertisements</returns>
        Task<List<AdvertisementResponse>> GetVerifiedAdvertisements();

        /// <summary>
        /// The advertisements which are newly created or modifed and not verified by admin yet. This method is only for Admin users.
        /// </summary>
        /// <returns>List of not verified advertisements</returns>
        Task<List<AdvertisementResponse>> GetNotVerifiedAdvertisements();

        /// <summary>
        /// All of the advetisements that the specifed company has created
        /// </summary>
        /// <param name="companyID">The specific company ID to show their Ads</param>
        /// <returns>List of a specific company's advertisements</returns>
        Task<List<AdvertisementResponse>> GetAdvertisementsByCompanyID(Guid companyID);

        /// <summary>
        /// Gets a specific advertisement by its ID
        /// </summary>
        /// <param name="Id">ID of the specific advertisement</param>
        /// <returns>An object of AdvertsiementResponse which mathces with the given ID</returns>
        Task<AdvertisementResponse> GetAdvertisementByID(Guid? Id);

        /// <summary>
        /// Visitor's wanted topic to search ads. Either in title or in description of ads.
        /// </summary>
        /// <param name="searchTerm">Visitor's wanted topic to search</param>
        /// <returns>List of searched ads</returns>
        Task<List<AdvertisementResponse>> GetSearchedAdvertisements(string? searchTerm);

        /// <summary>
        /// Filtered Ads that may have multiple filters
        /// </summary>
        /// <param name="adList">The list to be filtered</param>
        /// <param name="salaries">Bunch of salary amount filters for the ads list</param>
        /// <param name="cities">cities filter on ads list</param>
        /// <param name="cooperations">Kind of cooperations that the ads list may has</param>
        /// <returns></returns>
        Task<List<AdvertisementResponse>> GetFilteredAdvertisements(List<AdvertisementResponse> adList, List<int?> salaries,
            List<long?> cities, List<CooperationTypeOptions?> cooperations);
    }
}
