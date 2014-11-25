
namespace FoodApp.Domain
{
    public class FoodPurchase
    {
        public int Id { get; set; }

        public Food Food { get; set; }

        public int Quantity { get; set; }
    }
}
