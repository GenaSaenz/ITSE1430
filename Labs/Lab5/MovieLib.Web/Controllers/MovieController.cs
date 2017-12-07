/*Gena (Annie) Saenz
ITSE 1430
Lab 5 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieLib.Web.Models;
using System.Configuration;
using MovieLib.Stores.Sql;

namespace MovieLib.Web.Controllers
{
    public class MovieController : Controller
    {
        public MovieController () : this(GetDatabase())
        {

        }

        public MovieController ( IMovieDatabase database )
        {
            _database = database;
        }

        //GET: Movie
        public ActionResult List()
        {
            var movies = _database.GetAll();
            return View(movies.ToModel());
        }

        public ActionResult Add()
        {
            var model = new MovieViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add ( MovieViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Add(model.ToDomain());
                    return RedirectToAction("List");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };
            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie.ToModel());
        }

        [HttpPost]
        public ActionResult Edit ( MovieViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.ToDomain());
                    return RedirectToAction("List");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };
            return View(model);
        }

        public ActionResult Delete (int id)
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie.ToModel());
        }

        [HttpPost]
        public ActionResult Delete( MovieViewModel model )
        {
            try
            {
                _database.Remove(model.Id);
                return RedirectToAction("List");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };
            return View(model);
        }

        private static IMovieDatabase GetDatabase()
        {
            var connstring = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            return new SqlMovieDatabase(connstring.ConnectionString);
        }

        private readonly IMovieDatabase _database;
    }
}