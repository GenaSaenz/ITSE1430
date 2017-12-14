/*Gena (Annie) Saenz
 * ITSE 1430
 * Final Exam
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieLib.Web.Models
{
    /// <summary>Provides a view model for movies.</summary>
    public class MovieViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Display(Name = "Is Owned")]
        public bool IsOwned { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Length must be > 0 minutes.")]
        public int Length { get; set; }

        [Range(0, 4)]  //**CR1 - Rating not being persistent
        public Rating Rating { get; set; }

        [Display(Name = "Release Year")]
        [Range(1900, 2100, ErrorMessage = "Release Year must be between 1900 and 2100.")]  //**CR2 - Release year limited to years between 1900 and 2100
        public int ReleaseYear { get; set; }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext ) => Enumerable.Empty<ValidationResult>();        
    }
}