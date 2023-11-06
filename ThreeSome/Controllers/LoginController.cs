using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class LoginController : Controller
    {
        DATAWEBPHIMEntities database = new DATAWEBPHIMEntities();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult AuthenLogin(USER user)
        {
            var check = database.USERS.Where(u => u.userName.Equals(user.userName)
            && u.userPass == user.userPass).FirstOrDefault();
            if(check == null)
            {
                ViewBag.ErrorLog = "Mày đã nhập sai username hoặc password";
                return View("LoginPage");
            }
            else
            {
                var check_user = database.USERS.FirstOrDefault(u => u.userName == user.userName);
                if (check_user.userName != "admin")
                {
                    Session["Username"] = user.userName;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("AdminPage","Admin",new {area = "ADMIN"});
                }
            }
        }

        public ActionResult Register()
        {
            return View();
        }
      
    }
}