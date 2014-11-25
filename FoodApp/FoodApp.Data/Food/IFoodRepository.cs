using FoodApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodApp.Data.Food
{
    public interface IFoodRepository
    {
        /// <summary>
        /// Get Items
        /// </summary>
        /// <returns></returns>
        IList<FoodItem> GetItems();
    }
}
