namespace FoodApp.Api.Controllers
{
    using FoodApp.Api.Helpers;
    using FoodApp.Api.Models;
    using FoodApp.Domain;
    using FoodApp.Framework;
    using FoodApp.Services.Account;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;

    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccountService accountService { get; set; }
        private ICacheService cacheService { get; set; }
        private ApplicationUserManager _userManager;

        public AccountController()
        {
            this.accountService = new AccountService();
            this.cacheService = new CacheService();
        }
        // POST api/Account/Logout
        [Route("Logout")]
        [HttpPost]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }


        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<HttpResponseMessage> Register(RegisterModel model)
        {
            try
            {
                if(!this.ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                    {
                        Message = "Insufficient Data",
                        Status = ApiStatusCode.BadRequest,
                    });
                }
                if(this.accountService.IsExists(model.Email))
                {
                    return this.Request.CreateResponse(HttpStatusCode.NotAcceptable, new DefaultResponse()
                    {
                        Message = "Already registered",
                        Status = ApiStatusCode.Failed
                    });
                }
                var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new DefaultResponse() { 
                        Message="Unable To Register",
                        Status=ApiStatusCode.InternalServerError
                    });
                }
                User User = new User()
                {
                    ConfirmationToken = Token.GenerateToken(),
                    VerificationNumber = Token.GenerateVerificationNumber(),
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    MobileNo = model.MobileNo,
                    RoleId = Role.User
                };
                this.accountService.Register(User);

                return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
                {
                    Message = "Registered Successfully",
                    Status = ApiStatusCode.Ok
                });

            }
            catch(Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new DefaultResponse()
                {
                    Message = "Unable To Register",
                    Status = ApiStatusCode.InternalServerError
                });

            }

        }

        ///// <summary>
        ///// To verify promotion
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("VerifyPromotion/{VerificationNumber}")]
        //public HttpResponseMessage VerifyPromotion([FromUri]int VerificationNumber)
        //{
        //    try
        //    {
        //        User user = Helper.User;
        //        if (user.RoleId == Role.Cook)
        //        {
        //            return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
        //            {
        //                Message = "Already promoted",
        //                Status = ApiStatusCode.Ok,
        //            });
        //        }
        //        bool Ok=this.accountService.VerifyPromotion(user.UserId, VerificationNumber);
        //        if (Ok)
        //        {
        //            return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
        //            {
        //                Message = "Verified",
        //                Status = ApiStatusCode.Ok
        //            });
        //        }
        //        else
        //        {
        //            return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
        //            {
        //                Message = "Verification Number does not match",
        //                Status = ApiStatusCode.Failed
        //            });
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new DefaultResponse()
        //        {
        //            Message = "Some error occured",
        //            Status = ApiStatusCode.InternalServerError
        //        });

        //    }
        //}

        /// <summary>
        /// To request promotion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("RequestPromotion")]
        public HttpResponseMessage RequestPromote()
        {
            try
            {
                User user = Helper.User;
                if(user.RoleId==Role.Cook)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                    {
                        Message = "Already promoted",
                        Status = ApiStatusCode.BadRequest,
                    });
                }
                int verificationNumber = Token.GenerateVerificationNumber();
                this.accountService.RequestPromotion(user.UserId,verificationNumber);
                this.cacheService.RemoveSession(SessionKeys.UserProfile);
                return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
                {
                    Message = "Requset Sent",
                    Status = ApiStatusCode.Ok
                });
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new DefaultResponse()
                {
                    Message = "Some error occured",
                    Status = ApiStatusCode.InternalServerError
                });

            }
        }

        /// <summary>
        /// To send VerificationMail
        /// </summary>
        /// <param name="verificationNumber"></param>
        private void SendVerificationMail(string email,int verificationNumber)
        {
            var replacements = new ListDictionary()
            {
                {"<<UserName>>",Helper.User.DisplayName},
                {"<<VerificationNumber>>",verificationNumber.ToString()}
            };
            new Mailer().SendMail(replacements, "CookConfirmationMail.html", email, "Verify Your promotion");
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            accountService = new AccountService();
            cacheService = new CacheService();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

    }
}
