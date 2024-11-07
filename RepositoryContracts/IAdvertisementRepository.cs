using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IAdvertisementRepository
    {
        Task<Advertisement> CreateAdvertisement(Advertisement advertisement);
        Task<Advertisement> UpdateAdvertisement(Advertisement advertisement);
        Task<bool> DeleteAdvertisement(Guid id);
        Task<List<Advertisement>> GetVerifiedAdvertisements();
        Task<List<Advertisement>> GetNotVerifiedAdvertisements();
        Task<List<Advertisement>> GetAdvertisementsByCompanyID (Guid companyID);
        Task<Advertisement?> GetAdvertisementByID (Guid Id);
    }
}
