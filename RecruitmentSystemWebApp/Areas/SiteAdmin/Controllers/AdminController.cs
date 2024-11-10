using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace RecruitmentSystemWebApp.Areas.SiteAdmin.Controllers
{
    [Area("SiteAdmin")]
    [Authorize(Roles = "SiteAdmin")]
    public class AdminController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public AdminController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public async Task<IActionResult> ControlAds()
        {
            List<AdvertisementResponse> advertisements = await _advertisementService.GetNotVerifiedAdvertisements();
            return View(advertisements);
        }

        [HttpGet]
        public async Task<IActionResult> EditAdvertisement(Guid? Ad)
        {
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(Ad);
            if (response == null)
            {
                return NotFound();
            }

            ViewBag.Response = response;


            AdvertisementAdminUpdateDTO updateDTO = response.ToAdminUpdateDTO();
            return View(updateDTO);
        }

        public async Task<IActionResult> EditAdvertisement(AdvertisementAdminUpdateDTO updateDTO)
        {
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(updateDTO.AdvertisementID);
            if (updateDTO == null)
            {
                ViewBag.Response = response;
                ModelState.AddModelError(string.Empty, "آگهی مورد نظر یافت نشد!");
                AdvertisementAdminUpdateDTO dto = response.ToAdminUpdateDTO();
                return View(dto);
            }

            if (updateDTO.IsVerified == false && string.IsNullOrEmpty(updateDTO.NoVerificationDescription))
            {
                ModelState.AddModelError(string.Empty, "در صورت رد آگهی، حتماً دلیل آن را هم بنویسید.");
                ViewBag.Response = response;
                AdvertisementAdminUpdateDTO dto = response.ToAdminUpdateDTO();
                return View(dto);
            }

            if (updateDTO.EditionStatus != response.EditionStatus)
            {
                ModelState.AddModelError(string.Empty, "این آگهی قبل از بررسی کامل شما ویرایش شده است! لطفاً آن را دوباره بررسی کنید.");
                ViewBag.Response = response;
                AdvertisementAdminUpdateDTO dto = response.ToAdminUpdateDTO();
                return View(dto);
            }

            AdvertisementResponse? resultResponse = await _advertisementService.UpdateAdvertisementByAdmin(updateDTO);
            if (resultResponse == null)
            {
                ViewBag.Response = response;
                ModelState.AddModelError(string.Empty, "آگهی مورد نظر یافت نشد!");
                AdvertisementAdminUpdateDTO dto = response.ToAdminUpdateDTO();
                return View(dto);
            }
            else
            {
                return RedirectToAction(nameof(ControlAds), "Admin");
            }


        }

        public async Task<IActionResult> SuspendAdvertisement(Guid? SuspendAd)
        {
            AdvertisementResponse? response = await _advertisementService.GetAdvertisementByID(SuspendAd);
            if (response == null)
            {
                return NotFound();
            }
            AdvertisementAdminUpdateDTO? updateDTO = response.ToAdminUpdateDTO();
            updateDTO.IsVerified = null;
            AdvertisementResponse? resultUpdate = await _advertisementService.UpdateAdvertisementByAdmin(updateDTO);
            if (resultUpdate == null)
            {
                return BadRequest();
            }
            else
            {
                return RedirectToAction(nameof(ControlAds), "Admin");
            }
        }
    }
}
