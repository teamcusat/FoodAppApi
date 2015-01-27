using System.Linq;
using Dapper;
using FoodApp.Domain;

namespace FoodApp.Data.Account
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        /// <summary>
        /// To register
        /// </summary>
        /// <param name="user"></param>
        public void Register(User user)
        {
            using (this.Connection)
            {
                string Query = @"INSERT INTO UserProfile(
                    Username,
                    FirstName,
                    LastName,
                    ConfirmationToken,
                    IsArchived,
                    IsConfirmed,
                    IsLocked,
                    IsPasswordChanged,
                    IsVerified,
                    Latitude,
                    Longitude,
                    MobileNo,
                    RoleId,
                    VerificationNumber)
    
                values(
                    @UserName,
                    @FirstName,
                    @LastName,
                    @ConfirmationToken,
                    0,
                    0,
                    0,
                    0,
                    0,
                    @Latitude,
                    @Longitude,
                    @MobileNo,
                    @RoleId,
                    @VerificationNumber
                )";
                this.Connection.Execute(Query, user);
            }
        }

        /// <summary>
        /// To check wheather exists already
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool IsExists(string UserName)
        {
            using (this.Connection)
            {
                string Query = @"select count(*) from AspNetUsers where Username=@UserName";
                return this.Connection.Query<int>(Query, new { UserName }).FirstOrDefault() > 0;
            }

        }

        /// <summary>
        /// To request to promote as Cook
        /// </summary>
        /// <param name="p"></param>
        public void RequestPromotion(int userId, int VerificationNumber)
        {
            using (this.Connection)
            {
                string Query = @"Update UserProfile set IsRequestedForPromotion=1,PromotionVerificationNumber=@VerificationNumber where UserId=@UserId";
                this.Connection.Execute(Query, new { UserId = userId, VerificationNumber });
            }
        }

        /// <summary>
        /// To verify Promotion as Cook
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="VerificationNumber"></param>
        /// <returns></returns>
        public bool VerifyPromotion(int userId, int VerificationNumber)
        {
            using (this.Connection)
            {
                string Query = @"select count(*) from UserProfile where UserId=@UserId and VerificationNumber=@VerificationNumber and IsRequestedForPromotion=1";
                bool isOk = this.Connection.Query<int>(Query, new { UserId = userId, VerificationNumber }).FirstOrDefault() > 0;
                if (isOk)
                {
                    string Query1 = @"Update UserProfile set IsPromoted=1,RoleId=@Role where UserId=@UserId";
                    this.Connection.Execute(Query1, new { UserId = userId, Role = Role.Cook });

                }
                return isOk;
            }
        }

    }
}
