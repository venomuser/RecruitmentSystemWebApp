using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystemWebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class GeneralController : Controller
    {
        [Route("/")]
        public async Task<IActionResult> Home()
        {
            return View();
        }
    }
}
