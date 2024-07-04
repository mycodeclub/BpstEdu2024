using System.Linq;
using System.Threading.Tasks;
using BpstEducation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace BpstEducation.Controllers
{
    public class InterviewQuestionsController : Controller
    {
        private readonly AppDbContext _context;
        public InterviewQuestionsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Questions.Include(q => q.Subject);
            ViewBag.Subjects = await _context.Subjects.ToListAsync().ConfigureAwait(false);
            var questions = await appDbContext.ToListAsync();
            var Qg = questions.GroupBy(q => q.Subject.Name);
            return View(Qg);
        }
    }
}