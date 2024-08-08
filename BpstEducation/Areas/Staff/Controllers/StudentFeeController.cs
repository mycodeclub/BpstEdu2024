using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Admin")]

    public class StudentFeeController(UserManager<AppUser> userManager, AppDbContext context, IUserServiceBAL loginService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IUserServiceBAL _loggedInUser = loginService;

        public async Task<IActionResult> Index(int id)
        {
            var stu3 = await _context.students.Where(s => s.UniqueId == id).FirstOrDefaultAsync();
            ViewBag.Layout = await _loggedInUser.GetLayout();

            var stu = await _context.students
                .Include(f => f.MySubmittedFeeTillNow)
                .Include(f => f.Batch)
                .Include(f => f.CourseCategory)
                .Where(s => s.UniqueId == id).FirstOrDefaultAsync();
            stu ??= new Students() { UniqueId = id };
            ViewBag.StudentId = id;
            return View(stu);
        }

        public IActionResult Create(int id)
        {
            StudentFee studentfee = new StudentFee() { StudentId = id, CreatedDate = DateTime.UtcNow, FeeSubmittingDate = DateTime.Now };
            return View(studentfee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentFee studentfee)
        {
            if (ModelState.IsValid)
            {
                _context.Fees.Add(studentfee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = studentfee.StudentId });
            }

            return View(studentfee);

        }

    }
}
