/*Gena (Annie) Saenz
ITSE 1430
Lab 3 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Stores
{
    /// <summary>Base class for movie database.</summary>
    public class SeededMemoryMovieDatabase : MemoryMovieDatabase
    {
        public SeededMemoryMovieDatabase ()
        {
            AddCore(new Movie() { Id = 1, Title = "Saving Private Ryan", Description = "WWII movie with Tom Hanks and Matt Damon", Length = 180,
                IsOwned = true });
            AddCore(new Movie() { Id = 2, Title = "The 5th Element", Length = 120, IsOwned = true });
            AddCore(new Movie() { Id = 3, Title = "What About Bob", Description = "Comedy with Bill Murray", Length = 118, IsOwned = false });
            AddCore(new Movie() { Id = 4, Title = "Crouching Tiger, Hidden Dragon", Length = 145, IsOwned = true });
        }
    }
}
