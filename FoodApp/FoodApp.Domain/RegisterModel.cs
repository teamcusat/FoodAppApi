using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Domain
{
    public class RegisterModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
        
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// MobileNo
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        public Role Role { get; set; }
        
        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }
    }
}
