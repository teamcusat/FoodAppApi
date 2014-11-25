using FoodApp.Domain;

namespace FoodApp.Services.Account
{
    public interface IAccountService
    {
        /// <summary>
        /// To register
        /// </summary>
        /// <param name="model"></param>
        void Register(UserProfile user);

        /// <summary>
        /// To check wheather exists already
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        bool IsExists(string UserName);
    }
}
