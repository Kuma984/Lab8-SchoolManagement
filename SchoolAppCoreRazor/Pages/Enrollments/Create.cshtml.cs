using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;
        public CreateModel(SchoolContext context) { _context = context; }

        [BindProperty] public Enrollment Enrollment { get; set; } = new Enrollment();
        public SelectList? CourseList { get; set; }
        public SelectList? StudentList { get; set; }

        public async Task OnGetAsync()
        {
            CourseList = new SelectList(await _context.Courses.ToListAsync(), "CourseID", "Title");
            StudentList = new SelectList(await _context.Students.Select(s => new {
                s.StudentID,
                FullName = s.FirstName + " " + s.LastName
            }).ToListAsync(), "StudentID", "FullName");
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
            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
