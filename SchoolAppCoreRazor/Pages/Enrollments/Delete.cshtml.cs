using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Enrollments
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolContext _context;
        public DeleteModel(SchoolContext context) { _context = context; }
        [BindProperty] public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null) return NotFound();
            Enrollment = enrollment;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var enrollment = await _context.Enrollments.FindAsync(Enrollment.EnrollmentID);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
