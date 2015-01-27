namespace FoodApp.Api.Controllers
{
    using FoodApp.Api.Helpers;
    using FoodApp.Api.Models;
    using FoodApp.Core;
    using FoodApp.Domain;
    using FoodApp.Service.Foods;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// The Food Controller
    /// </summary>
    [Authorize]
    public class FoodController : ApiController
    {
        /// <summary>
        /// The food Service
        /// </summary>
        public IFoodService foodService { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public FoodController()
        {
            this.foodService = new FoodService();
        }

        /// <summary>
        /// To add Food
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Food/Add")]
        public HttpResponseMessage Add(Food food)
        {
            try
            {
                if (food == null || !this.ModelState.IsValid || ((food.ItemId==0 || food.ItemId==null) && string.IsNullOrEmpty(food.ItemName)))
                {
                        return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                        {
                            Message = "Bad Request",
                            Status = ApiStatusCode.BadRequest
                        });
                }
                var user = Helper.User;
                if (user == null)
                {
                    return this.Request.CreateResponse(HttpStatusCode.Unauthorized, new DefaultResponse()
                    {
                        Message = "Unauthenticated",
                        Status = ApiStatusCode.UnAuthenticated
                    });
                }

                food.CookId = user.UserId;
                if(food.ItemId==null ||food.ItemId==0)
                {
                    food.ItemId = this.foodService.AddFoodItem(food.ItemName);
                }

                this.foodService.Add(food);

                return this.Request.CreateResponse(HttpStatusCode.OK, new DefaultResponse()
                {
                    Message = "Added",
                    Status = ApiStatusCode.Ok,
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
        /// To search Food
        /// </summary>
        /// <param name="foodRequest"></param>
        /// <returns></returns>
        [Authorize]
        [AcceptVerbs("GET","POST")]
        [Route("api/Food")]
        public HttpResponseMessage Get(FoodRequest foodRequest)
        {
            try
            {
                IList<ApiFoodModel> foods = new List<ApiFoodModel>();
                if(foodRequest==null|| !this.ModelState.IsValid ||(foodRequest.Distance==null && string.IsNullOrEmpty(foodRequest.Keyword)))
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest,
                        new DefaultResponse()
                        {
                            Message = "Incomplete Data",
                            Status = ApiStatusCode.BadRequest
                        });
                }
                var user = Helper.User;
                if(foodRequest.Keyword==null)
                {
                    foodRequest.Distance = GeographicHelper.ConvertToDegrees(foodRequest.Distance);
                    foods = this.foodService.GetFood(foodRequest.Latitude,foodRequest.Longitude,foodRequest.Distance,user.UserId);
                }
                else if(foodRequest.Distance==null)
                {
                    foods = this.foodService.GetFood(foodRequest.Latitude, foodRequest.Longitude, foodRequest.Keyword,user.UserId);
                }
                else
                {
                    foodRequest.Distance = GeographicHelper.ConvertToDegrees(foodRequest.Distance);
                    foods = this.foodService.GetFood(foodRequest.Latitude, foodRequest.Longitude, foodRequest.Distance, foodRequest.Keyword,user.UserId);
                }


                return this.Request.CreateResponse(HttpStatusCode.OK,
                    new FoodResponseModel()
                    {
                        Message = "Ok",
                        Status = ApiStatusCode.Ok,
                        Foods = foods
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
