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
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaProgramYear> DiplomaProgramYear { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaProgramYear = await _context.DiplomaProgramYears
                .Include(d => d.DiplomaProgram)
                .OrderBy(d=>d.DiplomaProgram)
                    .ThenBy(d=>d.Title)
                .ToListAsync();
        }
    }
}
