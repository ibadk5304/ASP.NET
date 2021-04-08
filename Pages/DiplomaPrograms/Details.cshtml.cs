using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_DiplomaPrograms
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public DiplomaProgram DiplomaProgram { get; set; }

        public int YearCount { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgram = await _context.DiplomaPrograms
                            .Include(dp=>dp.DiplomaProgramYears)
                            .FirstOrDefaultAsync(m => m.Id == id);


            if (DiplomaProgram == null)
            {
                return NotFound();
            }
            ViewData["YearCount"] = DiplomaProgram.DiplomaProgramYears.Count;

            return Page();
        }
    }
}
