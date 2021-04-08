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
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CourseOffering> CourseOffering { get;set; }

        public async Task OnGetAsync()
        {
            CourseOffering = await _context.CourseOfferings
                .Include(c => c.Course)
                .Include(c => c.DiplomaProgramYearSection)
                    .ThenInclude(d=>d.DiplomaProgramYear)
                        .ThenInclude(d=>d.DiplomaProgram)
                .Include(c => c.Instructor)
                .Include(c => c.Semester)
                .OrderByDescending(c=>c.Semester.Name)
                    .ThenBy(d=>d.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title)
                        .ThenBy(d=>d.DiplomaProgramYearSection.DiplomaProgramYear.Title)
                            .ThenBy(c=>c.Course.CourseCode)
                .ToListAsync();
        }
    }
}
