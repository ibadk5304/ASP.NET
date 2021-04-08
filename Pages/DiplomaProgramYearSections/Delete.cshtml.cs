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
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public DeleteModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgramYearSection = await _context.DiplomaProgramYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaProgramYear).FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaProgramYearSection == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaProgramYearSection = await _context.DiplomaProgramYearSections.FindAsync(id);

            if (DiplomaProgramYearSection != null)
            {
                _context.DiplomaProgramYearSections.Remove(DiplomaProgramYearSection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
