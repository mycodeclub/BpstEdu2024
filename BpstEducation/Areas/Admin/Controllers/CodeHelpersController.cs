using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.Extensions.Logging;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CodeHelpersController : Controller
    {
        private readonly AppDbContext _context;
        public CodeHelpersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CodeHelpers
        public async Task<IActionResult> Index()
        {
            ViewBag.activeTabName = "CodeHelper";
            var appDbContext = _context.CodeHelpers.Include(c => c.Subject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/CodeHelpers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.activeTabName = "CodeHelper";
            if (id == null)
            {
                return NotFound();
            }

            var codeHelper = await _context.CodeHelpers
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (codeHelper == null)
            {
                return NotFound();
            }

            return View(codeHelper);
        }

        // GET: Admin/CodeHelpers/Create
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.activeTabName = "CodeHelper";
            CodeHelper ch = null;
            if (id > 0) ch = await _context.CodeHelpers.FindAsync(id);
            if (ch == null) ch = new CodeHelper();
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "UniqueId", "Name");
            return View(ch);
        }

        // POST: Admin/CodeHelpers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CodeHelper ch)
        {
            ViewBag.activeTabName = "CodeHelper";
            ch.LastUpdatedDate = ch.CreatedDate = DateTime.Now;
            ch.IsActive = true;

            if (ModelState.IsValid)
            {
                if (ch.UniqueId > 0)
                    _context.Update(ch);
                else
                    _context.Add(ch);
                await _context.SaveChangesAsync();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "UniqueId", "Name", ch.SubjectId);
            return View(ch);
        }

        // GET: Admin/CodeHelpers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.activeTabName = "CodeHelper";
            if (id == null)
            {
                return NotFound();
            }

            var codeHelper = await _context.CodeHelpers
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (codeHelper == null)
            {
                return NotFound();
            }

            return View(codeHelper);
        }

        // POST: Admin/CodeHelpers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.activeTabName = "CodeHelper";
            var codeHelper = await _context.CodeHelpers.FindAsync(id);
            _context.CodeHelpers.Remove(codeHelper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeHelperExists(int id)
        {
            return _context.CodeHelpers.Any(e => e.UniqueId == id);
        }
    }
}
