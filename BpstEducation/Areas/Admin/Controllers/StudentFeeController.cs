using BpstEducation.Data;
using BpstEducation.Migrations;
using BpstEducation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StudentFeeController : Controller
    {
        private readonly AppDbContext _context;
        public StudentFeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            var stu = await _context.students.FindAsync(id);
            if (stu != null)
            {
                stu.MySubmittedFeeTillNow = await _context.Fees.Where(f => f.StudentId == id).ToListAsync();
            }
            else stu = new Students() { UniqueId = id };
            ViewBag.StudentId = id;
            return View(stu);
        }
        public IActionResult Create(int id)
        {
            StudentFee studentfee = new StudentFee() { StudentId = id, CreatedDate = DateTime.UtcNow,FeeSubmittingDate=DateTime.Now }; 
            return View(studentfee);

        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentFee studentfee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentfee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id=studentfee.StudentId});
            }

            return View(studentfee);

        }











    }
}
