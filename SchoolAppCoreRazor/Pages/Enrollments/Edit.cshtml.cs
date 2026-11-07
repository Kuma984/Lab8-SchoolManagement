using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly SchoolContext _context;
        public EditModel(SchoolContext context) { _context = context; }

        [BindProperty] public Enrollment Enrollment { get; set; } = default!;
        public SelectList? CourseList { get; set; }
        public SelectList? StudentList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return NotFound();
            Enrollment = enrollment;
            CourseList = new SelectList(await _context.Courses.ToListAsync(), "CourseID", "Title");
            StudentList = new SelectList(await _context.Students.Select(s => new {
                s.StudentID,
                FullName = s.FirstName + " " + s.LastName
            }).ToListAsync(), "StudentID", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CourseList = new SelectList(await _context.Courses.ToListAsync(), "CourseID", "Title");
                StudentList = new SelectList(await _context.Students.Select(s => new {
                    s.StudentID,
                    FullName = s.FirstName + " " + s.LastName
                }).ToListAsync(), "StudentID", "FullName");
                return Page();
            }
            _context.Attach(Enrollment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
