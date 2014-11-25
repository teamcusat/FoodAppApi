using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using FoodApp.Services.Account;
using FoodApp.Domain;

namespace FoodApp.Api.Identity
{
    /// <summary>
    ///     The user store.
    /// </summary>
    public class UserStore : IUserStore<WebApiUser>, IUserPasswordStore<WebApiUser>, IUserSecurityStampStore<WebApiUser>
    {
        /// <summary>
        ///     The _account service.
        /// </summary>
        private readonly IAccountService _accountService;
       
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UserStore"/> class.
        /// </summary>
        /// <param name="accountService">
        /// The account service.
        /// </param>
        public UserStore()
        {
            this._accountService = new AccountService();
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
        }

        #region IUserStore


        /// <summary>
        /// The create async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task CreateAsync(WebApiUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.OauthId = Guid.NewGuid();
//            this._accountService.InsertAuthInfo(user);
            return Task.FromResult(0);
        }



 
        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task DeleteAsync(WebApiUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

//            this._accountService.UpdateAuthInfo(new WebApiUser { OauthId = user.OauthId });
            return Task.FromResult(0);
        }

        /// <summary>
        /// The find by id async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task<WebApiUser> FindByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("userId");
            }

            return Task.FromResult(new WebApiUser() { UserName = "abcd", UserId = "123",PasswordHash="123456" });//this._accountService.GetUser(userId));
        }

        /// <summary>
        /// The find by name async.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task<WebApiUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName");
            }

            return Task.FromResult(new WebApiUser() { UserName = "abcd", UserId = "123",PasswordHash="123456" });//this._accountService.GetUserByUserName(userName));
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task UpdateAsync(WebApiUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

//            this._accountService.UpdateAuthInfo(user);

            return Task.FromResult(0);
        }

        #endregion

        #region IUserPasswordStore

        /// <summary>
        /// The get password hash async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task<string> GetPasswordHashAsync(WebApiUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.PasswordHash);
        }

        /// <summary>
        /// The has password async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual Task<bool> HasPasswordAsync(WebApiUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        /// <summary>
        /// The set password hash async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="passwordHash">
        /// The password hash.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task SetPasswordHashAsync(WebApiUser user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        #endregion

        #region IUserSecurityStampStore

        /// <summary>
        /// The get security stamp async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task<string> GetSecurityStampAsync(WebApiUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.SecurityStamp);
        }

        /// <summary>
        /// The set security stamp async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="stamp">
        /// The stamp.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public virtual Task SetSecurityStampAsync(WebApiUser user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }


   
        #endregion
    }
}