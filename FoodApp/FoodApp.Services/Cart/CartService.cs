
using FoodApp.Data.Cart;
using FoodApp.Domain;
using System.Collections.Generic;
namespace FoodApp.Services.Cart
{
    /// <summary>
    /// The cart service
    /// </summary>
    public class CartService:ICartService
    {
        /// <summary>
        /// The cart repository
        /// </summary>
        public ICartRepository cartRepository { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public CartService()
        {
            cartRepository = new CartRepository();
        }

        /// <summary>
        /// To get the cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IList<CartItem> Get(int UserId)
        {
            return this.cartRepository.Get(UserId);
        }

        /// <summary>
        /// To add to cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FoodId"></param>
        /// <param name="Quantity"></param>
        public void Add(int UserId, int FoodId, int Quantity)
        {
            this.cartRepository.Add(UserId, FoodId, Quantity);
        }

        /// <summary>
        /// To remove from cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FoodId"></param>
        /// <param name="Quantity"></param>
        public void Remove(int UserId, int CartId)
        {
            this.cartRepository.Remove(UserId, CartId);
        }


    }
}
