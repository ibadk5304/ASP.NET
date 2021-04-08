using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_DiplomaProgramYears
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public DiplomaProgramYear DiplomaProgramYear { get; set; }
        // public List<CourseOffering> CourseOfferings { get; set;} 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgramYear = await _context.DiplomaProgramYears
                                // .Include(d => d.DiplomaProgram)
                                // .Include(dpys=> dpys.DiplomaProgramYearSections)
                                //     .ThenInclude(dpys => dpys.CourseOfferings)
                                //         .ThenInclude(co=> co.Course)
                                // .Include(dpys=> dpys.DiplomaProgramYearSections)
                                //     .ThenInclude(dpys => dpys.CourseOfferings)
                                //         .ThenInclude(co=> co.Instructor)
                                // .Include(dpys=> dpys.DiplomaProgramYearSections)
                                //     .ThenInclude(dpys => dpys.CourseOfferings)
                                //         .ThenInclude(co=> co.Semester)
                                // .OrderBy(dpys => dpys.DiplomaProgramYearSections)
                                .FirstOrDefaultAsync(m => m.Id == id);
            // CourseOfferings = await _context.CourseOfferings.ToList();

            if (DiplomaProgramYear == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
