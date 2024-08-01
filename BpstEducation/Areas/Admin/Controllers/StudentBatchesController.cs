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
    public class StudentBatchesController : Controller
    {
        private readonly AppDbContext _context;

        public StudentBatchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StudentBatches
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _context.StudentBatch.Include(s => s.Batch).Include(s => s.Registration).ToListAsync();
            return View(appDbContext);
        }

        // GET: StudentBatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBatch = await _context.StudentBatch
                .Include(s => s.Batch)
                .Include(s => s.Registration)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (studentBatch == null)
            {
                return NotFound();
            }

            return View(studentBatch);
        }

        // GET: StudentBatches/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.Batchs.Include(b=>b.Course), "UniqueId", "Course.Name");
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId");
            return View();
        }

        // POST: StudentBatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BatchStudent studentBatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentBatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.Batchs, "UniqueId", "UniqueId", studentBatch.BatchId);
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId", studentBatch.RegistrationId);
            return View(studentBatch);
        }

        // GET: StudentBatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBatch = await _context.StudentBatch.FindAsync(id);
            if (studentBatch == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.Batchs, "UniqueId", "UniqueId", studentBatch.BatchId);
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId", studentBatch.RegistrationId);
            return View(studentBatch);
        }

        // POST: StudentBatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BatchStudent studentBatch)
        {
            if (id != studentBatch.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentBatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentBatchExists(studentBatch.UniqueId))
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
            ViewData["BatchId"] = new SelectList(_context.Batchs, "UniqueId", "UniqueId", studentBatch.BatchId);
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId", studentBatch.RegistrationId);
            return View(studentBatch);
        }

        // GET: StudentBatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBatch = await _context.StudentBatch
                .Include(s => s.Batch)
                .Include(s => s.Registration)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (studentBatch == null)
            {
                return NotFound();
            }

            return View(studentBatch);
        }

        // POST: StudentBatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentBatch = await _context.StudentBatch.FindAsync(id);
            if (studentBatch != null)
            {
                _context.StudentBatch.Remove(studentBatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentBatchExists(int id)
        {
            return _context.StudentBatch.Any(e => e.UniqueId == id);
        }
    }
}
