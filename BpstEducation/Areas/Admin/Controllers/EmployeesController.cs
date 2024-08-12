using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BpstEducation.Services;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = " Admin")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserServiceBAL _userService;
        public EmployeesController(
            UserManager<AppUser> userManager,
             AppDbContext context,
             IUserServiceBAL userService
            )
        {
            _userManager = userManager;
            _context = context;
            _userService = userService;
        }

        // GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.employees.ToListAsync());
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.employees
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Admin/Employees/Create
        public async Task<IActionResult> Create(int id)
        {
            var employee = await _context.employees.FindAsync(id);
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
                if (employees.UniqueId == 0)
                {
                    _context.Add(employees);
                    var result = await AddLoginDetails(employees);
                    if (!result.Succeeded)
                        ModelState.AddModelError("Login Creation Error", string.Join(",", result.Errors.Select(e => { return e.Code + " : " + e.Description; }).ToList()));
                }
                else
                    _context.Update(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(employees);
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Admin/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.employees
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.employees.FindAsync(id);
            if (employees != null)
            {
                _context.employees.Remove(employees);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.employees.Any(e => e.UniqueId == id);
        }

        private async Task<IdentityResult> AddLoginDetails(Employees emp)
        {
            var appUser = new AppUser()
            {
                UserName = emp.Email,
                Email = emp.Email,
                Password = "Bpst@" + emp.FullName,
                ConfirmPassword = "Bpst@" + emp.FullName,
                PhoneNumber = emp.PhoneNumber
            };
            var result = await _userService.AddUser(appUser, ["Staff"]);
            return result;
        }
    }
}
