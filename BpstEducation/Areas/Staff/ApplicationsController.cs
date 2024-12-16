using BpstEducation.Data;
using BpstEducation.Models;
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
        public async Task<IActionResult> Dashboard(int StatusId, int CourseId)
        {
            var allRegistrations = await _context.Applications.Include(r => r.Course).Include(r => r.ApplicationStatus).ToListAsync();
            var registrations = (CourseId == 0) ? allRegistrations : allRegistrations.Where(r => r.CourseId == CourseId).ToList();
              registrations = (StatusId == 0) ? allRegistrations : allRegistrations.Where(r => r.StatusId == StatusId).ToList();
            var coursesTask = await _context.Courses.ToListAsync();
            var applicationStatusTask = await _context.ApplicationStatus.ToListAsync();
           // await Task.WhenAll(coursesTask, applicationStatusTask);
            var registrationsByCourse = allRegistrations.GroupBy(r => r.Course).ToDictionary(g => g.Key, g => g.Count());
            var registrationsByStatus = allRegistrations.GroupBy(r => r.ApplicationStatus).ToDictionary(g => g.Key, g => g.Count());
            ViewBag.registrationsByCourse = registrationsByCourse;
            ViewBag.registrationsByStatus = registrationsByStatus;

            //var applicationsByCourse = coursesTask.Result.Select(c => new KeyValuePair<string, int>(c.Name, registrationsByCourse.TryGetValue(c.UniqueId, out var count) ? count : 0)).ToList();
            //var applicationsByStatus = applicationStatusTask.Result.Select(s => new KeyValuePair<string, int>(s.RegistrationStatus, registrationsByStatus.TryGetValue(s.UniqueId, out var count) ? count : 0)).ToList();
            return View(registrations);
        }
        public async Task<IActionResult> DashboardOld(int id)
        {
            var allRegistrations = await _context.Applications.Include(r => r.Course).ToListAsync();
            var registrations = (id == 0) ? allRegistrations : allRegistrations.Where(r => r.CourseId == id);
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
    }
}
