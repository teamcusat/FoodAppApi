using FoodApp.Data.Users;
using FoodApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Service.Users
{
    public class UserService:IUserService
    {
        /// <summary>
        /// The user Repository
        /// </summary>
        public IUserRepository userRepository{ get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        /// <summary>
        /// To get The user
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public User Get(string userName)
        {
            return this.userRepository.Get(userName);
        }

        /// <summary>
        /// To get all users
        /// </summary>
        /// <returns></returns>
        public IList<User> Get()
        {
            return this.userRepository.Get();
        }

        /// <summary>
        /// To delete User
        /// </summary>
        /// <param name="UserName"></param>
        public void Delete(string UserName)
        {
            this.userRepository.Delete(UserName);
        }

        /// <summary>
        /// To promote a user as Cook
        /// </summary>
        /// <param name="UserName"></param>
        public void Promote(string UserName)
        {
            this.userRepository.Promote(UserName);
        }

    }
}
