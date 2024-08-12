using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Authorization;
using BpstEducation.Services;
using Microsoft.AspNetCore.Identity;

namespace BpstEducation.Areas.Staff.Controllers
{


    [Area("Staff")]
    [Authorize(Roles = "Staff,Admin")]
    public class BatcheStudentsController(UserManager<AppUser> userManager, AppDbContext context, IUserServiceBAL loginService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IUserServiceBAL _loggedInUser = loginService;


        // GET: StudentBatches
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _context.BatchStudents.Include(s => s.Batch).Include(s => s.Student).ToListAsync();

            ViewBag.Layout = await _loggedInUser.GetLayout();
            return View(appDbContext);
        }

        // GET: StudentBatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBatch = await _context.BatchStudents
                .Include(s => s.Batch)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (studentBatch == null)
            {
                return NotFound();
            }
            ViewBag.Layout = await _loggedInUser.GetLayout();
            return View(studentBatch);
        }

        // GET: StudentBatches/Create
        public async Task<IActionResult> Create(int id)
        {
            var batchStu = await _context.BatchStudents.FindAsync(id);
            if (batchStu == null)
                batchStu = new BatchStudent() { DiscountFee = 0, };
            ViewData["BatchId"] = new SelectList(_context.Batchs.Include(b => b.Course), "UniqueId", "BatchDisplayName");
            ViewData["StudentId"] = new SelectList(_context.Students, "UniqueId", "StudentDisplayName");
            ViewBag.Layout = await _loggedInUser.GetLayout();
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
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId", studentBatch.StudentId);
            ViewBag.Layout = await _loggedInUser.GetLayout();
            return View(studentBatch);
        }

        // GET: StudentBatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBatch = await _context.BatchStudents.FindAsync(id);
            if (studentBatch == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.Batchs, "UniqueId", "UniqueId", studentBatch.BatchId);
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId", studentBatch.StudentId);
            ViewBag.Layout = await _loggedInUser.GetLayout();
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
            ViewData["RegistraionId"] = new SelectList(_context.Registrations, "UniqueId", "EmailId", studentBatch.StudentId);
            ViewBag.Layout = await _loggedInUser.GetLayout();
            return View(studentBatch);
        }

        // GET: StudentBatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBatch = await _context.BatchStudents
                .Include(s => s.Batch)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (studentBatch == null)
            {
                return NotFound();
            }

            ViewBag.Layout = await _loggedInUser.GetLayout();
            return View(studentBatch);
        }

        // POST: StudentBatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentBatch = await _context.BatchStudents.FindAsync(id);
            if (studentBatch != null)
            {
                _context.BatchStudents.Remove(studentBatch);
            }

            await _context.SaveChangesAsync();
            ViewBag.Layout = await _loggedInUser.GetLayout();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentBatchExists(int id)
        {
            return _context.BatchStudents.Any(e => e.UniqueId == id);
        }
    }
}
