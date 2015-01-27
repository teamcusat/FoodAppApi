// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiRequestModel.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   The blurb request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The Reset Password Request.
    /// </summary>
    public class ResetPasswordRequest
    {
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$")]
        public string Email { get; set; }
    }

    /// <summary>
    /// The food Request Model
    /// </summary>
    public class FoodRequest
    {
        /// <summary>
        /// The latitude
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// The latitude
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// The keyword
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// The distance
        /// </summary>
        public double? Distance { get; set; } 
    }

    /// <summary>
    /// The remove Cart Request
    /// </summary>
    public class RemoveCartRequest
    {
        /// <summary>
        /// The CartId
        /// </summary>
        [Required]
        [Range(1,int.MaxValue)]
        public int CartId { get; set; }
    }

    /// <summary>
    /// Add to cart Request
    /// </summary>
    public class AddToCartRequest
    {
        /// <summary>
        /// The food Id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int FoodId { get; set; }

        /// <summary>
        /// The Quantity
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

}