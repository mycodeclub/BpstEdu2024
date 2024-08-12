using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using BpstEducation.Models;
using System.Threading.Tasks;
using BpstEducation.ViewModels;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Services;

namespace BpstEducation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IUserServiceBAL _userService;
        public AccountController(
           UserManager<AppUser> userManager,
           SignInManager<AppUser> signInManager, AppDbContext context, IUserServiceBAL userService
           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _userService = userService;

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

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return await ReDirectIfLoggedIn();

        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.LoginName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                    return await ReDirectIfLoggedIn();
                else { ModelState.AddModelError("", "Invalid Email Id or Password"); }
            }
            return View(model);
        }

        public async Task<IActionResult> ReDirectIfLoggedIn()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(user);

                if (role.Contains("Admin")) return RedirectToAction("Index", "Home", new { Area = "Admin" });
                else if (role.Contains("Staff")) return RedirectToAction("Index", "Home", new { Area = "Staff" });
                else if (role.Contains("Student")) return RedirectToAction("Index", "Home", new { Area = "Student" });
                else return View("Login");
            }
            else
                return View("Login");// RedirectToAction("Login", "Account");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UpdatePassword model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpldateLoggedInUserPassword(model.NewEmail, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Admin");

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //-------------------------- 
        public async Task<IActionResult> CreateMasterUser()
        {
            var resultStr = string.Empty;
            try
            {
                var appUser = new AppUser()
                {
                    UserName = "admin@bpst.com",
                    Email = "admin@bpst.com",
                    Password = "admin@bpst.com",
                    ConfirmPassword = "admin@bpst.com",
                    PhoneNumber = "9999999999",
                };
                var userRoles = await _context.Roles.Select(r => r.Name).ToListAsync();
                var result = await _userService.AddUser(appUser, userRoles);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    resultStr += "Some Error: " + error.Code;
                }
            }
            catch (Exception ex)
            {
                resultStr = "Some Error: " + ex.Message;
            }
            return RedirectToAction("AutoLogin");
        }
        public async Task<IActionResult> AutoLogin()
        {
            var result = await _signInManager.PasswordSignInAsync("admin@bpst.com", "admin@bpst.com", true, lockoutOnFailure: false);
            if (result.Succeeded)
                return await ReDirectIfLoggedIn();
            else
                return RedirectToAction("CreateMasterUser");
            return RedirectToAction("Index", "Home");
        }
    }
}