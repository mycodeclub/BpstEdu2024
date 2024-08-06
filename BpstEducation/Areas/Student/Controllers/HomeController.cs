using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly int StudentId;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public async Task<IActionResult> Profile()
        {
            //  var stu = await _context.students.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();
            var stu = await GetLoggedInUser();
            return View(stu);
        }
        public async Task<IActionResult> Course()
        {
            var stu = await GetLoggedInUser(); 
            return View(stu.CourseCategory);
        }
        public async Task<IActionResult> Fees()
        {
            var stu = await _context.Fees.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();

            return View(stu);
        }

        private async Task<Students> GetLoggedInUser()
        {
            var stu = await _context.students.Where(s => s.CourseCategoryID > 0 && s.BatchId > 0)
                .Include(s => s.CourseCategory)
                .Include(s => s.Batch)
                .FirstOrDefaultAsync();
            return stu;
        }
    }
}
