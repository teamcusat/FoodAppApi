using FoodApp.Domain;
using FoodApp.Framework;
using System;

namespace FoodApp.Web
{
    public static class Helper
    {
        public static ICacheService cacheService=new CacheService();

        public static User User
        {
            get
            {
                return cacheService.GetSession<User>(SessionKeys.UserProfile,()=>{return null;});
            }
        }

        public static void Login(string Username,string Password)
        {
            if(Username=="Admin" && Password=="Admin123")
            {
                cacheService.RemoveSession(SessionKeys.UserProfile);
                cacheService.GetSession(SessionKeys.UserProfile,()=>{return new User(){UserName=Username};});
            }
        }


        public static void Logoff()
        {
            cacheService.RemoveSession(SessionKeys.UserProfile);
        }
    }
}