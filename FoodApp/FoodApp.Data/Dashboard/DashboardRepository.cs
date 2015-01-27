using FoodApp.Domain;
using Dapper;
using System.Linq;

namespace FoodApp.Data.Dashboard
{
    public class DashboardRepository :RepositoryBase,IDashboardRepository
    {
        /// <summary>
        /// To get Dashboard
        /// </summary>
        /// <returns></returns>
        public DashboardModel Get()
        {
            using (this.Connection)
            {
                string Query = @"";
                return this.Connection.Query<DashboardModel>(Query).FirstOrDefault();

            }
        }
    }
}
