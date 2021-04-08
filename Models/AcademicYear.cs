using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models{

    [Table("AcademicYears")]
    //[Index(nameof(Title),IsUnique=true)]

    public class AcademicYear{
   

        public int Id { get; set; } // primary key - auto number

        [Required]
        [MaxLength(20),MinLength(5)]

        public string Title { get; set; }

        //NAV property
        public ICollection<Semester> Semesters { get; set;} 
        public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set;} //many
    }
}

