using Microsoft.AspNetCore.Mvc;

namespace BpstEducation.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
