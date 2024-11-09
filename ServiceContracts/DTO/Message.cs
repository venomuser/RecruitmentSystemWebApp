using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class Message
    {
        public string? OperationMessage { get; set; }
        public bool? Success { get; set; }
        public object? Data { get; set; }
    }
}
