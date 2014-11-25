// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Token.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   Defines the Token type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Domain
{
    using System.Security.Cryptography;
    using System.Web;

    /// <summary>
    ///     The token.
    /// </summary>
    public static class Token
    {
        /// <summary>
        ///     The generate token.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public static string GenerateToken()
        {
            // generate random token
            using (var prng = new RNGCryptoServiceProvider())
            {
                // how unique is this. We need to verify this.
                // TO DO. Hash a string with the token.
                var tokenBytes = new byte[16]; // 16 bytes token
                prng.GetBytes(tokenBytes);
//                return HttpServerUtility.UrlTokenEncode(tokenBytes);
                return tokenBytes.ToString();
            }
        }

        public static int GenerateVerificationNumber()
        {
            return 12345678;
        }
    }
}