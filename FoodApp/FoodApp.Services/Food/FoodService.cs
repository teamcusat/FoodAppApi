using FoodApp.Data.Foods;
using FoodApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Service.Foods
{
    public class FoodService:IFoodService
    {

        /// <summary>
        /// Foood Repository
        /// </summary>
        private IFoodRepository foodRepository { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
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

        /// <summary>
        /// To Add Food Item
        /// </summary>
        /// <param name="ItemName"></param>
        public int AddFoodItem(string ItemName)
        {
            return this.foodRepository.AddFoodItem(ItemName);
        }

        /// <summary>
        /// To delete Food Items
        /// </summary>
        /// <param name="itemId"></param>
        public void DeleteFoodItem(int itemId)
        {
            this.foodRepository.DeleteFoodItem(itemId);
        }

        /// <summary>
        /// To add food
        /// </summary>
        /// <param name="food"></param>
        public void Add(Food food)
        {
            this.foodRepository.Add(food);
        }

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public IList<ApiFoodModel> GetFood(double? latitude, double? longitude, double? distance, int UserId)
        {
            return this.foodRepository.GetFood(latitude, longitude, distance,UserId);
        }

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<ApiFoodModel> GetFood(double? latitude, double? longitude, string keyword, int UserId)
        {
            return this.foodRepository.GetFood(latitude, longitude, keyword,UserId);
        }

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<ApiFoodModel> GetFood(double? latitude, double? longitude, double? distance, string keyword, int UserId)
        {
            return this.foodRepository.GetFood(latitude, longitude, distance,keyword,UserId);
        }

        /// <summary>
        /// To get All foods
        /// </summary>
        /// <returns></returns>
        public IList<ApiFoodModel> GetAll()
        {
            return this.foodRepository.GetAll();
        }

        /// <summary>
        /// To get a food
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        public Food Get(int foodId)
        {
            return this.foodRepository.Get(foodId);
        }

    }
}
