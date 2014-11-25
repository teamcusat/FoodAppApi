using FoodApp.Api.Models;
using FoodApp.Service.Food;
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
    public class ItemController : ApiController
    {
        private IFoodService foodService { get; set; }

        public ItemController()
        {
            foodService = new FoodService();
        }

        [Authorize]
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
    }
}
