using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Security.Claims;

namespace BpstEducation.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student,Admin,Staff")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly int StudentId;
        private Models.Student student;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly UserManager<AppUser> _userManager;
        private readonly IUserServiceBAL _userService;


        public HomeController(AppDbContext context, UserManager<AppUser> userManager, IUserServiceBAL userService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

            _userService = userService;

        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var student = await _context.Students.Where(s => s.UniqueId == id).FirstOrDefaultAsync();
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);

            }

        }
        

        //---------------------------------------------------------------------------------------
        public async Task<IActionResult> Create()
        {
            var employee = await _context.Students.ToListAsync();
            student ??= new Models.Student();
            return View(student);
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Student student)
        {
            
            if (ModelState.IsValid)
            {
                if (student.UniqueId == 0)
                {
                    _context.Add(student);
                    var result = await AddLoginDetails(student);
                    if (!result.Succeeded)
                        ModelState.AddModelError("Login Creation Error", string.Join(",", result.Errors.Select(e => { return e.Code + " : " + e.Description; }).ToList()));
                }
                else
                    _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(student);
            }
        }

        //-----------------------------------------------------------------------------------

        private async Task<IdentityResult> AddLoginDetails(Models.Student stu)
        {
            var appUser = new AppUser()
            {
                UserName = stu.Email,
                Email = stu.Email,
                Password = "Bpst@123" + stu.FullName,
                ConfirmPassword = stu.Email,
                PhoneNumber = stu.PhoneNumber
            };
            var result = await _userManager.CreateAsync(appUser, appUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "Admin").ConfigureAwait(false);
                await _userManager.AddToRoleAsync(appUser, "Staff").ConfigureAwait(false);
                await _userManager.AddToRoleAsync(appUser, "Student").ConfigureAwait(false);
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return result;
        }

        //------------------------------------------------------------------------------------------
        public async Task<IActionResult> Profile()
        {
            var StuLogInId = GetLoggedInUser();

            var stu = await _context.Students.Where(s => s.LoginIdGuid == StuLogInId).FirstOrDefaultAsync();
            return View(stu);
        }



        public string GetLoggedInUser()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }



        public async Task<IActionResult> Course()
        {
            var LogInGetid = GetLoggedInUser();
            var student = await _context.Students.Where(s => s.LoginIdGuid.Equals(LogInGetid)).FirstOrDefaultAsync();
            var stucourse = await _context.BatchStudents
                .Include(b => b.Batch)
                .ThenInclude(b => b.Course)
                .Where(bs => bs.StudentId == student.UniqueId)
                .ToListAsync();
            return View(stucourse);
        }
        public async Task<IActionResult> Fees()
        {
            var stu = await _context.Fees.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();

            return View(stu);
        }


    }
}
