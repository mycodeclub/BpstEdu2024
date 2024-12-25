using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BpstEducation.Data;
using BpstEducation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserServiceBAL _loginManager;





        public HomeController(AppDbContext context, IUserServiceBAL user)
        {
            _context = context;
            _loginManager = user;
        }
        public async Task<IActionResult> Index()
        {
            var _batches = await _context.Batchs.Include(b=>b.Course).Include(b => b.Students).Include(b => b.Trainer).ToListAsync();

            //var userId = _loginManager.GetLoggedInUserId();
            //var email = _loginManager.GetLoggedInUserEmail();
            //var roles = _loginManager.GetLoggedInUserRoles();
            return View(_batches);
        }
    }
}