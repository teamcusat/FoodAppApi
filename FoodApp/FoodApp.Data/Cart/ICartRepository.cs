
using FoodApp.Domain;
using System.Collections.Generic;
namespace FoodApp.Data.Cart
{
    /// <summary>
    /// The ICart Repository
    /// </summary>
    public interface ICartRepository
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
