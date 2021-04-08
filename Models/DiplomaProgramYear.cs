using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models{

    [Table("DiplomaProgramYears")]
    //[Index(nameof(Title),nameof(DiplomaProgramId),IsUnique=true)]

    public class DiplomaProgramYear{
   

        public int Id { get; set; } // primary key - auto number

        [Required]
        // [RegularExpression(@"^[Year]\s{1}[1-4]{1}$",
        //  ErrorMessage = "Characters are not allowed.")]
        public string Title { get; set; }
        [Required]

        public int DiplomaProgramId { get; set; }

        public DiplomaProgram DiplomaProgram { get; set; }

        //NAV property
        public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set;} //many
    }
}

