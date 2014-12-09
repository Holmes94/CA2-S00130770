using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CA2_NiallHolmes_S00130770.Models;

namespace CA2_NiallHolmes_S00130770.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private MovieDB db = new MovieDB();

        public ActionResult Index(string sortOrder)
        {
            //var q = db.Movies.ToList();
            IQueryable<Movie> Movies = db.Movies;

            //sorting movies in alphabetical order
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    Movies = Movies.OrderByDescending(m => m.MovieName);
                    break;
                default:
                    Movies = Movies.OrderBy(m => m.MovieName);
                    break;
            }
            
            ViewBag.GenreComedy = db.Movies.Count(m => m.Genre == Genre.Comedy );
            ViewBag.GenreAction = db.Movies.Count(m => m.Genre == Genre.Action);
            ViewBag.GenreHorror = db.Movies.Count(m => m.Genre == Genre.Horror);
            ViewBag.GenreCrime = db.Movies.Count(m => m.Genre == Genre.Crime);
            ViewBag.GenreDrama = db.Movies.Count(m => m.Genre == Genre.Drama);
            ViewBag.GenreRomance = db.Movies.Count(m => m.Genre == Genre.Romance);
            ViewBag.GenreAnimation = db.Movies.Count(m => m.Genre == Genre.Animation);



            //if (q == null) return View();
            //else
            return View(Movies.ToList());


        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var q = db.Movies.Find(id);
            if (q == null)
            {
                Debug.WriteLine("Record not found");
                ViewBag.PageTitle = String.Format("Sorry, record {0} not found.", id);
            }
            else ViewBag.PageTitle = "Movie Name:" + q.MovieName + " (" + ((q.Actors.Count == 0) ? "No Actors" : q.Actors.Count.ToString()) + ')';
            return View(q);
   
        }
        // Partial View of Actor Details
        public PartialViewResult ActorsById(int id)
        {
            return PartialView("ActorsInMovie", db.Movies.Find(id).Actors);
           
        }


        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateActor()
        {
            return View();
        }
        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Movie incomingMovie)
        {
            try
            {
                db.Movies.Add(incomingMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateActor(Actor incomingActor)
        {
            try
            {
                db.Actors.Add(incomingActor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Movies = db.Movies.ToList();
            return View(db.Movies.Find(id));
        }

        public ActionResult EditActor(int id)
        {
            ViewBag.Actors = db.Actors.ToList();
            return View(db.Actors.Find(id));
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie editMovie)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(editMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditActor(Actor editActor)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(editActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View(db.Movies.Find(id));
        }//end delete

        public ActionResult DeleteActors(int id)
        {
            return View(db.Actors.Find(id));
        }//end delete

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }//end delete

        [HttpPost, ActionName("DeleteActors")]
        public ActionResult DeleteConfirmed1(int id)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }//end deleteActors
    }
}
