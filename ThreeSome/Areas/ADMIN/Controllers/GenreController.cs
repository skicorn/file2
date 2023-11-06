using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class GenreController : Controller
    {
        DATAWEBPHIMEntities database = new DATAWEBPHIMEntities();
        // GET: ADMIN/Genre
        public ActionResult GenrePage()
        {
            return View(database.GENREs.ToList());
        }
        #region "TAO MOI"
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GENRE genre)
        {
            database.GENREs.Add(genre);
            database.SaveChanges();
            return RedirectToAction("GenrePage");
        }
        #endregion
        #region "XOA THE LOAI"
        public ActionResult Delete(int id)
        {
            return View(database.GENREs.Where(movie => movie.genreID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, GENRE genre)
        {
            genre = database.GENREs.Where(m => m.genreID == id).FirstOrDefault();
            database.GENREs.Remove(genre);
            database.SaveChanges();
            return RedirectToAction("GenrePage");
        }
        #endregion 
        #region "SUA THE LOAI"
        public ActionResult Edit(int id)
        {
            return View(database.GENREs.Where(m => m.genreID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, GENRE genre)
        {
            database.Entry(genre).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("GenrePage");
        }
        #endregion  
    }
}