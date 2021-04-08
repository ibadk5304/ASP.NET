using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models
{

    [Table("CourseOfferings")]
    //[Index(nameof(CourseId),nameof(InstructorId),nameof(DiplomaProgramYearSectionId),nameof(SemesterId),IsUnique=true)]

    public class CourseOffering
    {


        public int Id { get; set; } // primary key - auto number

        [Required]
        public int CourseId { get; set; }
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public int DiplomaProgramYearSectionId { get; set; }
        [Required]
        //
        public int SemesterId { get; set; }
        public bool IsDirectedElective { get; set; } = false;
        
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }
        public Semester Semester { get; set; }


        //NAV property

    }
}

