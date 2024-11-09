using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;


namespace RecruitmentSystemWebApp.Filters
{
    public class EmailMatchAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var emailClaim = user.FindFirst(ClaimTypes.Email)?.Value;

            if (!string.IsNullOrEmpty(emailClaim))
            {
                var requestEmail = context.HttpContext.Request.Query["UserEmail"].ToString();
                if (!string.Equals(emailClaim, requestEmail, StringComparison.OrdinalIgnoreCase))
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

}
