using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolContext _context;
        public DeleteModel(SchoolContext context) { _context = context; }
        [BindProperty] public Department Department { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();
            Department = dept;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var dept = await _context.Departments.FindAsync(Department.DepartmentID);
            if (dept != null)
            {
                _context.Departments.Remove(dept);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
