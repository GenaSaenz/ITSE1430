/*Gena (Annie) Saenz
ITSE 1430
Lab 5 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    /// <summary>Provides extensions for <see cref="IMovieDatabase"/>.</summary>
    public static class MovieDatabaseExtensions
    {
        /// <summary>Get a movie by title.</summary>
        /// <param name="source">The source.</param>
        /// <param name="title">The movie title.</param>
        /// <returns>The movie, if found.</returns>
        public static Movie GetByTitle( this IMovieDatabase source, string title )
        {
            foreach (var item in source.GetAll())
            {
                if (String.Compare(item.Title, title, true) == 0)
                    return item;
            };

            return null;
        }


        /// <summary>Adds seed data to a database.</summary>
        /// <param name="source">The data to seed.</param>
        public static void WithSeedData( this IMovieDatabase source )
        {
            source.Add(new Movie() { Id = 1, Title = "Saving Private Ryan", Description = "WWII movie with Tom Hanks and Matt Damon", Length = 180,
                                      IsOwned = true });
            source.Add(new Movie() { Id = 2, Title = "The 5th Element", Length = 120, IsOwned = true });
            source.Add(new Movie() { Id = 3, Title = "What About Bob", Description = "Comedy with Bill Murray", Length = 118, IsOwned = false });
            source.Add(new Movie() { Id = 4, Title = "Crouching Tiger, Hidden Dragon", Length = 145, IsOwned = true });
        }
    }
}


