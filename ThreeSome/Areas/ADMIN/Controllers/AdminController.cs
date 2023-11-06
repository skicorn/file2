using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class AdminController : Controller
    {
        // GET: ADMIN/Admin
        public ActionResult AdminPage()
        {
            return View();
        }
    }
}