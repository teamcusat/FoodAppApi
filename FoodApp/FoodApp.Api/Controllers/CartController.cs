using FoodApp.Api.Helpers;
using FoodApp.Api.Models;
using FoodApp.Domain;
using FoodApp.Service.Foods;
using FoodApp.Services.Cart;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodApp.Api.Controllers
{
    /// <summary>
    /// The cart controller
    /// </summary>
    [Authorize]
    public class CartController : ApiController
    {

        /// <summary>
        /// The cart Service
        /// </summary>
        private ICartService cartService { get; set; }

        /// <summary>
        /// The food Service
        /// </summary>
        private IFoodService foodService { get; set; }

        /// <summary>
        /// The cart service
        /// </summary>
        public CartController()
        {
            this.cartService = new CartService();
            this.foodService = new FoodService();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns></returns>
        [Route("api/Cart")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var items = this.cartService.Get(Helper.User.UserId);
                double sum = 0;

                foreach (var item in items)
                {
                    sum += item.Amount;
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, new CartResponse()
                {
                    Message = "Success",
                    Status = ApiStatusCode.Ok,
                    Items = items,
                    Total = sum
                });
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new DefaultResponse()
                    {
                        Message = "Some error occured",
                        Status = ApiStatusCode.InternalServerError
                    });
            }
        }

        /// <summary>
        /// To add to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/Cart/Add")]
        [HttpPost]
        public HttpResponseMessage Add([FromBody]AddToCartRequest request)
        {
            try
            {
                if (request !=null && this.ModelState.IsValid)
                {
                    Food food = this.foodService.Get(request.FoodId);
                    if (request.Quantity > food.Quantity)
                    {
                        return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                        {
                            Message = "Quantity Exceeds Limit",
                            Status = ApiStatusCode.BadRequest,
                        });
                    }
                    this.cartService.Add(Helper.User.UserId, request.FoodId, request.Quantity);
                    return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
                    {
                        Message = "Success",
                        Status = ApiStatusCode.Ok,
                    });
                }
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                {
                    Message = "Bad Request",
                    Status = ApiStatusCode.BadRequest,
                });
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new DefaultResponse()
                    {
                        Message = "Some error occured",
                        Status = ApiStatusCode.InternalServerError
                    });

            }
        }

        /// <summary>
        /// To add to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/Cart/Remove")]
        [HttpPost]
        public HttpResponseMessage Remove(RemoveCartRequest request)
        {
            try
            {
                if (request!=null && this.ModelState.IsValid)
                {
                    this.cartService.Remove(Helper.User.UserId, request.CartId);
                    return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
                    {
                        Message = "Success",
                        Status = ApiStatusCode.Ok,
                    });
                }
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                {
                    Message = "Bad Request",
                    Status = ApiStatusCode.BadRequest
                });
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new DefaultResponse()
                    {
                        Message = "Some error occured",
                        Status = ApiStatusCode.InternalServerError
                    });
            }

        }
    }
}
