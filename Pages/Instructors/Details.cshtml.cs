using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors
                        .Include(i => i.AdvisingAssignments)
                            .ThenInclude(aa => aa.DiplomaProgramYearSection)
                                .ThenInclude(dpys =>dpys.DiplomaProgramYear)
                                    .ThenInclude(dpy => dpy.DiplomaProgram)
                        .FirstOrDefaultAsync(m => m.Id == id);

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
