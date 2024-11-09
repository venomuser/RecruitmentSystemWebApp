using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace RecruitmentSystemWebApp.Areas.CompanyArea.Controllers
{

    [Area("CompanyArea")]
    [Authorize(Roles = "CompanyUser")]
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

        [HttpGet]
        public IActionResult AddCategories()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategories(JobCategoryAddRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity?.Name);
                if(user != null)
                {
                    request.UserID = user.Id;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "شناسه کاربر ثبت کننده نامعتبر است");
                    return View(request);
                }

                Message message = await _jobCategoryService.JobAddAsync(request);
                if (!message.Success.Value)
                {
                    ModelState.AddModelError(string.Empty, message.OperationMessage);
                    return View(request);
                }
                else
                {
                    ViewBag.SuccessMessage = message.OperationMessage;
                    return View();
                }
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategories()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity?.Name);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "شناسه کاربر ثبت کننده نامعتبر است");
                return View();
            }
            else
            {
                ViewBag.Categories = await _jobCategoryService.GetJobCategoryByCompanyId(user.Id);
                return View();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> EditCategories(JobCategoryUpdateRequest request)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity?.Name);
            if (ModelState.IsValid)
            {
                
                if (user != null)
                {
                    request.UserID = user.Id;
                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "شناسه کاربر ثبت کننده نامعتبر است");
                    return View(request);
                }

                Message message = await _jobCategoryService.JobUpdateAsync(request);
                if (!message.Success.Value)
                {
                    ModelState.AddModelError(string.Empty, message.OperationMessage);
                    return View(request);
                }
                else
                {
                    ViewBag.SuccessMessage = message.OperationMessage;
                    ViewBag.Categories = await _jobCategoryService.GetJobCategoryByCompanyId(user.Id);

                    return View();
                }
            }
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "شناسه کاربر ثبت کننده نامعتبر است");
                return View(request);
            }

            ViewBag.Categories = await _jobCategoryService.GetJobCategoryByCompanyId(user.Id);
            return View(request);
        }

        [HttpGet]
        public IActionResult AddAdvertisement()
        {
            return View();
        }




    }
}
