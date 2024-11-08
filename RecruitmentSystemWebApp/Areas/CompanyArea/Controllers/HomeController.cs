using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystemWebApp.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [Authorize(Roles ="CompanyUser")]
    public class HomeController : Controller
    {
        public IActionResult CompanyPanel()
        {
            return View();
        }

        
    }
}
