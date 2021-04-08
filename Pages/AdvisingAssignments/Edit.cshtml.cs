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

namespace nscccoursemap_ibadk5304.Pages_AdvisingAssignments
{
    public class EditModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public EditModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(a => a.DiplomaProgramYearSection)
                    .ThenInclude( d=> d.DiplomaProgramYear)
                        .ThenInclude( d=> d.DiplomaProgram)
                .Include(a => a.Instructor).FirstOrDefaultAsync(m => m.Id == id);

            if (AdvisingAssignment == null)
            {
                return NotFound();
            }

            var LongText= _context.DiplomaProgramYearSections
                        .Select( d=>new
                        {
                            Id=d.Id, 
                            fulltext= d.DiplomaProgramYear.DiplomaProgram.Title+" - "+d.DiplomaProgramYear.Title+" - "+d.Title
        
                        });

           ViewData["DiplomaProgramYearSectionId"] = new SelectList(LongText, "Id", "fulltext");
            // Select all records from the database and store in a variable
            // Create a new objects the array and concatenate the first and last names together


           var fullname= _context.Instructors.Select(i=> new{Id=i.Id,fullname = i.FirstName+" "+i.LastName });

            ViewData["InstructorId"] = new SelectList(fullname, "Id", "fullname");
            // Pass the fullNames variable into the ViewData
            //ViewData['InstructorId'] = new SelectList(fullNames, "Id", "fullNames");
         
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

            _context.Attach(AdvisingAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisingAssignmentExists(AdvisingAssignment.Id))
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

        private bool AdvisingAssignmentExists(int id)
        {
            return _context.AdvisingAssignments.Any(e => e.Id == id);
        }
    }
}
