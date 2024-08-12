using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BpstEducation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using BpstEducation.Data;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics.Contracts;

namespace BpstEducation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ActiveTabId = 1;
            return View();
        }



        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View(new Contact());
        }
        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {

            if (ModelState.IsValid)
            {
                if (contact.UniqueId.Equals(0))
                {
                    await _context.Contacts.AddRangeAsync(contact);
                    _context.Contacts.Add(contact);

                }
                else

                    _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(contact));
            }
            return View(contact);
        }



        // ----------------------------------------------------------

        public IActionResult Carrier()
        {
            ViewBag.ActiveTabId = 3;
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }


        public static string ReadFile(string FileName)
        {
            try
            {
                using (StreamReader reader = System.IO.File.OpenText(FileName))
                {
                    string fileContent = reader.ReadToEnd();
                    if (fileContent != null && fileContent != "")
                    {
                        return fileContent;
                    }
                }
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Exam()
        {
            return View();
        }






        public async Task<IActionResult> StudentRegistration(int Id)
        {
            Registration course = null;
            if (Id != 0)
            {
                course = await _context.Registrations.Include(a => a.Qualification).Include(a => a.Course).Where(a => a.UniqueId.Equals(Id)).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            if (course == null)
            {
                course = new Registration() { };
            }
            if (TempData["Message"] != null)
            {
                if ((bool)TempData["Message"] == true)
                {
                    ViewBag.RegId = TempData["RegId"];
                    ViewBag.RegistrationSaved = true;
                }
            }
            else
            {
                ViewBag.RegistrationSaved = false;
            }
            ViewData["ApplicationFor"] = new SelectList(_context.Courses, "UniqueId", "Name");
            ViewData["Qualification"] = new SelectList(_context.Set<Qualification>(), "UniqueId", "Name");
            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentRegistration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (registration.UniqueId.Equals(0))
                    {
                        registration.StatusId = 1;
                        var id = _context.Registrations.Count();
                        registration.RegistrationId = "BPST0" + (id + 1); // Increment id to avoid duplicate ID
                        TempData["RegId"] = registration.RegistrationId;
                        registration.CreateDate = DateTime.UtcNow.AddMinutes(750); // Use UTC for consistency
                        _context.Add(registration);

                    }
                    else
                        _context.Update(registration);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = true;
                    return RedirectToAction(nameof(StudentRegistration));
                }
                catch (Exception ex)
                {
                    // Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    ModelState.AddModelError("", ex.Message);
                    ModelState.AddModelError("", ex.InnerException.Message);
                    ModelState.AddModelError("", ex.StackTrace);
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["ApplicationFor"] = new SelectList(_context.Courses, "UniqueId", "Name");
            ViewData["Qualification"] = new SelectList(_context.Set<Qualification>(), "UniqueId", "Name");
            return View(registration);
        }
    }


}
