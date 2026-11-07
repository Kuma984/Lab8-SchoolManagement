using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;
        public DetailsModel(SchoolContext context) { _context = context; }
        public Student Student { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null) return NotFound();
            Student = s; return Page();
        }
    }
}
