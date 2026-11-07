using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Instructors
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;
        public CreateModel(SchoolContext context) { _context = context; }
        [BindProperty] public Instructor Instructor { get; set; } = new Instructor { LastName = "", FirstName = "" };

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Instructors.Add(Instructor);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
