using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolContext _context;
        public DeleteModel(SchoolContext context) { _context = context; }
        [BindProperty] public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null) return NotFound();
            Course = course;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var course = await _context.Courses.FindAsync(Course.CourseID);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
