using FoodApp.Data.Account;
using FoodApp.Domain;

namespace FoodApp.Services.Account
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository=new AccountRepository();

        /// <summary>
        /// register
        /// </summary>
        /// <param name="user"></param>
        public void Register(UserProfile user)
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
    }
}
