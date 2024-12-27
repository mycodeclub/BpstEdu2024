using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.NewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Staff.Controllers
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
        public async Task<IActionResult> Dashboard()
        {
            var allRegistrations = await _context.Applications.Include(r => r.Course).Include(r => r.ApplicationStatus).ToListAsync();
            var batches = await _context.Batchs.Include(b => b.Course).ToListAsync();
            ViewBag.registrationsByCourse = allRegistrations.GroupBy(r => r.Course).ToDictionary(g => g.Key, g => g.Count());
            ViewBag.registrationsByStatus = allRegistrations.GroupBy(r => r.ApplicationStatus).ToDictionary(g => g.Key, g => g.Count());
            return View(batches);
        }


        public async Task<IActionResult> GetApplicationPartials(int _statusId, int _courseId)
        {
            List<StudentApplication> registrations;
            if (_courseId > 0 && _statusId > 0)
                registrations = await _context.Applications
                    .Include(r => r.Course)
                    .Include(r => r.ApplicationStatus)
                    .Where(a => a.StatusId == _statusId && a.CourseId == _courseId)
                    .ToListAsync();
            else if (_courseId > 0)
                registrations = await _context.Applications
                 .Include(r => r.Course)
                 .Include(r => r.ApplicationStatus)
                 .Where(a => a.CourseId == _courseId)
                 .ToListAsync();

            else if (_statusId > 0)
                registrations = await _context.Applications
                 .Include(r => r.Course)
                 .Include(r => r.ApplicationStatus)
                 .Where(a => a.StatusId == _statusId)
                 .ToListAsync();
            else
                registrations = await _context.Applications
                 .Include(r => r.Course)
                 .Include(r => r.ApplicationStatus)
                 .ToListAsync();
            return PartialView(registrations);
        }

        public async Task<IActionResult> DashboardOld(int id)
        {
            var allRegistrations = await _context.Applications.Include(r => r.Course).ToListAsync();
            var registrations = id == 0 ? allRegistrations : allRegistrations.Where(r => r.CourseId == id);
            var _courses = await _context.Courses.ToListAsync();
            var _applicationStatus = await _context.ApplicationStatus.ToListAsync();

            var applicationsByCourse = new List<KeyValuePair<string, int>>();
            var applicationsByStatus = new List<KeyValuePair<string, int>>();
            foreach (var c in _courses)
            {
                var _count = allRegistrations.Where(r => r.CourseId == c.UniqueId).Count();
                applicationsByCourse.Add(new KeyValuePair<string, int>(c.Name, _count));
            }
            foreach (var s in _applicationStatus)
            {
                var _count = allRegistrations.Where(r => r.StatusId == r.UniqueId).Count();
                applicationsByStatus.Add(new KeyValuePair<string, int>(s.RegistrationStatus, _count));
            }
            ViewBag.Courses = _courses;
            ViewBag.applicationsByCourse = applicationsByCourse;
            return View(registrations);
            return View();
        }

        public async Task<IActionResult> EnrollToBatch(int _statusId, int _courseId, int _batchId)
        {
            var _applications = await _context.Applications
                    .Include(r => r.Course)
                    .Include(r => r.ApplicationStatus)
                    .Where(a => a.StatusId == _statusId && a.CourseId == _courseId)
                    .ToListAsync();
            return View(_applications);
        }
    }
}
