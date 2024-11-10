using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace RecruitmentSystemWebApp.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class GeneralController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdvertisementService _advertisementService;
        private readonly ILocationService _locationService;

        public GeneralController(UserManager<ApplicationUser> userManager, IAdvertisementService advertisementService, ILocationService locationService)
        {
            _userManager = userManager;
            _advertisementService = advertisementService;
            _locationService = locationService;
        }

        [Route("[action]")]
        [Route("/")]
        public async Task<IActionResult> Home()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("CompanyUser"))
                {
                    Company company = (Company)await _userManager.FindByNameAsync(User.Identity.Name);
                    ViewBag.Avatar = company.AvatarAddress;
                }
            }

            ViewBag.Result = await _advertisementService.GetVerifiedAdvertisements();
            AdvertisementFiltersDTO filtersDTO = new AdvertisementFiltersDTO();

            var salaryObjects = await _locationService.GetAllSalaryCases();
            filtersDTO.Salaries = salaryObjects.Select(temp => temp.SalaryId).ToList();
            filtersDTO.SalaryNames = salaryObjects.Select(temp => temp.SalaryName).ToList();

            var cityObject = await _locationService.GetAllCities();
            filtersDTO.Cities = cityObject.Select(temp => temp.CityId).ToList();
            filtersDTO.CityNames = cityObject.Select(temp => temp?.CityName).ToList();



            return View(filtersDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Searching(AdvertisementFiltersDTO filterDTO)
        {
            List<AdvertisementResponse> advertisements = await _advertisementService.GetVerifiedAdvertisements();
            var filteredAds = await _advertisementService.GetFilteredAdvertisements(advertisements, filterDTO.Salaries, filterDTO.Cities, filterDTO.CooperationTypes);
            var resultAds = filteredAds;
            if (!string.IsNullOrEmpty(filterDTO.SearchString))
            {
                var searchedAds = await _advertisementService.GetSearchedAdvertisements(filteredAds,filterDTO.SearchString);
                resultAds = searchedAds;
            }

            ViewBag.Result = resultAds;

            var salaryObjects = await _locationService.GetAllSalaryCases();
            filterDTO.Salaries = salaryObjects.Select(temp => temp.SalaryId).ToList();
            filterDTO.SalaryNames = salaryObjects.Select(temp => temp.SalaryName).ToList();

            var cityObject = await _locationService.GetAllCities();
            filterDTO.Cities = cityObject.Select(temp => temp.CityId).ToList();
            filterDTO.CityNames = cityObject.Select(temp => temp?.CityName).ToList();
            return View("Home",filterDTO);
        }

        public async Task<IActionResult> ViewAdvertisement(Guid? Ad)
        {
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(Ad);
            if (response == null)
            {
                return NotFound();
            }
            if(response.IsVerified != true)
            {
                return RedirectToAction(nameof(Home), "General");
            }

            return View(response);
        }



    }
}
