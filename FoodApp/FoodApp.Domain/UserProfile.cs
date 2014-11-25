
namespace FoodApp.Domain
{
    public class UserProfile
    {
        /// <summary>
        /// Mobile Verificationnumber
        /// </summary>
        public int VerificationNumber { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// user MobileNumber
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// IsLocked
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Isarchived
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName
        {
            get
            {
                return string.IsNullOrEmpty(FullName) ? Email.Substring(0, Email.IndexOf('@')) : FullName;
            }
        }

        public string Email
        {
            get
            {
                return UserName;
            }
        }

        /// <summary>
        /// Full Name
        /// </summary>
        public string FullName
        {
            get
            {
                string name = "";
                if (!string.IsNullOrEmpty(FirstName))
                {
                    name += FirstName + " ";
                }
                if (!string.IsNullOrEmpty(LastName))
                {
                    name += LastName;
                }
                return name;
            }
        }

        /// <summary>
        /// Email confirmation Token
        /// </summary>
        public string ConfirmationToken { get; set; }

        /// <summary>
        /// IsPasswordChanged
        /// </summary>
        public bool IsPasswordChanged { get; set; }

        /// <summary>
        /// IsConfirmed
        /// </summary>
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// Is mobile verified
        /// </summary>
        public bool IsVerified { get; set; }
    }
}
