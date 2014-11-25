using FoodApp.Data.Food;
using FoodApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Service.Food
{
    public class FoodService:IFoodService
    {

        /// <summary>
        /// Foood Repository
        /// </summary>
        private IFoodRepository foodRepository { get; set; }

        public FoodService()
        {
            foodRepository = new FoodRepository();
        }

        /// <summary>
        /// GetItems
        /// </summary>
        /// <returns></returns>
        public IList<FoodItem> GetItems()
        {
            return this.foodRepository.GetItems();
        }
    }
}
