using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_DiplomaProgramYearSections
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaProgramYearSection> DiplomaProgramYearSection { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaProgramYearSection = await _context.DiplomaProgramYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaProgramYear)
                    .ThenInclude(d=>d.DiplomaProgram)
                .OrderByDescending(d => d.AcademicYear)
                    .ThenBy(d => d.DiplomaProgramYear)
                        .ThenBy(d => d.Title)
                .ToListAsync();
        }
    }
}
