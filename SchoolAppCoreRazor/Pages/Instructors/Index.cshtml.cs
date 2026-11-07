using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        public IndexModel(SchoolContext context) { _context = context; }
        public IList<Instructor> Instructors { get; set; } = new List<Instructor>();

        public async Task OnGetAsync()
        {
            Instructors = await _context.Instructors.ToListAsync();
        }
    }
}
