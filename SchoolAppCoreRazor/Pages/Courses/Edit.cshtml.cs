using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly SchoolContext _context;
        public EditModel(SchoolContext context) { _context = context; }

        [BindProperty] public Course Course { get; set; } = default!;
        public SelectList? DepartmentList { get; set; }
        public SelectList? InstructorList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            Course = course;
            DepartmentList = new SelectList(await _context.Departments.ToListAsync(), "DepartmentID", "DepartmentName");
            InstructorList = new SelectList(await _context.Instructors.ToListAsync(), "InstructorID", "LastName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                DepartmentList = new SelectList(await _context.Departments.ToListAsync(), "DepartmentID", "DepartmentName");
                InstructorList = new SelectList(await _context.Instructors.ToListAsync(), "InstructorID", "LastName");
                return Page();
            }
            _context.Attach(Course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
