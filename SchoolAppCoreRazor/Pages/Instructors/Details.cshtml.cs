using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;
        public DetailsModel(SchoolContext context) { _context = context; }
        public Instructor Instructor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var item = await _context.Instructors.FindAsync(id);
            if (item == null) return NotFound();
            Instructor = item;
            return Page();
        }
    }
}
