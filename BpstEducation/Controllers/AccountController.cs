using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BpstEducation.Models;
using BpstEducation.ViewModels;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Services;
using System;

namespace BpstEducation.Controllers
{
    [AllowAnonymous]

    //[Authorize(Roles = "Staff,Admin,Student")]

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

        [Authorize(Roles = "Staff,Admin,Student")]

        public async Task<IActionResult> ChangePassword()
        {
            ViewBag.Layout =  _userService.GetLayout();
            return View();
        }
        [Authorize(Roles = "Staff,Admin,Student")]

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UpdatePassword model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpldateLoggedInUserPassword(model.NewEmail, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction(ViewBag.Layout);

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            ViewBag.Layout =  _userService.GetLayout();
            return View(model);
        }
        [Authorize(Roles = "Staff,Admin,Student")]

        [HttpGet]
        public async Task<IActionResult> ChangeEmail()
        {
            var emailUpdate = new UpdateEmailVM() { };
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                emailUpdate.OldEmail = user.Email;
            }
            ViewBag.Layout =  _userService.GetLayout();
            return View(emailUpdate);
        }
        [Authorize(Roles = "Staff,Admin,Student")]

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(UpdateEmailVM updateEmail)
        {
            var result = await _userService.UpldateLoggedInUserEmail(updateEmail);
            ViewBag.Layout =  _userService.GetLayout();
            return View(updateEmail);
        }





        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> CreateMasterUser()        
        {
            var errorStr = string.Empty;
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
                    if (error.Code == "DuplicateUserName")
                        return RedirectToAction("AutoLogin");
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        errorStr += "Some Error: " + error.Code;
                    }
                }
            }
            catch (Exception ex)
            {
                errorStr = "Some Error: " + ex.Message;
            }
            if (string.IsNullOrWhiteSpace(errorStr))
                return RedirectToAction("AutoLogin");
            return RedirectToAction("Login");
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