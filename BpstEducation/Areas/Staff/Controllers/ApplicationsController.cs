using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.NewModels;
using BpstEducation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class ApplicationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IStudentServiceBAL _studentBal;

        public ApplicationsController(AppDbContext context, IStudentServiceBAL studentBal)
        {
            _context = context;
            _studentBal = studentBal;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Details(int id)
        //{

        //    var data = await _context.Applications.Where(a=>a.UniqueId == id);
        //    return View();
        //}
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id > 0)
            {
                var appls = await _context.Applications.Include(b => b.Course).Where(c => c.UniqueId == id).FirstOrDefaultAsync();
                return View(appls);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateApplication(StudentApplication stuApp)
        {
            var result = false;
            var stuAppDb = await _context.Applications.FindAsync(stuApp.UniqueId);
            stuAppDb.StatusId = stuApp.StatusId;
            stuAppDb.HRComment = stuApp.HRComment;

            await _context.SaveChangesAsync();
            result = true;
            ViewBag.SaveResult = result;
            return View("Details", stuAppDb);
        }
        public async Task<IActionResult> Dashboard(int courseId = 2, int statusId = 1)
        {
            var allRegistrations = await _context.Applications.Include(r => r.Course).Include(r => r.ApplicationStatus).ToListAsync();
            var batches = await _context.Batchs.Include(b => b.Course).ToListAsync();

            var _courses = await _context.Courses.ToListAsync();


            ViewBag.registrationsByCourse = allRegistrations.GroupBy(r => r.Course).ToDictionary(g => g.Key, g => g.Count());
            ViewBag.registrationsByStatus = allRegistrations.GroupBy(r => r.ApplicationStatus).ToDictionary(g => g.Key, g => g.Count());
            ViewBag.SelectedCourseId = courseId;
            ViewBag.SelectedStatusId = statusId;
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

        public async Task<IActionResult> EnrollToBatch(int _applicationId, int _batchId)
        {
            var r = await _studentBal.MoveApplicationToBatch(_applicationId, _batchId);
            if (r)
            { return RedirectToAction(nameof(Dashboard)); }
            return View(r);
        }
    }
}
