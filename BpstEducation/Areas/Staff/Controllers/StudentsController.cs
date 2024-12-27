using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System;
namespace BpstEducation.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Admin")]
    public class StudentsController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserServiceBAL _userServiceBal;

        public StudentsController(UserManager<AppUser> userManager, AppDbContext context, IUserServiceBAL userServiceBal)
        {
            _context = context;
            _userManager = userManager;
            _userServiceBal = userServiceBal;
        }

        // GET: Admin/Students
        public async Task<IActionResult> Index()
        {

            var appDbContext = _context.Students.Include(s => s.CourseOfInterest);
            ViewBag.Layout = _userServiceBal.GetLayout();
            return View(await appDbContext.ToListAsync());
        }



        // GET: Admin/Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var students = await _context.Students
                .Include(s => s.Address)
                .Include(a => a.Address.Country)
                .Include(s => s.Address.State)
                .Include(s => s.Address.City)
                  .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (students == null)
                return NotFound();
            var _studentBatches = await _context.BatchStudents
                .Include(bs=>bs.Student)
                .Include(bs=>bs.Batch)
                .Include(bs=>bs.SubmittedFeeList)
                .Where(s => s.StudentId == id).ToListAsync();
            foreach (var sb in _studentBatches)
            {
            }
            ViewBag.StudentBatches = _studentBatches;
            return View(students);
        }

        // GET: Admin/Students/Create
        public async Task<IActionResult> Create(int id)
        {
            var stu = await _context.Students.FindAsync(id);
            stu ??= new Models.Student() { RegistrationDate = DateTime.UtcNow, DateOfBirth = DateTime.Now.AddYears(-18) };
            //ViewData["CourseCategoryID"] = new SelectList(_context.Courses, "UniqueId", "Name");
            //ViewData["BatchId"] = new SelectList(_context.Batchs.Include(c => c.Course), "UniqueId", "BatchNameWithStartDate"); 
            ViewData["CountryId"] = new SelectList(_context.Countries, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            return View(stu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Student student)
        {
            ValidateFileUploads(student);
            if (ModelState.IsValid)
            {
                if (student.UniqueId == 0)
                {
                    student.LastUpdatedDate = student.CreatedDate = DateTime.UtcNow;
                    _context.Add(student);
                    var result = await AddLoginDetails(student);
                    if (!result.Succeeded)
                        ModelState.AddModelError("Login Creation Error", string.Join(",", result.Errors.Select(e => { return e.Code + " : " + e.Description; }).ToList()));
                }
                else
                {
                    student.LastUpdatedDate = DateTime.UtcNow;
                    _context.Update(student);
                }

                await _context.SaveChangesAsync();
                if (student.Aadhar != null && student.Aadhar.Length > 0)
                {
                    student.AadharFileUrl = await Common.CommonFuntions.UploadFile(student.Aadhar, "Student", student.UniqueId, "Aadhar");
                    await _context.SaveChangesAsync();
                }
                if (student.Pan != null && student.Pan.Length > 0)
                {
                    student.PanFileUrl = await Common.CommonFuntions.UploadFile(student.Pan, "Student", student.UniqueId, "Pan");
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));

            }


            //  ViewData["BatchId"] = new SelectList(_context.Batchs.Include(b => b.Course), "UniqueId", "Course.Name", student.BatchId);
            //            ViewData["CourseCategoryID"] = new SelectList(_context.Courses, "UniqueId", "Name", student.CourseOfInterestId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            return View(student);

        }
        private async Task<IdentityResult> AddLoginDetails(Models.Student student)
        {
            var appUser = new AppUser()
            {
                UserName = student.Email,
                Email = student.Email,
                Password = Common.CommonFuntions.GetDefaultPassword(student.DateOfBirth),
                ConfirmPassword = Common.CommonFuntions.GetDefaultPassword(student.DateOfBirth),
                PhoneNumber = student.PhoneNumber
            };

            var result = await _userServiceBal.AddUser(appUser, ["Student"]);
            student.LoginIdGuid = appUser.Id;
            return result;
        }

        // GET: Admin/Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var students = await _context.Students
                .Include(s => s.CourseOfInterest)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (students == null)
                return NotFound();
            return View(students);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.FindAsync(id);
            if (students != null)
            {
                _context.Students.Remove(students);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.UniqueId == id);
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
                    Directory.CreateDirectory(aadhaarFilePath);

                using (var stream = new FileStream(aadhaarFilePath + aadhaarFileName, FileMode.Create))
                    await aadhaarFile.CopyToAsync(stream);

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
        private void ValidateFileUploads(Models.Student student)
        {
            if (student.Aadhar != null)
            {
                if (student.Aadhar.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Aadhar", "Aadhaar file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(student.Aadhar.FileName).ToLower()))
                {
                    ModelState.AddModelError("Aadhar", "Only JPG, JPEG, and PNG formats are allowed for Aadhaar.");
                }
            }

            if (student.Pan != null)
            {
                if (student.Pan.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Pan", "PAN file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(student.Pan.FileName).ToLower()))
                {
                    ModelState.AddModelError("Pan", "Only JPG, JPEG, and PNG formats are allowed for PAN.");
                }
            }
        }

    }
}
