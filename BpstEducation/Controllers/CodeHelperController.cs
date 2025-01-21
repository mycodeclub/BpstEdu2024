using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BpstEducation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpstEducation.Controllers
{
    public class CodeHelperController : Controller
    {
        private readonly AppDbContext _context;
        public CodeHelperController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Subjects = await _context.Subjects.ToListAsync().ConfigureAwait(false);
            var CodeHelpers = await _context.CodeHelpers.Include(q => q.Subject).ToListAsync();
            var ch = CodeHelpers.GroupBy(q => q.Subject.Name);
            return View(ch);
        }
    }
}