using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApp.Web.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login(string Username,string Password)
        {
            Helper.Login(Username,Password);
            var user = Helper.User;
            if(user==null)
            {
                return RedirectToAction("Index", "Home", new { error = "Invalid username or password" });
            }
            return RedirectToAction("Index", "User");
        }

        public ActionResult Logoff()
        {
            Helper.Logoff();
            return RedirectToAction("Index","Home");
        }
    }
}
