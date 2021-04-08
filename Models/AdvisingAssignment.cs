using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models
{

    [Table("AdvisingAssignments")]
    //[Index(nameof(InstructorId),nameof(DiplomaProgramYearSectionId),IsUnique=true)]

    public class AdvisingAssignment
    {


        public int Id { get; set; } // primary key - auto number
        [Required]

        public int InstructorId { get; set; }
        [Required]

        public int DiplomaProgramYearSectionId { get; set; }
        
        public Instructor Instructor { get; set; }
        public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }


    }
}

