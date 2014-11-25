
namespace FoodApp.Domain
{
    public class Food
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Latitude { get; set; }

        public double  Longitude { get; set; }

    }
}
