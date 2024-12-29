using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public async Task<IActionResult> Create(int studentId, int batchId)
        {
            var stuBatchDetails = await GetBatchStudent(batchId, studentId);
            var fee = new StudentFee()
            {
                SubmittedFeeAmount = stuBatchDetails.TotalFeesAfterDiscount - stuBatchDetails.SubmittedFeeList.Sum(f => f.SubmittedFeeAmount),
                CreatedDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now,
                FeeSubmittingDate = DateTime.Now,
                BatchStudentId = stuBatchDetails.UniqueId,
            };

            ViewBag.stuFeeDetails = stuBatchDetails;
            return View(fee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentFee fee)
        {
            if (ModelState.IsValid)
            {
                var dbFee = await _context.Fees.FindAsync(fee.UniqueId);
                if (dbFee == null)
                {
                    fee.CreatedDate = DateTime.Now;
                    fee.LastUpdatedDate = DateTime.Now;
                    fee.FeeSubmittingDate = DateTime.Now;
                    _context.Fees.Add(fee);
                }
                else
                {
                    dbFee.SubmittedFeeAmount = fee.SubmittedFeeAmount;
                    dbFee.Description = fee.Description;
                    dbFee.LastUpdatedDate = DateTime.Now;
                }
                await _context.SaveChangesAsync();
            }
            var bs = await _context.BatchStudents.FindAsync(fee.BatchStudentId);
            ViewBag.stuFeeDetails = await GetBatchStudent(bs.BatchId, bs.StudentId);
            return View(fee);
        }

        private async Task<BatchStudent> GetBatchStudent(int batchId, int studentId)
        {
            var _batchStu = await _context.BatchStudents.Where(b => b.BatchId == batchId && b.StudentId == studentId)
                .Include(b => b.Batch)
                .Include(sb => sb.Batch.Course)

                .Include(b => b.Student)
                .Include(b => b.Student.Address)
                .Include(b => b.Student.Address.Country)
                .Include(b => b.Student.Address.State)
                .Include(b => b.Student.Address.City)

                .Include(b => b.SubmittedFeeList)
                .FirstOrDefaultAsync();
            return _batchStu;
        }


    }
}
