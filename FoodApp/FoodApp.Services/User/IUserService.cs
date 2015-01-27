using FoodApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodApp.Service.Users
{
    public interface IUserService
    {
        /// <summary>
        /// To get The user
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        User Get(string UserName);

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
