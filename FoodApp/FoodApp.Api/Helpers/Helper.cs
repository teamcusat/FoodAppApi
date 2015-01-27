namespace FoodApp.Api.Helpers
{
    using FoodApp.Domain;
    using FoodApp.Service.Users;
    using System.Web;
    using FoodApp.Framework;

    /// <summary>
    /// The Helper class
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// To get the current user
        /// </summary>
        public static User User
        {
            get
            {
                if (HttpContext.Current.User == null || !HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }
                return new CacheService().GetSession<User>(SessionKeys.UserProfile, () => GetUser(HttpContext.Current.User.Identity.Name));
            }
        }

        /// <summary>
        /// To get User
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static User GetUser(string userName)
        {
            return new UserService().Get(userName);
        }
    }
}