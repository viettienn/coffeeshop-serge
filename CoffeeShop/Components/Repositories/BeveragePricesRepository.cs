using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Components.Repositories
{
    public interface IBeveragePricesRepository
    {
        IEnumerable<BeveragePrice> Get();
        BeveragePrice Get(int beverageId, int beverageSizeId);
        BeveragePrice InsertPrice(BeveragePrice beveragePrice);
        bool InsertPrices(IList<BeveragePrice> beveragePrices);
        bool UpdatePrice(BeveragePrice beveragePrice);
    }
    public class BeveragePricesRepository : BaseRepository, IBeveragePricesRepository
    {
        public IEnumerable<BeveragePrice> Get()
        {
            return GetAll<BeveragePrice>();
        }

        public BeveragePrice Get(int beverageId, int beverageSizeId)
        {
            string sql = @"select 
	                        top 1* 
                        from BeveragePrices
                        where
	                        BeverageId = @0 and BeverageSizeId = @1";

            return GetOne<BeveragePrice>(sql, beverageId, beverageSizeId);
        }

        public BeveragePrice InsertPrice(BeveragePrice beveragePrice)
        {
            return Insert<BeveragePrice>(beveragePrice);
        }

        public bool InsertPrices(IList<BeveragePrice> beveragePrices)
        {
            return InsertBulk<BeveragePrice>(beveragePrices) > 0;
        }

        public bool UpdatePrice(BeveragePrice beveragePrice)
        {
            return Update<BeveragePrice>(beveragePrice);
        }
    }
}