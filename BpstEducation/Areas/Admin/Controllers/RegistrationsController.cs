using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Authorization;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RegistrationsController : Controller
    {
        private readonly AppDbContext _context;

        public RegistrationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Registrations
        public IActionResult Index()
        {
            ViewBag.activeTabName = "Registrations";
            ViewData["ApplicationFor"] = new SelectList(_context.CourseCategories, "UniqueId", "Name");
            ViewData["BoardId"] = new SelectList(_context.Set<EducationBoardsMaster>(), "UniqueId", "Name");
            return View();
        }

        // GET: Admin/Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.activeTabName = "Registrations";
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Course)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        

        // GET: Admin/Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.activeTabName = "Registrations";
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["ApplicationFor"] = new SelectList(_context.Courses, "UniqueId", "CourseName", registration.ApplicationFor);
            ViewData["StatusId"] = new SelectList(_context.RegistrationMasters, "UniqueId", "RegistrationStatus", registration.StatusId);
            return View(registration);
        }

        // POST: Admin/Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,StatusId,FullName,FatherName,CurrentlyPursuing,CollegeName,BoardId,HighestQualification,ApplicationFor,Message,MobileNumber,AlternateMobileNumber,EmailId,CreateDate")] Registration registration)
        {
            ViewBag.activeTabName = "Registrations";
            if (id != registration.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.UniqueId))
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
            ViewData["ApplicationFor"] = new SelectList(_context.Courses, "UniqueId", "CourseName", registration.ApplicationFor);
            ViewData["StatusId"] = new SelectList(_context.RegistrationMasters, "UniqueId", "RegistrationStatus", registration.StatusId);
            return View(registration);
        }

        // GET: Admin/Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.activeTabName = "Registrations";
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Course)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Admin/Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.activeTabName = "Registrations";
            var registration = await _context.Registrations.FindAsync(id);
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            ViewBag.activeTabName = "Registrations";
            return _context.Registrations.Any(e => e.UniqueId == id);
        }

        public async Task<IActionResult> GetStudentFilter(int BoardId, int ApplicationFor, Registration registration)
        {
            ViewBag.activeTabName = "Registrations";
             var students = await _context.Registrations
                .Include(a => a.Status)
                .Include(a => a.Course)
                .Where(a => (ApplicationFor.Equals(0) || a.ApplicationFor.Equals(ApplicationFor)))
                .ToListAsync()
                .ConfigureAwait(false);
            ViewBag.Dem = "aa";

            return View(students);
        }

    }
}
