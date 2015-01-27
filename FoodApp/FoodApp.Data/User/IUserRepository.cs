using FoodApp.Domain;
using System.Collections.Generic;

namespace FoodApp.Data.Users
{
    /// <summary>
    /// The IUser Repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// To get the user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User Get(string userName);

        /// <summary>
        /// To get all users
        /// </summary>
        /// <returns></returns>
        IList<User> Get();

        /// <summary>
        /// To delete User
        /// </summary>
        /// <param name="UserName"></param>
        void Delete(string UserName);

        /// <summary>
        /// To promote a user as Cook
        /// </summary>
        /// <param name="UserName"></param>
        void Promote(string UserName);
    }
}
