using FoodApp.Data.Account;
using FoodApp.Domain;

namespace FoodApp.Services.Account
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository = new AccountRepository();

        /// <summary>
        /// register
        /// </summary>
        /// <param name="user"></param>
        public void Register(User user)
        {
            this.accountRepository.Register(user);
        }

        /// <summary>
        /// To check wheather exists already
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool IsExists(string UserName)
        {
            return this.accountRepository.IsExists(UserName);
        }

        /// <summary>
        /// To request to promote as Cook
        /// </summary>
        /// <param name="p"></param>
        public void RequestPromotion(int userId, int verificationNumber)
        {
            this.accountRepository.RequestPromotion(userId,verificationNumber);
        }

        /// <summary>
        /// To verify Promotion as Cook
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="VerificationNumber"></param>
        /// <returns></returns>
        public bool VerifyPromotion(int userId, int VerificationNumber)
        {
            return this.accountRepository.VerifyPromotion(userId, VerificationNumber);
        }
    }
}
