using System;
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
    public class QuestionsController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Questions
        public async Task<IActionResult> Index()
        {
            ViewBag.activeTabName = "HelperQuestions";
            var appDbContext = _context.Questions.Include(q => q.Subject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.activeTabName = "HelperQuestions";
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // GET: Admin/Questions/Create
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.activeTabName = "HelperQuestions";
            Question question = null;
            if (id > 0) question = await _context.Questions.FindAsync(id);
            if (question == null) question = new Question();
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "UniqueId", "Name");
            return View(question);
        }

        // POST: Admin/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question)
        {
            ViewBag.activeTabName = "HelperQuestions";
            question.LastUpdatedDate = question.CreatedDate = DateTime.Now;
            question.IsActive = true;
            if (ModelState.IsValid)
            {
                if (question.UniqueId > 0)
                    _context.Update(question);
                else
                    _context.Add(question);
                await _context.SaveChangesAsync();
                ViewBag.SavedSuccessfully = true;
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "UniqueId", "Name", question.SubjectId);
            return View(question);
        }

        // GET: Admin/Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.activeTabName = "HelperQuestions";
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "UniqueId", "UniqueId", question.SubjectId);
            return View(question);
        }

        // POST: Admin/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,SubjectId,QustionText,QustionDescription,AnswerHeading,AnswerSubHeading,AnswerText,AnswerObjectJson,Tags,CreatedDate,LastUpdatedDate,IsActive")] Question question)
        {
            ViewBag.activeTabName = "HelperQuestions";
            if (id != question.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.UniqueId))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "UniqueId", "UniqueId", question.SubjectId);
            return View(question);
        }

        // GET: Admin/Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.activeTabName = "HelperQuestions";
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Admin/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.activeTabName = "HelperQuestions";
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.UniqueId == id);
        }
    }
}
