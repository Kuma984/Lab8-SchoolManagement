using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;
        public DetailsModel(SchoolContext context) { _context = context; }
        public Department Department { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();
            Department = dept;
            return Page();
        }
    }
}
