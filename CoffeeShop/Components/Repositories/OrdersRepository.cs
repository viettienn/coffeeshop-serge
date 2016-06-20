using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Components.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Get();
        IEnumerable<Order> GetSummary();
        Order Get(int id);
        Order InsertOrder(Order order);
        bool UpdateOrder(Order order);
        bool Delete(int id);
    }
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {
        public bool Delete(int id)
        {
            return DeleteById<Order>(id);
        }

        public IEnumerable<Order> Get()
        {
            string sql = @"select 
	                        o.*,
	                        b.Name as BeverageName,
	                        s.Name as BeverageSize,
	                        bp.Price as Price
                        from Orders o
                        inner join dbo.Beverages b on o.BeverageId = b.Id
                        inner join dbo.BeverageSizes bs on bs.Id = o.BeverageSizeId
                        inner join dbo.Sizes s on s.Id = bs.sizeId
                        inner join dbo.BeveragePrices bp on bp.Id = o.BeveragePriceId
                        order by o.TsCreated desc";

            return GetMany<Order>(sql);
        }

        public Order Get(int id)
        {
            return GetById<Order>(id);
        }

        public IEnumerable<Order> GetSummary()
        {
            var sql = @";with PX as (
                        select 
	                        o.BeverageId,
	                        o.BeveragePriceId,
	                        o.BeverageSizeId,
	                        COUNT(o.BeverageId) as TotalCount,
	                        SUM(bp.Price) as TotalAmount
                        from Orders o
                        inner join dbo.BeveragePrices bp on bp.Id = o.BeveragePriceId
                        group by 
	                        o.BeverageId,
	                        o.BeverageSizeId,
	                        o.BeveragePriceId
                        )
                        select 
	                        o.*,
	                        b.Name as BeverageName,
	                        s.Name as BeverageSize
                        from PX o
                        inner join Beverages b on o.BeverageId =  b.Id
                        inner join dbo.BeverageSizes bs on bs.Id = o.BeverageSizeId
                        inner join Sizes s on s.Id = bs.sizeId";
            return GetMany<Order>(sql);
        }

        public Order InsertOrder(Order order)
        {
            return Insert(order);
        }

        public bool UpdateOrder(Order order)
        {
            return Update(order);
        }
    }
}