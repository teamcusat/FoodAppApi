// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityHelper.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   The UserHelper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Core
{
    using System.Security.Principal;

    using Microsoft.AspNet.Identity;

    /// <summary>
    ///     The user helper.
    /// </summary>
    public class IdentityHelper : IIdentityHelper
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
        public virtual int GetUserId(IIdentity identity)
        {
            return int.Parse(identity.GetUserId());
        }
    }
}