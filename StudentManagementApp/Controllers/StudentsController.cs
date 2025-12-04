using StudentManagementApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var studentsWithGrades = await _context.Students
                .Include(s => s.Grades)
                .ToListAsync();

            return View(studentsWithGrades);
        }
    }
}

