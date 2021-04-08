using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_DiplomaProgramYearSections
{
    public class EditModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public EditModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
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
           ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");
           ViewData["DiplomaProgramYearId"] = new SelectList(_context.DiplomaProgramYears, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DiplomaProgramYearSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomaProgramYearSectionExists(DiplomaProgramYearSection.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiplomaProgramYearSectionExists(int id)
        {
            return _context.DiplomaProgramYearSections.Any(e => e.Id == id);
        }
    }
}
