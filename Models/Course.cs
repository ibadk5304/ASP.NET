using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nscccoursemap_ibadk5304.Models
{

    [Table("Courses")]
    public class Course
    {


        public int Id { get; set; } // primary key - auto number

        [Required]
        // [RegularExpression(@"^[A-Z]{4}\s{1}[0-9]{4}*$",
        //  ErrorMessage = "Characters are not allowed.")]
        public string CourseCode { get; set; }
        [Required]
        [MaxLength(100),MinLength(5)]
        public string Title { get; set; }
        

        //NAV property
        public ICollection<CourseOffering> CourseOfferings { get; set; }
        public ICollection<CoursePrerequisite> Prerequisites { get; set; } //many
        public ICollection<CoursePrerequisite> IsPrerequisiteFor { get; set; } //many
    }
}

