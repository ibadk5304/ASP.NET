using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_CourseOfferings
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public CourseOffering CourseOffering { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseOffering = await _context.CourseOfferings
                .Include(c => c.Course)
                .Include(c => c.DiplomaProgramYearSection)
                    .ThenInclude(dpys => dpys.DiplomaProgramYear)
                        .ThenInclude(dpy => dpy.DiplomaProgram)
                .Include(c => c.Instructor)
                .Include(c => c.Semester).FirstOrDefaultAsync(m => m.Id == id);

            if (CourseOffering == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
