using FoodApp.Api.Models;
using FoodApp.Service.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodApp.Api.Controllers
{
    /// <summary>
    /// ItemsController
    /// </summary>
    [Authorize]
    public class ItemController : ApiController
    {
        /// <summary>
        /// The foodService
        /// </summary>
        private IFoodService foodService { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public ItemController()
        {
            foodService = new FoodService();
        }

        /// <summary>
        /// To get Items
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [AcceptVerbs("POST","GET")]
        [Route("api/Items")]
        public HttpResponseMessage Get()
        {
            try
            {
                var items = this.foodService.GetItems();
                return this.Request.CreateResponse(HttpStatusCode.OK, new ItemsResponseModel() {
                    Message = "Success",
                    Status = ApiStatusCode.Ok,
                    Items=items
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

        [HttpPost]
        [Route("api/Items/Add/{ItemName}")]
        public HttpResponseMessage Add(string ItemName)
        {
            try
            {
                if(string.IsNullOrEmpty(ItemName))
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, new DefaultResponse()
                    {
                        Message = "Success",
                        Status = ApiStatusCode.BadRequest
                    });
                }
                var itemId = this.foodService.AddFoodItem(ItemName);
                return this.Request.CreateResponse(HttpStatusCode.OK, new ItemResponseModel()
                {
                    Message = "Success",
                    Status = ApiStatusCode.Ok,
                    ItemId=itemId,
                    ItemName=ItemName
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
