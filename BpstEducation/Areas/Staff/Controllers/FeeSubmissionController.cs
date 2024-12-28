using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class FeeSubmissionController : Controller
    {
        private readonly AppDbContext _context;

        public FeeSubmissionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int studentId, int batchId)
        {
            var stuFeeDetails = await _context.BatchStudents.Where(b => b.BatchId == batchId && b.StudentId == studentId).Include(b => b.SubmittedFeeList).ToListAsync();
            return View(stuFeeDetails);
        }

        public async Task<IActionResult> Create(int studentId, int batchId)
        {
            var _studentbatchDetail = await _context.BatchStudents
                .Where(b => b.BatchId == batchId && b.StudentId == studentId)
                .Include(b => b.SubmittedFeeList)
                .Include(b => b.Batch)
                .FirstOrDefaultAsync();
            return View(_studentbatchDetail);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentFee fee)
        {
            var bs = await _context.BatchStudents.Include(f => f.SubmittedFeeList).Where(e => e.UniqueId.Equals(fee.BatchStudentId)).FirstOrDefaultAsync();
            if (bs != null)
            { 
            
            } fee.CreatedDate = DateTime.Now;
            fee.FeeSubmittingDate = DateTime.Now;
            fee.LastUpdatedDate = DateTime.Now;
            bs.SubmittedFeeList.Add(fee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Students", new { id = bs.StudentId });
        }
    }
}
