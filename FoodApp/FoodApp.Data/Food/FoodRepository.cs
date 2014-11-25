using FoodApp.Domain;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Data.Food
{
    public class FoodRepository:RepositoryBase,IFoodRepository
    {
        /// <summary>
        /// Get Items
        /// </summary>
        /// <returns></returns>
        public IList<FoodItem> GetItems()
        {
            using(this.Connection)
            {
                string Query = @"select ItemId,Name from FoodItems";
                return this.Connection.Query<FoodItem>(Query).ToList();
            }
        }
    }
}
