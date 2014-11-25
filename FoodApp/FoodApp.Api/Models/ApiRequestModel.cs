// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiRequestModel.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   The blurb request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;

    /// <summary>
    ///     The blurb request.
    /// </summary>
    public class BlurbRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BlurbRequest" /> class.
        /// </summary>
        public BlurbRequest()
        {
            this.blurbCount = Convert.ToInt32(ConfigurationManager.AppSettings["BlurbsPerPageCount"]);
        }

        /// <summary>
        ///     Gets or sets the category id.
        /// </summary>
        [RegularExpression("^[1-9][0-9]*$")]
        public int? CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the page.
        /// </summary>
        [Required]
        [RegularExpression("^[1-9][0-9]*$")]
        public int Page { get; set; }

        /// <summary>
        ///     Gets or sets the blurb count.
        /// </summary>
        public int blurbCount { get; set; }
    }

    /// <summary>
    ///     The connect request.
    /// </summary>
    public class ConnectRequest
    {
        /// <summary>
        ///     Gets or sets the provider user id.
        /// </summary>
        [Required]
        public string ProviderUserId { get; set; }

        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        [Required]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the avathar image url.
        /// </summary>
        public string AvatharImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the provider user name.
        /// </summary>
        [Required]
        public string ProviderUserName { get; set; }

        /// <summary>
        ///     Gets or sets the token secret.
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        ///     Gets or sets the verifier.
        /// </summary>
        public string Verifier { get; set; }
    }


    /// <summary>
    ///     The Reset Password Request.
    /// </summary>
    public class ResetPasswordRequest
    {
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$")]
        public string Email { get; set; }
    }

   

    public class BlurbInfo
    {
        /// <summary>
        ///     Gets or sets blurbId.
        /// </summary>
        [Required]
        [RegularExpression("^[1-9][0-9]*$")]
        public int BlurbId { get; set; }

        /// <summary>
        ///     Gets or sets enterpriseBlurbId.
        /// </summary>
        [Required]
        [RegularExpression("^[1-9][0-9]*$")]
        public int EnterpriseBlurbId { get; set; }

        /// <summary>
        ///     Gets or sets blurb title.
        /// </summary>
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets blurb Text.
        /// </summary> 
        [StringLength(130)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets comment.
        /// </summary>    
        [StringLength(130)]
        public string Comment { get; set; }

        /// <summary>
        ///     Gets or sets time.
        /// </summary>
        public string Time { get; set; }

    }

}