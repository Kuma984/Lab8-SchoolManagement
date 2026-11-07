using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;
        public CreateModel(SchoolContext context) { _context = context; }
        [BindProperty] public Student Student { get; set; } = new Student { LastName = "", FirstName = "" };
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
