using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Data;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Pages_CoursePrerequisites
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_ibadk5304.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_ibadk5304.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CoursePrerequisite> CoursePrerequisite { get;set; }

        public async Task OnGetAsync()
        {
            CoursePrerequisite = await _context.CoursePrerequisites
                .Include(c => c.Course)
                .Include(c => c.Prerequisite)
                .OrderBy(c =>c.Course.CourseCode)
                    .ThenBy(c=>c.Prerequisite.CourseCode)
                .ToListAsync();
        }
    }
}
