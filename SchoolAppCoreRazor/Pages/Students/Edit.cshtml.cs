using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly SchoolContext _context;
        public EditModel(SchoolContext context) { _context = context; }
        [BindProperty] public Student Student { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null) return NotFound();
            Student = s; return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Attach(Student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
