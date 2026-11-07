using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;
        public DetailsModel(SchoolContext context) { _context = context; }
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null) return NotFound();
            Course = course;
            return Page();
        }
    }
}
