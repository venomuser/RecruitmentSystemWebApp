using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILocationService _locationService;

        public HomeController(IJobCategoryService jobCategoryService, IAdvertisementService advertisementService, UserManager<ApplicationUser> userManager, ILocationService locationService)
        {
            _jobCategoryService = jobCategoryService;
            _advertisementService = advertisementService;
            _userManager = userManager;
            _locationService = locationService;
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
                if (user != null)
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
        public async Task<IActionResult> AddAdvertisement()
        {
            List<ProvinceResponse> provinces = await _locationService.GetAllProvinces();
            ViewBag.AllProvinces = provinces.Select(temp => new SelectListItem()
            {
                Text = temp.ProvinceName,
                Value = temp.ProvinceId.ToString()
            });

            List<SalaryResponse> salaries = await _locationService.GetAllSalaryCases();
            ViewBag.Salaries = salaries.Select(temp => new SelectListItem()
            {
                Text = temp.SalaryName,
                Value = temp.SalaryId.ToString()
            });

            List<JobCategoryResponse?> jobCategories = await _jobCategoryService.GetAllJobsAsync();
            ViewBag.JobCategories = jobCategories.Select(temp => new SelectListItem()
            {
                Text = temp?.CategoryName,
                Value = temp?.CategoryId.ToString()
            });
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCitiesByProvince(int provinceId)
        {
            var cities = await _locationService.GetCitiesByProvinceID(provinceId);
            var getCities = cities.Select(c => new
            {
                CityID = c.CityId,
                CityName = c.CityName
            });

            return Json(getCities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdvertisement(AdvertisementAddRequest advertisementAdd)
        {
            Company user = (Company)await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {

                if (user != null)
                {
                    advertisementAdd.CompanyID = user.Id;

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "شناسه کاربر ثبت کننده نامعتبر است");
                    return View(advertisementAdd);
                }

                AdvertisementResponse? response = await _advertisementService.AddAdvertisement(advertisementAdd);
                if (response == null)
                {
                    ModelState.AddModelError(string.Empty, "خطا در ثبت آگهی!");
                    return View(advertisementAdd);
                }
                else
                {
                    return RedirectToAction(nameof(CompanyPanel), "Home", new { area = "CompanyArea" });
                }
            }

            ModelState.AddModelError(string.Empty, "خطا در ثبت آگهی!");
            return View(advertisementAdd);
        }


        public async Task<IActionResult> ReviewAdvertisement(Guid? Ad)
        {
            if (Ad == null)
            {
                return NotFound();
            }
            Company user = (Company)await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(Ad);
            if (response == null)
            {
                return NotFound();
            }
            if (response.CompanyID != user.Id)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }

            return View(response);


        }

        [HttpGet]
        public async Task<IActionResult> EditAdvertisement(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Company user = (Company)await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(Id);
            if (response == null)
            {
                return NotFound();
            }
            if (response.CompanyID != user.Id)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }

            List<ProvinceResponse> provinces = await _locationService.GetAllProvinces();
            ViewBag.AllProvinces = provinces.Select(temp => new SelectListItem()
            {
                Text = temp.ProvinceName,
                Value = temp.ProvinceId.ToString()
            });

            List<SalaryResponse> salaries = await _locationService.GetAllSalaryCases();
            ViewBag.Salaries = salaries.Select(temp => new SelectListItem()
            {
                Text = temp.SalaryName,
                Value = temp.SalaryId.ToString()
            });

            List<JobCategoryResponse?> jobCategories = await _jobCategoryService.GetAllJobsAsync();
            ViewBag.JobCategories = jobCategories.Select(temp => new SelectListItem()
            {
                Text = temp?.CategoryName,
                Value = temp?.CategoryId.ToString()
            });

            AdvertisementCompanyUpdateDTO updateDTO = response.ToCompanyUpdateDTO();
            return View(updateDTO);

        }

        [HttpPost]
        public async Task<IActionResult> EditAdvertisement(AdvertisementCompanyUpdateDTO updateDTO)
        {
            if (updateDTO.AdvertisementID == null)
            {
                return NotFound();
            }
            Company user = (Company)await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(updateDTO.AdvertisementID);
            if (response == null)
            {
                return NotFound();
            }
            if (response.CompanyID != user.Id)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }

            if (!ModelState.IsValid)
            {
                List<ProvinceResponse> provinces = await _locationService.GetAllProvinces();
                ViewBag.AllProvinces = provinces.Select(temp => new SelectListItem()
                {
                    Text = temp.ProvinceName,
                    Value = temp.ProvinceId.ToString()
                });

                List<SalaryResponse> salaries = await _locationService.GetAllSalaryCases();
                ViewBag.Salaries = salaries.Select(temp => new SelectListItem()
                {
                    Text = temp.SalaryName,
                    Value = temp.SalaryId.ToString()
                });

                List<JobCategoryResponse?> jobCategories = await _jobCategoryService.GetAllJobsAsync();
                ViewBag.JobCategories = jobCategories.Select(temp => new SelectListItem()
                {
                    Text = temp?.CategoryName,
                    Value = temp?.CategoryId.ToString()
                });


                return View(updateDTO);
            }
            else
            {
                AdvertisementResponse? updateResponse = await _advertisementService.UpdateAvertisementByCompany(updateDTO);
                if (response == null)
                {
                    ModelState.AddModelError(string.Empty, "خطا در ثبت آگهی!");
                    return View(updateDTO);
                }
                else
                {
                    return RedirectToAction(nameof(CompanyPanel), "Home");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAdvertisement(Guid? RemoveAd)
        {
            if (RemoveAd == null)
            {
                return NotFound();
            }
            Company user = (Company)await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(RemoveAd);
            if (response == null)
            {
                return NotFound();
            }
            if (response.CompanyID != user.Id)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdvertisement(AdvertisementCompanyUpdateDTO updateDTO)
        {
            if (updateDTO.AdvertisementID == null)
            {
                return NotFound();
            }
            Company user = (Company)await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(updateDTO.AdvertisementID);
            if (response == null)
            {
                return NotFound();
            }
            if (response.CompanyID != user.Id)
            {
                return RedirectToAction(nameof(CompanyPanel), "Home");
            }

            bool isDeleted = await _advertisementService.RemoveAdvertisement(updateDTO.AdvertisementID);
            if (isDeleted)
            {
                return RedirectToAction(nameof(AllAdvertisements), "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "خطا در حذف آگهی!");
                return View(response);
            }
        }



    }
}
