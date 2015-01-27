using FoodApp.Domain;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace FoodApp.Data.Users
{
    /// <summary>
    /// The userRepository
    /// </summary>
    public class UserRepository:RepositoryBase,IUserRepository
    {
        /// <summary>
        /// To get The user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User Get(string userName)
        {
            using (this.Connection)
            {
                string Query = @"select * from UserProfile where Username=@UserName";
                return this.Connection.Query<User>(Query, new {UserName=userName }).FirstOrDefault();
            }
        }

        /// <summary>
        /// To get all users
        /// </summary>
        /// <returns></returns>
        public IList<User> Get()
        {
            using (this.Connection)
            {
                string Query = @"select * from UserProfile UP";
                return this.Connection.Query<User>(Query).ToList();
            }

        }

        /// <summary>
        /// To delete User
        /// </summary>
        /// <param name="UserName"></param>
        public void Delete(string userName)
        {
            using (this.Connection)
            {

                string Query = @"delete C from Cart C inner join UserProfile UP on C.UserId=UP.UserID where UP.Username=@UserName;delete F from Food F inner join UserProfile UP on F.CookId=UP.UserID where UP.Username=@UserName;delete from UserProfile where Username=@UserName; Delete from AspNetUsers where Username=@UserName";
                this.Connection.Execute(Query, new { UserName = userName });
            }

        }

        /// <summary>
        /// To promote a user as Cook
        /// </summary>
        /// <param name="UserName"></param>
        public void Promote(string UserName)
        {
            using (this.Connection)
            {
                string Query = @"Update UserProfile set RoleId=@CookRole where Username=@UserName";
                this.Connection.Execute(Query, new { UserName ,CookRole=Role.Cook });
            }
        }

    }
}
