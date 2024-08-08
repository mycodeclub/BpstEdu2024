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

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel rvm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new AppUser { UserName = rvm.Email, Email = rvm.Email, PhoneNumber = rvm.PhoneNumber };
        //        var result = await _userManager.CreateAsync(user, rvm.Password);
        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, isPersistent: false).ConfigureAwait(false);
        //            await _userManager.AddToRoleAsync(user, "Admin").ConfigureAwait(false);
        //            return RedirectToAction("Index", "Home", new { Areas = "Admin" }); 
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(rvm);
        //}

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
                    var user = await _userManager.FindByNameAsync(model.LoginName);
                    var role = await _userManager.GetRolesAsync(user); 
                    if (role.Contains("Admin")) return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    else if (role.Contains("Staff")) return RedirectToAction("Index", "Home", new { Area = "Staff" });
                    else if (role.Contains("Student")) return RedirectToAction("Index", "Home", new { Area = "Student" });
                    
                    return RedirectToAction("Index", "Home");
                }
                else { ModelState.AddModelError("", "Invalid Email Id or Password"); }
            }
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpldateLoggedInUserPassword(model.NewEmail, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    // Handle success, such as redirecting to a confirmation page
                    return RedirectToAction("Index", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
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
                var appUser = new AppUser() { UserName = "admin@bpst.com", Email = "admin@bpst.com", Password = "Admin@bpst.com", ConfirmPassword = "Admin@bpst.com", PhoneNumber = "9999999999", };
                var result = await _userManager.CreateAsync(appUser, appUser.Password);
                if (result.Succeeded)
                {
                    var userRoles = await _context.Roles.ToListAsync();
                    foreach (var role in userRoles)
                        await _userManager.AddToRoleAsync(appUser, role.Name).ConfigureAwait(false);
                    resultStr = "Master User Created Successfully.";
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        resultStr += "Some Error: " + error.Code;
                    }
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
            var result = await _signInManager.PasswordSignInAsync("admin@bpst.com", "Admin@bpst.com", true, lockoutOnFailure: false);
            if (result.Succeeded)
                return RedirectToAction("DashBoard", "Students", new { area = "Admin" });
            else
                return RedirectToAction("CreateMasterUser");
        }
    }
}