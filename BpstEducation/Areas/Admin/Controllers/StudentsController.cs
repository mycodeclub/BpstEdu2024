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
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Students
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.students.Include(s => s.CourseCategory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students
                .Include(s => s.CourseCategory)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Admin/Students/Create
        public async Task<IActionResult> Create(int id)
        {
            var stu = await _context.students.FindAsync(id);
            stu ??= new Students() { RegistrationDate = DateTime.UtcNow };
            ViewData["CourseCategoryID"] = new SelectList(_context.CourseCategories, "UniqueId", "Name");
            ViewData["BatchId"] = new SelectList(_context.Batchs.Include(c=>c.Course), "UniqueId", "Course.Name");
            return View(new Students() { DateOfBirth = DateTime.Now.AddYears(-18) });
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Students student)
        {

            if (ModelState.IsValid)
            {
                var (aadhaarImagePath, panImagePath) = await UploadAadhaarAndPanImagesAsync(student.Aadhar, student.Pan);
                student.AadharName = aadhaarImagePath;
                student.PanName = panImagePath;

                if (student.UniqueId == 0)
                {
                    student.CreatedDate = DateTime.UtcNow;
                     _context.Add(student);
                }
                else
                {
                    student.LastUpdatedDate = DateTime.UtcNow;
                    _context.Update(student);
                }
                ViewData["BatchId"] = new SelectList(_context.Batchs.Include(b => b.Course), "UniqueId", "Course.Name");

                ViewData["CourseCategoryID"] = new SelectList(_context.CourseCategories, "UniqueId", "Name", student.CourseCategoryID);
                return View(student);

            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            ViewData["CourseCategoryID"] = new SelectList(_context.CourseCategories, "UniqueId", "Name", students.CourseCategoryID);
            return View(students);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,FirstName,LastName,Email,DateOfBirth,PhoneNumber,Address,AadhaarNumber,PanNumber,AadharName,PanName,CourseCategoryID,Fees")] Students students)
        {
            if (id != students.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.UniqueId))
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
            ViewData["CourseCategoryID"] = new SelectList(_context.CourseCategories, "UniqueId", "Name", students.CourseCategoryID);
            return View(students);
        }

        // GET: Admin/Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students
                .Include(s => s.CourseCategory)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.students.FindAsync(id);
            if (students != null)
            {
                _context.students.Remove(students);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
            return _context.students.Any(e => e.UniqueId == id);
        }
        private async Task<(string? AadhaarImagePath, string? PanImagePath)> UploadAadhaarAndPanImagesAsync(IFormFile? aadhaarFile, IFormFile? panFile)
        {
            string? aadhaarImagePath = null;
            string? panImagePath = null;

            if (aadhaarFile != null && aadhaarFile.Length > 0)
            {
                var aadhaarFileName = Path.GetFileName(aadhaarFile.FileName);


                var aadhaarFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
                if (!Directory.Exists(aadhaarFilePath))
                {
                    Directory.CreateDirectory(aadhaarFilePath);
                }

                using (var stream = new FileStream(aadhaarFilePath + aadhaarFileName, FileMode.Create))
                {
                    await aadhaarFile.CopyToAsync(stream);
                }


                aadhaarImagePath = "/images/" + aadhaarFileName;
            }

            if (panFile != null && panFile.Length > 0)
            {
                var panFileName = Path.GetFileName(panFile.FileName);
                var panFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", panFileName);

                using (var stream = new FileStream(panFilePath, FileMode.Create))
                {
                    await panFile.CopyToAsync(stream);
                }

                panImagePath = "/images/" + panFileName;
            }

            return (aadhaarImagePath, panImagePath);
        }


    }
}
