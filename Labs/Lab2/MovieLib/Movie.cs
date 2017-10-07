/*Gena (Annie) Saenz
ITSE 1430
Lab 2 - Due 10/9/17 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class Movie
    {
        public string Title
        {
            get {
                return _title ?? "";
            }

            set {
                _title = value?.Trim();
            }
        }

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        public int Length { get; set; }

        public bool IsOwned { get; set; }

        private string _title;
        private string _description;

        public override string ToString()
        {
            return Title;
        }

        public virtual string Validate()
        {
            if (String.IsNullOrEmpty(Title))
                return "Name cannot be empty.";

             if (Length < 0)
                return "Length must be >= 0.";

            return null;
        }
    }
}
