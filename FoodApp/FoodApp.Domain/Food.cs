using System;
using System.ComponentModel.DataAnnotations;
namespace FoodApp.Domain
{
    /// <summary>
    /// The food
    /// </summary>
    public class Food
    {
        /// <summary>
        /// The ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Item Id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The Item Name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// The quantity
        /// </summary>
        [Required]
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// The price per quantity
        /// </summary>
        [Required]
        [Range(0.0,double.MaxValue)]
        public double Price { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double  Longitude { get; set; }

        /// <summary>
        /// The deliverable time
        /// </summary>
        [Required]
        public DateTime DeliverableTime { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// The cook Id
        /// </summary>
        public int CookId { get; set; }

        /// <summary>
        /// The location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// the home address
        /// </summary>
        public string HomeAddress { get; set; }
        
        /// <summary>
        /// the landmark
        /// </summary>
        public string Landmark { get; set; }
    }

    /// <summary>
    /// the Api Food Model
    /// </summary>
    public class ApiFoodModel : Food
    {
        /// <summary>
        /// The cook Details
        /// </summary>
        public virtual UserProfile Cook { get; set; }

        /// <summary>
        /// The distance
        /// </summary>
        public double Distance { get; set; }
    }
}
