using FoodApp.Framework;
using FoodApp.Service.Users;
using FoodApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApp.Web.Controllers
{
    [AdminFilter]
    public class UserController : Controller
    {
        /// <summary>
        /// The user Service
        /// </summary>
        private IUserService userService { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public UserController()
        {
            userService = new UserService();
        }

        /// <summary>
        /// The Users
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var users = this.userService.Get();
            return View(users);
        }

        ///// <summary>
        ///// To delete a user
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <returns></returns>
        //public ActionResult Delete(string UserName)
        //{
        //    this.userService.Delete(UserName);
        //    return RedirectToAction("Index");
        //}
        /// <summary>
        /// To promote a user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult Promote(string UserName)
        {
            this.userService.Promote(UserName);
            SendPromotionMessage(UserName);
            return RedirectToAction("Index");
        }

        public void SendPromotionMessage(string Email)
        {
            try
            {
                var replacements = new ListDictionary()
                {
                    {"<<UserName>>",Email}
                };
                new Mailer().SendMail(replacements, "Promotion.html", Email, "FoodApp - Promoted as Cook");
            }
            catch (Exception e)
            {

            }
        }
    }
}
