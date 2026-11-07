using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;
        public CreateModel(SchoolContext context) { _context = context; }
        [BindProperty] public Department Department { get; set; } = new Department { DepartmentName = "" };
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
