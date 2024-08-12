using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student,Admin,Staff")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly int StudentId;
        private Students student;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        //---------------------------------------------------------------------------------------
        public async Task<IActionResult> Create()
        {
            var employee = await _context.students.ToListAsync();
            student ??= new Students();
            return View(student);
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Students student)
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

        private async Task<IdentityResult> AddLoginDetails(Students stu)
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
            //  var stu = await _context.students.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();
            var stu = await GetLoggedInUser();
            return View(stu);
        }
        public async Task<IActionResult> Course()
        {
            var stu = await GetLoggedInUser();
            return View(stu.CourseOfInterest);
        }
        public async Task<IActionResult> Fees()
        {
            var stu = await _context.Fees.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();

            return View(stu);
        }

        private async Task<Students> GetLoggedInUser()
        {
            return null;
        }
    }
}
