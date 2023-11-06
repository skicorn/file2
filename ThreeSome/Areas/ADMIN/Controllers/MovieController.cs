using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class MovieController : Controller
    {
        DATAWEBPHIMEntities database = new DATAWEBPHIMEntities();
        // GET: ADMIN/Movie
        public ActionResult MoviePage()
        {
            return View(database.MOVIEs.ToList());
        }
        #region "TAO MOI"
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MOVIE movie)
        {
            database.MOVIEs.Add(movie);
            database.SaveChanges();
            return RedirectToAction("MoviePage");
        }
        #endregion
        #region "XOA VIDEO"
        public ActionResult Delete(int id) 
        {
            return View(database.MOVIEs.Where(movie => movie.movieId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, MOVIE movie)
        {
            movie = database.MOVIEs.Where(m => m.movieId == id).FirstOrDefault();
            database.MOVIEs.Remove(movie);
            database.SaveChanges();
            return RedirectToAction("MoviePage");
        }
        #endregion
        #region "THONG TIN VIDEO"
        public ActionResult Info(int id)
        {
            return View(database.MOVIEs.Where(s => s.movieId == id).FirstOrDefault());
        }
        #endregion
        #region "SUA VIDEO"
        public ActionResult Edit(int id)
        {
            return View(database.MOVIEs.Where(m => m.movieId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, MOVIE movie)
        {
            database.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("MoviePage");
        }
        #endregion
    }
}