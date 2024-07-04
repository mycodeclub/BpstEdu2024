using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View(await _context.CourseCategories.ToListAsync());
        }

        // GET: Admin/CourseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.activeTabName = "Courses"; 
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.CourseCategories
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            return View(courseCategory);
        }

        // GET: Admin/CourseCategories/Create
        public IActionResult Create()
        {
            ViewBag.activeTabName = "Courses"; return View();
        }

        // POST: Admin/CourseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniqueId,Name")] CourseCategory courseCategory)
        {
            ViewBag.activeTabName = "Courses";
            if (ModelState.IsValid)
            {
                _context.Add(courseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseCategory);
        }

        // GET: Admin/CourseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.CourseCategories.FindAsync(id);
            if (courseCategory == null)
            {
                return NotFound();
            }
            return View(courseCategory);
        }

        // POST: Admin/CourseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,Name")] CourseCategory courseCategory)
        {
            ViewBag.activeTabName = "Courses";
            if (id != courseCategory.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseCategoryExists(courseCategory.UniqueId))
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
            return View(courseCategory);
        }

        // GET: Admin/CourseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.activeTabName = "Courses";
            if (id == null)
            {
                return NotFound();
            }

            var courseCategory = await _context.CourseCategories
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
            var courseCategory = await _context.CourseCategories.FindAsync(id);
            _context.CourseCategories.Remove(courseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseCategoryExists(int id)
        {
            return _context.CourseCategories.Any(e => e.UniqueId == id);
        }
    }
}
