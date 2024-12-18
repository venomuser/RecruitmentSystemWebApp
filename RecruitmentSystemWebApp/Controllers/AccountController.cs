﻿using Entities.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystemWebApp.Filters;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.Text.Encodings.Web;

namespace RecruitmentSystemWebApp.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISenderEmail _emailSender;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ISenderEmail emailSender, RoleManager<ApplicationRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
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
                    if (await _roleManager.FindByNameAsync("CompanyUser") is null)
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

        [AllowAnonymous]
        private async Task ResetPasswordConfirmation(string? email, ApplicationUser? user)
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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(GeneralController.Home), "General");
        }

        [HttpGet]
        [Authorize(Roles = "CompanyUser")]
        [ServiceFilter(typeof(EmailMatchAuthorizationFilter))]
        public async Task<IActionResult> CompanyEdit(string? UserEmail)
        {
            if (UserEmail == null)
            {
                return RedirectToAction(nameof(GeneralController.Home), "General");
            }
            Company user = (Company)await _userManager.FindByEmailAsync(UserEmail);
            if (user == null)
            {
                return RedirectToAction(nameof(GeneralController.Home), "General");
            }

            var userUpdate = new CompanyEditDTO()
            {
                UserId = user.Id,
                CompanyEmail = user.Email,
                CompanyName = user.CompanyName,
                CompanyPhone = user.PhoneNumber,
                AvatarAddress = user.AvatarAddress,
                CompanyAddress = user.CompanyAddress,
                CompanyDescription = user.CompanyDescription

            };
            return View(userUpdate);
        }

        [HttpPost]
        [Authorize(Roles = "CompanyUser")]
        //[ServiceFilter(typeof(EmailMatchAuthorizationFilter))]
        public async Task<IActionResult> CompanyEdit(CompanyEditDTO companyEditDTO, IFormFile? avatar)
        {
            if (companyEditDTO == null)
            {
                return BadRequest("مشکلی پیش آمده است");
            }
            Company user = (Company)await _userManager.FindByIdAsync(companyEditDTO.UserId.Value.ToString());
            if (user == null)
            {
                return BadRequest("چنین کاربری پیدا نشد");
            }

            user.Email = companyEditDTO.CompanyEmail;
            user.UserName = companyEditDTO.CompanyEmail;
            user.CompanyAddress = companyEditDTO.CompanyAddress;
            user.PhoneNumber = companyEditDTO.CompanyPhone;
            user.CompanyName = companyEditDTO.CompanyName;
            user.CompanyDescription = companyEditDTO.CompanyDescription;

            if (avatar != null)
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + "/AppUploads"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "/AppUploads");
                }
                Guid avatarName = Guid.NewGuid();
                var fileExtension = Path.GetExtension(avatar.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath + "/AppUploads", avatarName.ToString() + fileExtension);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await avatar.CopyToAsync(stream);
                }
                //user.AvatarAddress = filePath;
                user.AvatarAddress = "/AppUploads/"+ avatarName.ToString() + fileExtension;
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                //Once user data updated redirect to the ListUsers view
                return RedirectToAction("CompanyPanel", "Home", new { area = "CompanyArea" });
            }
            else
            {
                //In case any error, stay in the same view and show the model validation error
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(companyEditDTO);
            }
        }

        [HttpGet]
        [Authorize("NoAccessForAuth")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Authorize("NoAccessForAuth")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    ApplicationUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);
                    if (user != null)
                    {
                        if (await _userManager.IsInRoleAsync(user, "SiteAdmin"))
                        {
                            return RedirectToAction("AdminPanel", "Admin", new
                            {
                                area = "SiteAdmin"
                            });
                        }

                        else if(await _userManager.IsInRoleAsync(user, "CompanyUser"))
                        {
                            return RedirectToAction("CompanyPanel", "Home", new { area = "CompanyArea" });
                        }
                    }
                }
            }
            ModelState.AddModelError("Login", "ایمیل یا رمز عبور نادرست است!");
            return View(loginDTO);
        }

        [HttpGet]
        [Authorize("NoAccessForAuth")]
        public IActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        [Authorize("NoAccessForAuth")]
        public async Task<IActionResult> AdminRegister(AdminRegisterDTO adminRegisterDTO)
        {
            if (ModelState.IsValid)
            {
                SiteAdministrator admin = new()
                {
                    AdminName = adminRegisterDTO.AdminActualName,
                    Email = adminRegisterDTO.AdminEmail,
                    UserName = adminRegisterDTO.AdminEmail
                };

                var result = await _userManager.CreateAsync(admin, adminRegisterDTO.Password);
                if (result.Succeeded)
                {
                    if (await _roleManager.FindByNameAsync("SiteAdmin") is null)
                    {
                        ApplicationRole applicationRole = new()
                        {
                            Name = "SiteAdmin"
                        };
                        await _roleManager.CreateAsync(applicationRole);
                    }

                    await _userManager.AddToRoleAsync(admin, "SiteAdmin");
                    await _signInManager.SignInAsync(admin, isPersistent: false);

                    return RedirectToAction("AdminPanel", "Admin", new { area = "SiteAdmin" });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(adminRegisterDTO);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        private async Task SendForgotPasswordEmail(string? email, ApplicationUser? user)
        {
            // Generate the reset password token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Build the password reset link which must include the Callback URL
            // Build the password reset link
            var passwordResetLink = Url.Action("ResetPassword", "Account",
                    new { Email = email, Token = token }, protocol: HttpContext.Request.Scheme);

            //Send the Confirmation Email to the User Email Id
            await _emailSender.SendEmailAsync(email, "رمز عبورتان را بازنشانی کنید", $"با سلام. اگر رمز عبورتان را فراموش کرده اید و اقدام به بازنشانی رمز عبور کرده اید، روی لینک زیر کلیک کنید. <a href='{HtmlEncoder.Default.Encode(passwordResetLink)}'>برای بازنشانی رمز عبور اینجا را کلیک کنید.</a>.", true);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);

                // If the user is found AND Email is confirmed
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    await SendForgotPasswordEmail(user.Email, user);

                    // Send the user to Forgot Password Confirmation view
                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            return View(forgotPasswordDTO);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string Token, string Email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (Token == null || Email == null)
            {
                ViewBag.ErrorTitle = "توکن بازنشانی رمز نامعتبر";
                ViewBag.ErrorMessage = "لینک منقضی شده یا نامعتبر است";
                return BadRequest("Error");
            }
            else
            {
                ResetPasswordDTO model = new ResetPasswordDTO();
                model.Token = Token;
                model.Email = Email;
                return View(model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ResetPasswordConfirmation", "Account");
                    }

                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
}
