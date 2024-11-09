using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace RecruitmentSystemWebApp.Areas.CompanyArea.Controllers
{

    [Area("CompanyArea")]
    [Authorize(Roles ="CompanyUser")]
    public class HomeController : Controller
    {
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IAdvertisementService _advertisementService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IJobCategoryService jobCategoryService, IAdvertisementService advertisementService, UserManager<ApplicationUser> userManager)
        {
            _jobCategoryService = jobCategoryService;
            _advertisementService = advertisementService;
            _userManager = userManager;
        }


       public IActionResult CompanyPanel()
        {
            return View();
        }

        public async Task<IActionResult> AllAdvertisements()
        {
            Company company = (Company)await _userManager.FindByEmailAsync(User.Identity.Name);
            List<AdvertisementResponse> ads = await _advertisementService.GetAdvertisementsByCompanyID(company.Id);
            return View(ads);
        }

        
    }
}
