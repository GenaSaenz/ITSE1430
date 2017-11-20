/*Gena (Annie) Saenz
ITSE 1430
Lab 4 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib 
{
    public class Movie : IValidatableObject
    {
        /// <summary>Gets or sets the unique Id for each movie.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the movie Title.</summary>
        /// <value>Never returns null.</value>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value?.Trim(); }
        }

        /// <summary>Gets or sets the movie description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the length of the movie.</summary>
        public int Length { get; set; }

        /// <summary>Determines if the movie is owned or not.</summary>
        public bool IsOwned { get; set; }

        private string _title;
        private string _description;

        public override string ToString()
        {
            return Title;
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //Title cannot be empty
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Title cannot be empty.", new[] { nameof(Title) });

            //Length >= 0
            if (Length < 0)
                yield return new ValidationResult("Length must be >= 0.", new[] { nameof(Length) });
        }

    }
}
