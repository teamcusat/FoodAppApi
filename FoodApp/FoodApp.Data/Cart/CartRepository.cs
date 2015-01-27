using System.Linq;
using FoodApp.Domain;
using System.Collections.Generic;
using Dapper;

namespace FoodApp.Data.Cart
{
    /// <summary>
    /// The cart Repository
    /// </summary>
    public class CartRepository:RepositoryBase,ICartRepository
    {
        /// <summary>
        /// To get the cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IList<CartItem> Get(int UserId)
        {
            using(this.Connection)
            {
                string Query = @"select C.ID,C.Quantity,F.Price,F.Quantity as MaxQuantity,I.Name as ItemName from Cart C inner join Food F on F.Id=C.FoodId inner join FoodItems I on I.ItemId=F.ItemId where userId=@UserId";
                return this.Connection.Query<CartItem>(Query, new { UserId }).ToList();
            }
        }

        /// <summary>
        /// To add to cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FoodId"></param>
        /// <param name="Quantity"></param>
        public void Add(int UserId,int FoodId,int Quantity)
        {
            using (this.Connection)
            {
                string Query = @"Insert into cart(FoodId,UserId,Quantity) values(@FoodId,@UserId,@Quantity);
                                   Update Food set Quantity=Quantity-@Quantity where ID=@FoodId";
                this.Connection.Execute(Query, new { FoodId,UserId,Quantity});
            }
        }

        /// <summary>
        /// To remove from cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FoodId"></param>
        /// <param name="Quantity"></param>
        public void Remove(int UserId, int CartId)
        {
            using (this.Connection)
            {
                string Query = @"declare @Quantity int;
                                declare @FoodId int;
                                select @Quantity=Quantity ,@FoodId=FoodId from cart where ID=@ID and UserId=@UserId;
                                Update food set Quantity=Quantity+@Quantity where Id=@FoodId;
                                delete from cart where ID=@ID and UserId=@UserId";
                this.Connection.Execute(Query, new { ID=CartId, UserId});
            }
        }
    }
}
