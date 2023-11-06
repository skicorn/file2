using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class VideoController : Controller
    {
        DATAWEBPHIMEntities database = new DATAWEBPHIMEntities();
        // GET: Video
        public ActionResult Video(int id)
        {
            MovieView movie = database.MOVIEs.Where(x=>x.movieId==id).Select(
                x => new MovieView 
                {
                    Title = x.movieName,
                    URL = x.movieURL,
                    View = x.movieView
                }).FirstOrDefault();
            return View(movie);
        }
    }
}