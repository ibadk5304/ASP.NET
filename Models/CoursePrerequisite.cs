using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models
{

    [Table("CoursePrerequisites")]
    //[Index(nameof(CourseId),nameof(PrerequisiteId),IsUnique=true)]

    
    public class CoursePrerequisite
    {


        public int Id { get; set; } // primary key - auto number
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int PrerequisiteId { get; set; }

        public Course Course { get; set; }

        public Course Prerequisite { get; set; }
    }
}

