using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolContext _context;
        public DeleteModel(SchoolContext context) { _context = context; }
        [BindProperty] public Student Student { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null) return NotFound();
            Student = s; return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var s = await _context.Students.FindAsync(Student.StudentID);
            if (s != null) { _context.Students.Remove(s); await _context.SaveChangesAsync(); }
            return RedirectToPage("Index");
        }
    }
}
