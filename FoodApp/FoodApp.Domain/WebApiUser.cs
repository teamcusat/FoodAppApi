using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodApp.Domain
{

    /// <summary>
    ///     The web api user.
    /// </summary>
    public class WebApiUser : IdentityUser,IUser
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the oauth id.
        /// </summary>
        public Guid OauthId { get; set; }

        /// <summary>
        ///     Gets or sets the password hash.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        ///     Gets or sets the security stamp.
        /// </summary>
        public string SecurityStamp { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Gets the id.
        /// </summary>
        public string Id
        {
            get
            {
                return this.UserId;
            }
        }

        /// <summary>
        ///     Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        #endregion
    }
}
