using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BatchesController : Controller
    {
        private readonly AppDbContext _context;

        public BatchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Batche
        public async Task<IActionResult> Index()
        {
            var batchs = await _context.Batchs.Include(b => b.Course).Include(b => b.Trainer).ToListAsync();
            //    var batchesGroup = batchs.GroupBy(b => b.StartDate > System.DateTime.Now.AddDays(-5));
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

            ViewData["CourseId"] = new SelectList(_context.CourseCategories, "UniqueId", "Name");
            ViewData["TrainerId"] = new SelectList(_context.employees, "UniqueId", "FullName");
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
            ViewData["CourseId"] = new SelectList(_context.CourseCategories, "UniqueId", "UniqueId", batch.CourseId);
            ViewData["TrainerId"] = new SelectList(_context.employees, "UniqueId", "UniqueId", batch.TrainerId);
            return View(batch);
        }


        // POST: Admin/Batche/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,CourseId,Title,Duration,Description,TrainerId,AssisTrainer,StartDate,LastUpdatedDate,BatchFee,CreatedBy,LastUpdatedBy")] Batch batch)
        {
            if (id != batch.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.UniqueId))
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
            ViewData["CourseId"] = new SelectList(_context.CourseCategories, "UniqueId", "UniqueId", batch.CourseId);
            ViewData["TrainerId"] = new SelectList(_context.employees, "UniqueId", "UniqueId", batch.TrainerId);
            return View(batch);
        }

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
