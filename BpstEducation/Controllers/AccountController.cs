using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using BpstEducation.Models;
using System.Threading.Tasks;
using BpstEducation.ViewModels;

namespace BpstEducation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = rvm.Email, Email = rvm.Email, PhoneNumber = rvm.PhoneNumber };
                var result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false).ConfigureAwait(false);
                    await _userManager.AddToRoleAsync(user, "Admin").ConfigureAwait(false);
                    return RedirectToAction("Index", "Home",new { Areas="Admin"});

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(rvm);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.LoginName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else { ModelState.AddModelError("", "Invalid Email Id or Password"); }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}