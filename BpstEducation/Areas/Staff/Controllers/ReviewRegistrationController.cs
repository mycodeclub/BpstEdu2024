using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.NewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Collections.Generic;

namespace BpstEducation.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class ReviewRegistrationController : Controller
    {

        private readonly AppDbContext _context;

        public ReviewRegistrationController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            var allRegistrations = await _context.Registration.Include(r => r.Course).ToListAsync();
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
        }
    }
}
