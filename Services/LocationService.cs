using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LocationService : ILocationService
    {

        private readonly ApplicationDbContext _dbContext;

        public LocationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CityResponse>> GetAllCities()
        {
            List<City> cities = await _dbContext.Cities.ToListAsync();
            return cities.Select(cit => cit.ToCityResponse()).ToList();
        }

        public async Task<List<ProvinceResponse>> GetAllProvinces()
        {
            List<Province> provinces = await _dbContext.Provinces.ToListAsync();
            return provinces.Select(pro => pro.ToProvinceResponse()).ToList();
        }

        public async Task<List<SalaryResponse>> GetAllSalaryCases()
        {
            List<SalaryAmount> salaryAmounts = await _dbContext.SalaryAmounts.ToListAsync();
            return salaryAmounts.Select(sal=>sal.ToSalaryResponse()).ToList();
        }

        public async Task<List<CityResponse>> GetCitiesByProvinceID(int provinceID)
        {
            List<City> cities = await _dbContext.Cities.Where(city=>city.ProvinceId == provinceID).ToListAsync();
            return cities.Select(ci=>ci.ToCityResponse()).ToList();
        }
    }
}
