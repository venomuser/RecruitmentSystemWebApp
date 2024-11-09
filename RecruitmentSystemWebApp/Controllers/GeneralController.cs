using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystemWebApp.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class GeneralController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public GeneralController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("[action]")]
        [Route("/")]
        public async Task<IActionResult> Home()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("CompanyUser"))
                {
                    Company company = (Company) await _userManager.FindByNameAsync(User.Identity.Name);
                    ViewBag.Avatar = company.AvatarAddress;
                }
            }
            return View();
        }
    }
}
