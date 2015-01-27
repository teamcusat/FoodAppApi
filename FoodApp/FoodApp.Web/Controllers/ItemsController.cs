using FoodApp.Data.Foods;
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
    public class ItemsController : Controller
    {
        public IFoodService foodService { get; set; }

        public ItemsController()
        {
            this.foodService = new FoodService();
        }

        public ActionResult Index()
        {
            IList<FoodItem> items = this.foodService.GetItems();
            return View(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        public ActionResult Add(string ItemName)
        {
            if(!string.IsNullOrEmpty(ItemName))
            {
                this.foodService.AddFoodItem(ItemName);
            }
            return RedirectToAction("Index");
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ItemName"></param>
        ///// <returns></returns>
        //public ActionResult Delete(int ItemId)
        //{
        //    this.foodService.DeleteFoodItem(ItemId);
        //    return RedirectToAction("Index");
        //}

    }
}
