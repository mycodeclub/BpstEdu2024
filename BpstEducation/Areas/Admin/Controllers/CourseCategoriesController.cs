using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Authorization;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CourseCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CourseCategories
        public async Task<IActionResult> Index()
        {
            ViewBag.activeTabName = "Courses";
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Admin/CourseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.Courses
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            return View(courseCategory);
        }

        // GET: Admin/CourseCategories/Create
        public async Task<IActionResult> Create(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            course ??= new Course() { };
            ViewBag.activeTabName = "Courses";
            return View(course);
        }

        // POST: Admin/CourseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniqueId,Name")] Course courseCategory)
        {
            ViewBag.activeTabName = "Courses";
            if (ModelState.IsValid)
            {
                if (courseCategory.UniqueId == 0)
                {
                    _context.Add(courseCategory);
                }
                else
                {
                    _context.Update(courseCategory);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseCategory);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Admin/CourseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.Courses
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            return View(courseCategory);
        }

        // POST: Admin/CourseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.activeTabName = "Courses";
            var courseCategory = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseCategoryExists(int id)
        {
            return _context.Courses.Any(e => e.UniqueId == id);
        }
    }
}
