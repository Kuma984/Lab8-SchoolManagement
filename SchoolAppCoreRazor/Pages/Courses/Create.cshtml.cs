using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;
        public CreateModel(SchoolContext context) { _context = context; }

        [BindProperty] public Course Course { get; set; } = new Course { Title = "" };
        public SelectList? DepartmentList { get; set; }
        public SelectList? InstructorList { get; set; }

        public async Task OnGetAsync()
        {
            DepartmentList = new SelectList(await _context.Departments.ToListAsync(), "DepartmentID", "DepartmentName");
            InstructorList = new SelectList(await _context.Instructors.ToListAsync(), "InstructorID", "LastName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                DepartmentList = new SelectList(await _context.Departments.ToListAsync(), "DepartmentID", "DepartmentName");
                InstructorList = new SelectList(await _context.Instructors.ToListAsync(), "InstructorID", "LastName");
                return Page();
            }
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
