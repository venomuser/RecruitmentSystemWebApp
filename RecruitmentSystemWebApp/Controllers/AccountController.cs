using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.Text.Encodings.Web;

namespace RecruitmentSystemWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISenderEmail _emailSender;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ISenderEmail emailSender, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        //[AllowAnonymous]
        [Authorize("NoAccessForAuth")]
        public IActionResult AdminOrCompany()
        {
            return View();
        }


        [AllowAnonymous]
        public async Task<IActionResult> IsEmailValid(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {

                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [Authorize("NoAccessForAuth")]
        [HttpGet]
        public IActionResult CompanyRegister()
        {
            return View();
        }

        [Authorize("NoAccessForAuth")]
        [HttpPost]
        public async Task<IActionResult> CompanyRegister(CompanyRegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var companyUser = new Company()
                {
                    Email = registerDTO.CompanyEmail,
                    CompanyName = registerDTO.CompanyName,
                    UserName = registerDTO.CompanyEmail,
                    PhoneNumber = registerDTO.CompanyPhone
                };

                var result = await _userManager.CreateAsync(companyUser, registerDTO.Password);
                if (result.Succeeded)
                {
                    if(await _roleManager.FindByNameAsync("CompanyUser") is null)
                    {
                        ApplicationRole applicationRole = new()
                        {
                            Name = "CompanyUser"
                        };
                        await _roleManager.CreateAsync(applicationRole);
                    }

                    await _userManager.AddToRoleAsync(companyUser, "CompanyUser");

                    return View("RegistrationSuccessful");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(registerDTO);
        }

        [AllowAnonymous]
        private async Task SendConfirmationEmail(string? email, ApplicationUser? user)
        {
            //Generate the Token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //Build the Email Confirmation Link which must include the Callback URL
            var ConfirmationLink = Url.Action("ConfirmEmail", "Account",
            new { UserId = user.Id, Token = token }, protocol: HttpContext.Request.Scheme);
            //Send the Confirmation Email to the User Email Id
            await _emailSender.SendEmailAsync(email, "سیستم ثبت آگهی استخدام", $"با سلام. لطفا با کلیک کردن روی لینک زیر، ثبت نام و صحت ایمیل خود را تأیید کنید. با تشکر.<a href='{HtmlEncoder.Default.Encode(ConfirmationLink)}'>تأیید ثبت نام</a>.", true);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                ViewBag.Message = "لینک منقضی شده یا نامعتبر است!";
            }

            //Find the User By Id
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                ViewBag.ErrorMessage = "شناسه کاربر نامعتبر است!";
                //return View("NotFound");
                return NotFound(ViewBag.ErrorMessage);
            }

            //Call the ConfirmEmailAsync Method which will mark the Email as Confirmed
            var result = await _userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
            {
                ViewBag.Message = "صحت ایمیل شما تأیید شد. با تشکر.";
                return View();
            }

            ViewBag.Message = "صحت ایمیل نمی تواند تأیید شود!";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResendConfirmationEmail(bool IsResend = true)
        {
            if (IsResend)
            {
                ViewBag.Message = "ارسال دوباره تأیید ایمیل";
            }
            else
            {
                ViewBag.Message = "ارسال تأیید ایمیل";
            }
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
       
        public async Task<IActionResult> ResendConfirmationEmail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null || await _userManager.IsEmailConfirmedAsync(user))
            {
                // Handle the situation when the user does not exist or Email already confirmed.
                // For security, don't reveal that the user does not exist or Email is already confirmed
                return View("ConfirmationEmailSent");
            }

            //Then send the Confirmation Email to the User
            await SendConfirmationEmail(Email, user);

            return View("ConfirmationEmailSent");
        }

    }
}
