using BpstEducation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Staff
{
    [Area("Staff")]
    public class ApplicationsController : Controller
    {
        private readonly AppDbContext _context;

        public ApplicationsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> Dashboard(int id)
        {
            var allRegistrations = await _context.Applications.Include(r => r.Course).ToListAsync();
            var registrations = (id == 0) ? allRegistrations : allRegistrations.Where(r => r.CourseId == id);
            var _courses = await _context.Courses.ToListAsync();

            var applicationsByCourse = new List<KeyValuePair<string, int>>();
            foreach (var c in _courses)
            {
                var _count = allRegistrations.Where(r => r.CourseId == c.UniqueId).Count();
                applicationsByCourse.Add(new KeyValuePair<string, int>(c.Name, _count));
            }
            ViewBag.Courses = _courses;
            ViewBag.applicationsByCourse = applicationsByCourse;
            return View(registrations);
            return View();
        }
    }
}
