// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiResponseModel.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   The default response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Api.Models
{
    using FoodApp.Domain;
    using System.Collections.Generic;

    #region  response models

    /// <summary>
    ///     The default response.
    /// </summary>
    public class DefaultResponse
    {
        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public ApiStatusCode Status { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// The cart response
    /// </summary>
    public class CartResponse : DefaultResponse
    {
        /// <summary>
        /// the cart items
        /// </summary>
        public IList<CartItem> Items { get; set; }

        /// <summary>
        /// the total amount
        /// </summary>
        public double Total { get; set; }
    }

    /// <summary>
    /// The Items
    /// </summary>
    public class ItemsResponseModel : DefaultResponse
    {
        /// <summary>
        /// The Items
        /// </summary>
        public IList<FoodItem> Items { get; set; }
    }

    /// <summary>
    /// ItemResponse Mode
    /// </summary>
    public class ItemResponseModel : DefaultResponse
    {

        /// <summary>
        /// ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Item Name
        /// </summary>
        public string ItemName { get; set; }
    }

    /// <summary>
    /// The food response
    /// </summary>
    public class FoodResponseModel : DefaultResponse
    {
        /// <summary>
        /// The Food List
        /// </summary>
        public IList<ApiFoodModel> Foods { get; set; }
    }

    #endregion
}