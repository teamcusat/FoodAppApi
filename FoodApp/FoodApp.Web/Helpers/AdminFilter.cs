using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApp.Web.Helpers
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = Helper.User;
            if(user==null)
            {
                context.Result=new RedirectResult("/Home/Index?Error=You have to Login First");
            }
        }
    }
}