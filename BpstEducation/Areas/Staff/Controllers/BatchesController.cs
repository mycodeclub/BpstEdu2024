using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;

namespace BpstEducation.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class BatchesController : Controller
    {
        private readonly AppDbContext _context;

        public BatchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Staff/Batches
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Batchs.Include(b => b.Course).Include(b => b.Trainer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Staff/Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            Batch batch = await GetBatchById(id);
            if (batch == null)
                return NotFound();
            return View(batch);
        }

        private async Task<Batch> GetBatchById(int? id)
        {
            var batch = await _context.Batchs
                           .Include(b => b.Course)
                           .Include(b => b.Trainer)
                           .Include(b => b.Students)
                           .FirstOrDefaultAsync(m => m.UniqueId == id);

            return batch;
        }


        // GET: Staff/Batches/Details/5 --@ToDo -- in progress ...
        public async Task<IActionResult> AssignStudentToBatch(int batchId)
        {
            var batch = GetBatchById(batchId);
            if (batch == null)
                return NotFound();

            // selecting students who are not part of any batch.
            
            var unassignedStudents = await _context.Students.Where(s => !_context.BatchStudents.Select(bs => bs.StudentId).Contains(s.UniqueId)).Where(s => s.IsDeleted == false).ToListAsync();
            ViewBag.UnassignedStudents = unassignedStudents;
            var batchStudents = _context.BatchStudents
                .Include(b => b.Student)
                .Where(s => s.BatchId == batchId).ToListAsync(); 
            return View(batchStudents);
        }
    }
}
