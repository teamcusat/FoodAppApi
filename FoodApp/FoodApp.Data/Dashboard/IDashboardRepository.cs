
using FoodApp.Domain;
namespace FoodApp.Data.Dashboard
{
    public interface IDashboardRepository
    {
        /// <summary>
        /// To get Dashboard
        /// </summary>
        /// <returns></returns>
        DashboardModel Get();
    }
}
