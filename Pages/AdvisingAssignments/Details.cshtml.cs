using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_AdvisingAssignments
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public AdvisingAssignment AdvisingAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                    .ThenInclude(dpys => dpys.DiplomaProgramYear)
                        .ThenInclude(dpy => dpy.DiplomaProgram)
                .Include(a => a.Instructor).FirstOrDefaultAsync(m => m.Id == id);

            if (AdvisingAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
