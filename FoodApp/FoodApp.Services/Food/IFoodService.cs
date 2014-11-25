using FoodApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodApp.Service.Food
{
    public interface IFoodService
    {
        /// <summary>
        /// Get items
        /// </summary>
        /// <returns></returns>
        IList<FoodItem> GetItems();
    }
}
