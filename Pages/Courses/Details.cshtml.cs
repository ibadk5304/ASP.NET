using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_Courses
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                            .Include(c => c.Prerequisites)
                                .ThenInclude(c => c.Prerequisite)
                            .Include(c=>c.IsPrerequisiteFor)
                                .ThenInclude(ip => ip.Course)
                            .FirstOrDefaultAsync(m => m.Id == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
