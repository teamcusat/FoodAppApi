using FoodApp.Domain;
using System.Collections.Generic;

namespace FoodApp.Data.Foods
{
    public interface IFoodRepository
    {
        /// <summary>
        /// Get Items
        /// </summary>
        /// <returns></returns>
        IList<FoodItem> GetItems();

        /// <summary>
        /// To add foodItem
        /// </summary>
        /// <param name="ItemName"></param>
        int AddFoodItem(string ItemName);

        /// <summary>
        /// To delete Food Items
        /// </summary>
        /// <param name="itemId"></param>
        void DeleteFoodItem(int itemId);

        /// <summary>
        /// To add Food
        /// </summary>
        /// <param name="food"></param>
        void Add(Food food);

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        IList<ApiFoodModel> GetFood(double? latitude, double? longitude, double? distance,int UserId);

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IList<ApiFoodModel> GetFood(double? latitude, double? longitude, string keyword, int UserId);

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IList<ApiFoodModel> GetFood(double? latitude, double? longitude, double? distance, string keyword, int UserId);

        /// <summary>
        /// To get All foods
        /// </summary>
        /// <returns></returns>
        IList<ApiFoodModel> GetAll();

        /// <summary>
        /// To get a food
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        Food Get(int foodId);
    }
}
