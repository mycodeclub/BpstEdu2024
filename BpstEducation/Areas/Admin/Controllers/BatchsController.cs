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
    public class BatchsController : Controller
    {
        private readonly AppDbContext _context;

        public BatchsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Batche
        public async Task<IActionResult> Index()
        {
            var batchs = await _context.Batchs.Include(b => b.Course).Include(b => b.Trainer).ToListAsync();
             return View(batchs);
        }

        // GET: Admin/Batche/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batchs
                .Include(b => b.Course)
                .Include(b => b.Trainer)
                // .Include(b => b.Students)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }


        // GET: Admin/Batche/Create
        public async Task<IActionResult> Create(int id)
        {
            var batch = await _context.Batchs.FindAsync(id);
            batch ??= new Batch() { StartDate = DateTime.Now.AddMonths(2) };

            ViewData["CourseId"] = new SelectList(_context.Courses, "UniqueId", "Name");
            ViewData["TrainerId"] = new SelectList(_context.Employees, "UniqueId", "FullName");
            return View(batch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                if (batch.UniqueId == 0)
                {
                    batch.CreatedDate = DateTime.UtcNow;
                    _context.Add(batch);
                }
                else
                {
                    batch.LastUpdatedDate = DateTime.UtcNow;
                    _context.Update(batch);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "UniqueId", "UniqueId", batch.CourseId);
            ViewData["TrainerId"] = new SelectList(_context.Employees, "UniqueId", "UniqueId", batch.TrainerId);
            return View(batch);
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        // GET: Admin/Batche/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batchs
                .Include(b => b.Course)
                .Include(b => b.Trainer)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Admin/Batche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batch = await _context.Batchs.FindAsync(id);
            if (batch != null)
            {
                _context.Batchs.Remove(batch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
            return _context.Batchs.Any(e => e.UniqueId == id);
        }
    }
}
