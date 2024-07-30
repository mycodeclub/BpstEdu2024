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
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Courses
        public async Task<IActionResult> Index()
        {
            ViewBag.activeTabName = "Courses";
            var appDbContext = _context.Courses.Include(c => c.CourseCategory);
            return View(await appDbContext.ToListAsync());
        }


        // GET: Admin/Courses
        public async Task<IActionResult> Categories()
        {
            ViewBag.activeTabName = "Courses";
            var CourseCategory = _context.CourseCategories.ToListAsync();
            return View(await CourseCategory);
        }

        // GET: Admin/Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.CourseCategory)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Admin/Courses/Create
        public async Task<IActionResult> Create(int Id)
        {
            ViewBag.activeTabName = "Courses";
            Course course = null;
            if(Id != 0)
            {
                course = await _context.Courses.Include(a => a.CourseCategory).Where(a => a.UniqueId.Equals(Id)).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            if(course == null)
            {
                course = new Course() { };
            }
            ViewData["CourseCategoryID"] = new SelectList(_context.Set<CourseCategory>(), "UniqueId", "Name");
            return View(course);
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            ViewBag.activeTabName = "Courses";
            if (ModelState.IsValid)
            {
                if (course.UniqueId.Equals(0))
                {
                    course.CreateDate = DateTime.Now.AddMinutes(750);
                    _context.Add(course);
                }
                else
                {
                    _context.Update(course);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseCategoryID"] = new SelectList(_context.Set<CourseCategory>(), "UniqueId", "UniqueId", course.CourseCategoryID);
            return View(course);
        }

        // GET: Admin/Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CourseCategoryID"] = new SelectList(_context.Set<CourseCategory>(), "UniqueId", "UniqueId", course.CourseCategoryID);
            return View(course);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,CourseName,CourseCategoryID,CreateDate")] Course course)
        {
            ViewBag.activeTabName = "Courses";
            if (id != course.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.UniqueId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseCategoryID"] = new SelectList(_context.Set<CourseCategory>(), "UniqueId", "UniqueId", course.CourseCategoryID);
            return View(course);
        }

        // GET: Admin/Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.CourseCategory)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.activeTabName = "Courses";
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.UniqueId == id);
        }
    }
}
