using Microsoft.AspNetCore.Mvc;
using BpstEducation.Services;
using BpstEducation.ViewModels;

namespace BpstEducation.Controllers
{
    public class ManageController : Controller
    {
        private readonly IUserServiceBAL _userService;
        public ManageController(IUserServiceBAL userService)
        {
            _userService = userService;
        }

        public IActionResult ChangeEmail()
        {
            return View();
        }

   
    }
}
