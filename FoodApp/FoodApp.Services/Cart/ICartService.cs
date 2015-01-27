
using FoodApp.Domain;
using System.Collections.Generic;
namespace FoodApp.Services.Cart
{
    /// <summary>
    /// The I cart service
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// To get the cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IList<CartItem> Get(int UserId);

        /// <summary>
        /// To add to cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FoodId"></param>
        /// <param name="Quantity"></param>
        void Add(int UserId, int FoodId, int Quantity);

        /// <summary>
        /// To remove from cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FoodId"></param>
        /// <param name="Quantity"></param>
        void Remove(int UserId, int CartId);

    }
}
