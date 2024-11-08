using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystemWebApp.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class GeneralController : Controller
    {
        [Route("[action]")]
        [Route("/")]
        public async Task<IActionResult> Home()
        {
            return View();
        }
    }
}
