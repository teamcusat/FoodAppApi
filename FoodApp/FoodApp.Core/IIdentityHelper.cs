// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIdentityHelper.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   The UserHelper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Core
{
    using System.Security.Principal;

    /// <summary>
    ///     The UserHelper interface.
    /// </summary>
    public interface IIdentityHelper
    {
        /// <summary>
        /// The get user id.
        /// </summary>
        /// <param name="identity">
        /// The identity.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetUserId(IIdentity identity);
    }
}