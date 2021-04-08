using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models{

    [Table("DiplomaProgramYearSections")]
    //[Index(nameof(Title), nameof(DiplomaProgramYearId),nameof(AcademicYearId), IsUnique = true)]

    public class DiplomaProgramYearSection{
   

        public int Id { get; set; } // primary key - auto number
        [Required]
        // [RegularExpression(@"^[Section]\s{1}[1-4]{1}$",
        //  ErrorMessage = "Characters are not allowed.")]
        public string Title { get; set; }
        [Required]
        
        public int DiplomaProgramYearId { get; set; }
        [Required]

        public int AcademicYearId { get; set; }

        public DiplomaProgramYear DiplomaProgramYear { get; set; }
        public AcademicYear AcademicYear { get; set; }


        //NAV property
        public ICollection<AdvisingAssignment> AdvisingAssignments { get; set;} //many
        public ICollection<CourseOffering> CourseOfferings { get; set; } //many

    }
}

