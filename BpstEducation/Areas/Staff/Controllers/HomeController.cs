using BpstEducation.Data;
using BpstEducation.Models;
using BpstEducation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Faculty.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Admin")]

    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserServiceBAL _loginManager;

        public HomeController(AppDbContext context, IUserServiceBAL user)
        {
            _context = context;
            _loginManager = user;
        }
        public IActionResult Index()
        {
            var userId = _loginManager.GetLoggedInUserId();
            var email = _loginManager.GetLoggedInUserEmail();
            var roles = _loginManager.GetLoggedInUserRoles();
            return View();
        }

        public async Task<IActionResult> ViewProfile()
        {
            var employees = await _context.Employees
                .FirstOrDefaultAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);

        }

        public async Task<IActionResult> Create(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            employee ??= new Employees() { DateOfBirth = DateTime.Now.AddYears(-22) };
            return View(employee);
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewProfile");
            }
            else
            {
                return View(employees);
            }
        }

    }
}
