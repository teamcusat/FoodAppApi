using Microsoft.Owin.Security;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using FoodApp.Domain;
using FoodApp.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using FoodApp.Services.Account;
using System.Net;
using System;

namespace FoodApp.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccountService accountService { get; set; }
        private ApplicationUserManager _userManager;

        public AccountController()
        {
            this.accountService = new AccountService();
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
                model.Role = model.Role == null ? Role.User : model.Role;
                UserProfile User = new UserProfile()
                {
                    ConfirmationToken = Token.GenerateToken(),
                    VerificationNumber = Token.GenerateVerificationNumber(),
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    MobileNo = model.MobileNo,
                    Role = model.Role
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

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            accountService = new AccountService();
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
