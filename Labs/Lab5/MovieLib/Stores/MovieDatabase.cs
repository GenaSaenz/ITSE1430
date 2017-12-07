/*Gena (Annie) Saenz
ITSE 1430
Lab 4 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.Stores
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary>Adds the movie.</summary>
        /// <param name="movie"></param>
        /// <returns>The added movie.</returns>
        public Movie Add( Movie movie )
        {
            //Validate
            if (movie == null)
            {
                throw new NullReferenceException("Movie cannot be empty.");
            };

            //Using IValidatableObject
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            ///<summary>Throws an exception if title is a duplicate title when adding new movie.</summary>
            foreach (var tempMovie in GetAllCore())
            {
                if (tempMovie.Title == movie.Title)
                {
                    throw new DuplicateNameException("Movie title already exists.");
                }
            }

            return AddCore(movie);
        }

        /// <summary>Get a specific movie.</summary>
        /// <returns>The movie, if it exists.</returns>
        public Movie Get( int id )
        {
            ///<summary>Throws an exception if id is out of valid range.</summary>
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be greater than 0.");
            }

            return GetCore(id);
        }

        /// <summary>Gets all movies.</summary>
        /// <returns>The movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        /// <summary>Removes the movie.</summary>
        /// <param name="id">The movie to remove.</param>
        public void Remove( int id )
        {
            ///<summary>Throws an exception if id is out of valid range.</summary>
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be greater than 0.");
            }

            RemoveCore(id);  
        }

        /// <summary>Updates a movie.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        public Movie Update( Movie movie )
        {
            if (movie == null)
            {
                throw new NullReferenceException("Movie cannot be empty.");
            };

            //Using IValidatableObject
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            //Get existing movie
            var existing = GetCore(movie.Id);
            if (existing == null)
                return null;

            ///<summary>Throws an exception if title is a duplicate title when adding new movie.</summary>
            foreach (var tempMovie in GetAllCore())
                if (tempMovie.Title == movie.Title && tempMovie.Description != movie.Description )
            {
                    throw new DuplicateNameException("Movie title already exists with.");
            };

            return UpdateCore(existing, movie);
        }

        #region Protected Members

        protected abstract Movie GetCore( int id );

        protected abstract IEnumerable<Movie> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Movie UpdateCore( Movie existing, Movie newItem );

        protected abstract Movie AddCore( Movie product );
#endregion

    }
}

