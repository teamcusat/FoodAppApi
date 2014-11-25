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
    /// The Items
    /// </summary>
    public class ItemsResponseModel :DefaultResponse
    {
        /// <summary>
        /// The Items
        /// </summary>
        public IList<FoodItem> Items { get; set; }
    }
    
    #endregion
}