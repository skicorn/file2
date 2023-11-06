using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class UserController : Controller
    {
        DATAWEBPHIMEntities database = new DATAWEBPHIMEntities();
        // GET: ADMIN/User
        public ActionResult UserPage()
        {
            return View(database.USERS.ToList());
        }
        #region "TAO MOI"
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(USER user)
        {
            database.USERS.Add(user);
            database.SaveChanges();
            return RedirectToAction("UserPage");
        }
        #endregion
        #region "XOA USER"
        public ActionResult Delete(int id)
        {
            return View(database.USERS.Where(movie => movie.userID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, USER user)
        {
            user = database.USERS.Where(m => m.userID == id).FirstOrDefault();
            database.USERS.Remove(user);
            database.SaveChanges();
            return RedirectToAction("UserPage");
        }
        #endregion
        #region "THONG TIN USER"
        public ActionResult Info(int id)
        {
            return View(database.USERS.Where(s => s.userID == id).FirstOrDefault());
        }
        #endregion
        #region "SUA USER"
        public ActionResult Edit(int id)
        {
            return View(database.USERS.Where(m => m.userID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, USER user)
        {
            database.Entry(user).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("UserPage");
        }
        #endregion
    }
}