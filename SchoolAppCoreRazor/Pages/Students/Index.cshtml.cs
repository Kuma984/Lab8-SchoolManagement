using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        public IndexModel(SchoolContext context) { _context = context; }
        public IList<Student> Students { get; set; } = new List<Student>();
        public async Task OnGetAsync() { Students = await _context.Students.ToListAsync(); }
    }
}
