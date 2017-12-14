/*Gena (Annie) Saenz
 * ITSE 1430
 * Final Exam
 */
using System;

namespace MovieLib
{
    /// <summary>Provides the different types of movie ratings.</summary>
    public enum Rating  //**CR1 - I do not understand how to work with enums enough to fix this unpersistent Rating 
    {
        /// <summary>Unknown or unspecified rating.</summary>
        Unspecified = 0,

        /// <summary>General Audience.</summary>
        G = 1,

        /// <summary>Parental Guidance suggested.</summary>
        PG = 2,

        /// <summary>Parental Guidance suggested for those under 13.</summary>
        PG13 = 3,

        /// <summary>Restricted</summary>
        R = 4,
    }
}
