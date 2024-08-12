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

            var batch = await _context.Batchs
                .Include(b => b.Course)
                .Include(b => b.Trainer)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (batch == null)
                return NotFound();
            return View(batch);
        }


        // GET: Staff/Batches/Details/5 --@ToDo -- in progress ...
        public async Task<IActionResult> AddStudents(int batchId)
        {
            if (batchId == null)
                return NotFound();
            var batch = await _context.Batchs.FirstOrDefaultAsync(m => m.UniqueId == batchId);
        //      batch.Students = await _context.Students.ToListAsync();
            if (batch == null)
                return NotFound();
            return View(batch);
        }
    }
}
