
namespace FoodApp.Domain
{
    /// <summary>
    /// The cart Item
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// The cart Item Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Item Name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// The Item Quantity
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// the price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// the amount
        /// </summary>
        public double Amount
        {
            get
            {
                return Price * Quantity;
            }
        }

        /// <summary>
        /// The maximum allowed Quantity
        /// </summary>
        public int MaxQuantity { get; set; }
    }
}
