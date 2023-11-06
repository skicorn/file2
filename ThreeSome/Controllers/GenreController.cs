using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class GenreController : Controller
    {
        DATAWEBPHIMEntities database = new DATAWEBPHIMEntities();
        // GET: Genre
        public ActionResult Genre()
        {
            var videosByGenre = database.MOVIEs
                  .GroupBy(movie => movie.movieGenre)
                  .Select(group => new
                   {
                       Genre = group.Key,
                       Videos = group.Select(movie => new
                       {
                           Title = movie.movieName,
                           Genre = movie.movieGenre,
                           VideoPath = movie.movieURL
                       }).ToList()
                   })
                   .ToList();

            return View(videosByGenre);
        }
    }
}