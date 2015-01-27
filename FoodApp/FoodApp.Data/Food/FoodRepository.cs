using FoodApp.Domain;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Data.Foods
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

        /// <summary>
        /// To add Food Item
        /// </summary>
        /// <param name="itemName"></param>
        public int AddFoodItem(string itemName)
        {
            using (this.Connection)
            {
                string Query = @"IF( NOT EXISTS (select ItemId from FoodItems where Name=@ItemName))
                                BEGIN
                                    Insert into FoodItems(Name) Values(@ItemName)
                                END
                                select ItemId from FoodItems where Name=@ItemName";
                return this.Connection.Query<int>(Query,new { ItemName=itemName}).FirstOrDefault();
            }
        }

        /// <summary>
        /// To delete Food Items
        /// </summary>
        /// <param name="itemId"></param>
        public void DeleteFoodItem(int itemId)
        {
            using (this.Connection)
            {
                string Query = @"delete FoodItems where ItemId = @ItemId";
                this.Connection.Execute(Query, new { ItemId = itemId });
            }
        }

        /// <summary>
        /// To add Food
        /// </summary>
        /// <param name="food"></param>
        public void Add(Food food)
        {
            using (this.Connection)
            {
                string Query = @"insert into Food (ItemId,Quantity,Price,CookId,Longitude,Latitude,DeliverableTime,Comments,Location,HomeAddress,Landmark) values(@ItemId,@Quantity,@Price,@CookId,@Longitude,@Latitude,@DeliverableTime,@Comments,@Location,@HomeAddress,@Landmark)";
                this.Connection.Execute(Query, food);
            }
        }

        /// <summary>
        /// To get a food
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        public Food Get(int foodId)
        {
            using (this.Connection)
            {
                string Query = @"select * from Food where Id=@FoodID";
                return this.Connection.Query<Food>(Query, new { FoodId=foodId}).FirstOrDefault();
            }
        }

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public IList<ApiFoodModel> GetFood(double? latitude, double? longitude, double? distance, int UserId)
        {
            using (this.Connection)
            {
                string Query = @"select F.CookId,F.Id,F.ItemId,I.Name as ItemName,F.Quantity,F.Price,F.Latitude,F.Longitude,F.DeliverableTime,F.Comments,F.Location , F.HomeAddress , F.Landmark, SQRT((F.Latitude-@Latitude)*(F.Latitude-@Latitude)+(F.Longitude-@Longitude)*(F.Longitude-@Longitude)) as Distance from Food F 
                                inner join FoodItems I on I.ItemId=F.ItemId where F.CookId!=@UserId and F.Quantity>0 and ((F.Latitude-@Latitude)*(F.Latitude-@Latitude)+(F.Longitude-@Longitude)*(F.Longitude-@Longitude))<=@MaxDistance order by Distance";
                var foods=this.Connection.Query<ApiFoodModel>(Query, new { Latitude=latitude,Longitude=longitude,MaxDistance=distance*distance,UserId}).ToList();
                setCook(foods);
                return foods;
            }
        }

        /// <summary>
        /// To set cook against each food
        /// </summary>
        /// <param name="list"></param>
        private void setCook(List<ApiFoodModel> list)
        {
            using (this.Connection)
            {
                string Query = @"select * from UserProfile";
                var users=this.Connection.Query<UserProfile>(Query).ToList();
                foreach(var food in list)
                {
                    food.Cook = users.Where(u => u.UserId == food.CookId).FirstOrDefault();
                    food.Distance =((int)food.Distance*11000); //TODO : move code
                }
            }            
        }

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<ApiFoodModel> GetFood(double? latitude, double? longitude, string keyword, int UserId)
        {
            using (this.Connection)
            {
                string Query = @"select Top 30 F.CookId,F.Id,F.ItemId,I.Name as ItemName,F.Quantity,F.Price,F.Latitude,F.Longitude,F.DeliverableTime,F.Comments,F.Location , F.HomeAddress , F.Landmark,SQRT((F.Latitude-@Latitude)*(F.Latitude-@Latitude)+(F.Longitude-@Longitude)*(F.Longitude-@Longitude)) as Distance from Food F 
                                inner join FoodItems I on I.ItemId=F.ItemId where F.CookId!=@UserId and F.Quantity>0 and I.Name like '%" + keyword + "%' order by Distance";
                var foods= this.Connection.Query<ApiFoodModel>(Query, new { Latitude = latitude, Longitude = longitude,UserId }).ToList();
                setCook(foods);
                return foods;
            }

        }

        /// <summary>
        /// To search Food
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="distance"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<ApiFoodModel> GetFood(double? latitude, double? longitude, double? distance, string keyword, int UserId)
        {
            using (this.Connection)
            {
                string Query = @"select Top 30 F.CookId,F.Id,F.ItemId,I.Name as ItemName,F.Quantity,F.Price,F.Latitude,F.Longitude,F.DeliverableTime,F.Comments,F.Location , F.HomeAddress , F.Landmark,SQRT((F.Latitude-@Latitude)*(F.Latitude-@Latitude)+(F.Longitude-@Longitude)*(F.Longitude-@Longitude)) as Distance from Food F  
                                inner join FoodItems I on I.ItemId=F.ItemId where F.CookId!=@UserId and F.Quantity>0 and I.Name like '%" + keyword + "%' and ((F.Latitude-@Latitude)*(F.Latitude-@Latitude)+(F.Longitude-@Longitude)*(F.Longitude-@Longitude))<=@MaxDistance order by Distance";
                var foods= this.Connection.Query<ApiFoodModel>(Query, new { Latitude = latitude, Longitude = longitude,MaxDistance=distance*distance,UserId }).ToList();
                setCook(foods);
                return foods;

            }

        }


        /// <summary>
        /// To get All foods
        /// </summary>
        /// <returns></returns>
        public IList<ApiFoodModel> GetAll()
        {
            using (this.Connection)
            {
                string Query = @"Select F.*,I.Name as ItemName from Food F inner join FoodItems I on F.ItemId=I.ItemId where F.Quantity>0;
                                SELECT * FROM USERPROFILE
                                ";
                var multi = this.Connection.QueryMultiple(Query);
                List<ApiFoodModel> food = multi.Read<ApiFoodModel>().ToList();
                var users = multi.Read<UserProfile>().ToList();
                foreach(ApiFoodModel f in food)
                {
                    f.Cook = users.Where(u => u.UserId == f.CookId).FirstOrDefault();
                }
                return food;
            }
        }


    }
}
