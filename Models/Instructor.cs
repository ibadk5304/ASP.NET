using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nscccoursemap_ibadk5304.Models
{

    [Table("Instructors")]
    public class Instructor
    {


        public int Id { get; set; } // primary key - auto number
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }


        //NAV property
        public ICollection<CourseOffering> CourseOfferings { get; set; }
        public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; } //many
    }
}

