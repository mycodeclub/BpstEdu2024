using Microsoft.AspNetCore.Mvc;

namespace BpstEducation.Areas.Faculty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
