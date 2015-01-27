using FoodApp.Domain;
namespace FoodApp.Data.Account
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        void Register(User user);

        /// <summary>
        /// To check wheather exists already
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        bool IsExists(string UserName);
        
        /// <summary>
        /// To request to promote as Cook
        /// </summary>
        /// <param name="p"></param>
        void RequestPromotion(int userId, int VerificationNumber);

        /// <summary>
        /// To verify Promotion as Cook
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="VerificationNumber"></param>
        /// <returns></returns>
        bool VerifyPromotion(int userId, int VerificationNumber);
    }
}
