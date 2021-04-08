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
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get;set; }

        public async Task OnGetAsync()
        {
            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                    .ThenInclude( d=> d.DiplomaProgramYear)
                        .ThenInclude( d=> d.DiplomaProgram)
                .OrderBy(dp=> dp.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title)
                    .ThenBy(dpy=> dpy.DiplomaProgramYearSection.DiplomaProgramYear.Title)
                        .ThenBy(dpy=> dpy.DiplomaProgramYearSection.Title)
                .Include(a => a.Instructor)
                .ToListAsync();
        }
    }
}
