using FoodApp.Domain;

namespace FoodApp.Services.Account
{
    public interface IAccountService
    {
        /// <summary>
        /// To register
        /// </summary>
        /// <param name="model"></param>
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
        void RequestPromotion(int userId,int verificationNumber);

        /// <summary>
        /// To verify Promotion as Cook
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="VerificationNumber"></param>
        /// <returns></returns>
        bool VerifyPromotion(int userId, int VerificationNumber);
    }
}
