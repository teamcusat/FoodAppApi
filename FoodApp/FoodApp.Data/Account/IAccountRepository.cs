using FoodApp.Domain;
namespace FoodApp.Data.Account
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        void Register(UserProfile user);

                /// <summary>
        /// To check wheather exists already
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        bool IsExists(string UserName);
    }
}
