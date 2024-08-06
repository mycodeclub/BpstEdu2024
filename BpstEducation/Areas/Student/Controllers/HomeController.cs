using BpstEducation.Data;
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
        private readonly int  StudentId;
        public HomeController(AppDbContext context)
        {
            _context = context;
            StudentId = 1;
          // @ToDo will be replaced by login user id-------------------------------------------------
        }
        public  async Task<IActionResult> Index()
        {
            var stu = await _context.students.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();

            return View(stu);
        }
        public async Task<IActionResult> Course()
        {
            var stu = await _context.students
                .Include(s=>s.CourseCategory)
                .Include(s=>s.Batch)
                .Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();

            return View(stu);
        }
        public async Task<IActionResult>Fees()
        {
            var stu = await _context.Fees.Where(s => s.UniqueId == StudentId).FirstOrDefaultAsync();

            return View(stu);
        }
    }
}
