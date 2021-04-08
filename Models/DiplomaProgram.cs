using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models{

    [Table("DiplomaPrograms")]
    //[Index(nameof(Title),IsUnique=true)]

    public class DiplomaProgram{
   

        public int Id { get; set; } // primary key - auto number

        [Required]
        [MinLength(10)]

        public string Title { get; set; }

        //NAV property
        public ICollection<DiplomaProgramYear> DiplomaProgramYears { get; set;} //many

        
    }
}

