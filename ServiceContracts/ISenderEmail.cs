using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ISenderEmail
    {
        Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false);
    }
}
