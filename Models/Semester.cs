using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;

namespace nscccoursemap_ibadk5304.Models{
    

    [Table("Semesters")]
    //[Index(nameof(Name),IsUnique=true)]

    public class Semester: IValidatableObject
    {
        public int Id { get; set; } // primary key - auto number

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        // [DateTimeCompare("EndDate", ValueComparison.IsLessThan,    
        // ErrorMessage = "Start date must be earlier than end date.")] 
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Required]       
        public int AcademicYearId { get; set; }

        public AcademicYear AcademicYear { get; set; }

        //NAV property
        public ICollection<CourseOffering> CourseOfferings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate  > EndDate)
            {
                yield return new ValidationResult(
                    errorMessage:"Start date must be smaller than end date");
            }
        }
    }

        
}

