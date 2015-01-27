using FoodApp.Domain;
using FoodApp.Service.Foods;
using FoodApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApp.Web.Controllers
{
    [AdminFilter]
    public class FoodController : Controller
    {

        private IFoodService foodService { get; set; }

        public FoodController()
        {
            this.foodService = new FoodService();
        }

        public ActionResult Index()
        {
            IList<ApiFoodModel> foods = this.foodService.GetAll();
            return View(foods);
        }

        public ActionResult Add(Food food)
        {
            this.foodService.Add(food);
            return RedirectToAction("Index");
        }
    }
}
