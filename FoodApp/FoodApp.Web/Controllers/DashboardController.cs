using FoodApp.Web.Helpers;
using System.Web.Mvc;

namespace FoodApp.Web.Controllers
{
    [AdminFilter]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
