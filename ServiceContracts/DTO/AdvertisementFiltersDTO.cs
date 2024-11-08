using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class AdvertisementFiltersDTO
    {
        public List<int>? Salaries { get; set; }
        public List<long>? Cities { get; set; }
        public List<CooperationTypeOptions>? CooperationTypes { get; set; }

    }
}
