using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace FoodApp.Data.Account
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public void Register(Domain.UserProfile user)
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
                    @Role,
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
    }
}
