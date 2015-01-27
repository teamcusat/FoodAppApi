using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApp.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string error)
        {
            var user = Helper.User;
            if (user == null)
            {
                ViewBag.Error = error;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

    }
}
