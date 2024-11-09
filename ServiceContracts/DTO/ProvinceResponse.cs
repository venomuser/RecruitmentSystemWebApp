using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class ProvinceResponse
    {
        public int ProvinceId { get; set; }
        public string? ProvinceName { get; set; }
    }

    public class CityResponse
    {
        public long CityId { get; set; }
        public string? CityName { get; set; }
        public int? ProvinceId { get; set; }
    }

    public class SalaryResponse
    {
        public int SalaryId { get; set; }
        public string? SalaryName { get; set; }
    }

    public static class ProvinceExtensions
    {
        public static ProvinceResponse ToProvinceResponse( this Province province)
        {
            return new ProvinceResponse()
            {
                ProvinceId = province.Id,
                ProvinceName = province.ProvinceName,
            };
        }
    }

    public static class CityExtensions
    {
        public static CityResponse ToCityResponse(this City city)
        {
            return new CityResponse()
            {
                CityId = city.Id.Value,
                CityName = city.CityName,
                ProvinceId = city.ProvinceId.Value
            };
        }
    }

    public static class SalaryExtensions
    {
        public static SalaryResponse ToSalaryResponse(this SalaryAmount salaryAmount)
        {
            return new SalaryResponse()
            {
                SalaryId = salaryAmount.Id,
                SalaryName =salaryAmount.SalaryExplanation
            };
        }
    }
}
