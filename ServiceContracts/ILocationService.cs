using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ILocationService
    {
        Task<List<ProvinceResponse>> GetAllProvinces();
        Task<List<CityResponse>> GetCitiesByProvinceID(int provinceID);
        Task<List<CityResponse>> GetAllCities();
        Task<List<SalaryResponse>> GetAllSalaryCases();
    }
}
