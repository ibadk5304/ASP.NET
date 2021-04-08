using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_AdvisingAssignments
{
    public class CreateModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public CreateModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {


        var LongText= _context.DiplomaProgramYearSections
                        .Select( d=>new
                        {
                            Id=d.Id, 
                            fulltext= d.DiplomaProgramYear.DiplomaProgram.Title+" - "+d.DiplomaProgramYear.Title+" - "+d.Title
        
                        });

           ViewData["DiplomaProgramYearSectionId"] = new SelectList(LongText, "Id", "fulltext");
            // Select all records from the database and store in a variable
            // Create a new "column" in that array and concatenate the first and last names together


           var fullname= _context.Instructors.Select(i=> new{Id=i.Id,fullname = i.FirstName+" "+i.LastName });

            ViewData["InstructorId"] = new SelectList(fullname, "Id", "fullname");
            return Page();
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdvisingAssignments.Add(AdvisingAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
