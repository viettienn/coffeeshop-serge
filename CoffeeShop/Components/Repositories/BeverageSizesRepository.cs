using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Components.Repositories
{
    public interface IBeverageSizesRepository
    {
        Size InsertSize(Size size);
        IEnumerable<Size> GetSizes();
        IEnumerable<BeverageSize> Get(int id);
        BeverageSize InsertBeverageSize(BeverageSize beveragesize);
        bool InsertBeverageSizes(IList<BeverageSize> beverageSizes);
        bool UpdateBeverageSize(BeverageSize beverageSize);
        bool UpdateBeverageSizeList(int beverageId, int sizeId, decimal price, bool add_remove);
        void Delete(int id);
    }

    public class BeverageSizesRepository : BaseRepository, IBeverageSizesRepository
    {
        public void Delete(int id)
        {
            DeleteById<BeverageSize>(id);
        }

        public IEnumerable<BeverageSize> Get(int beverageId)
        {
            string sql = @"select 
	                            bs.*,
	                            s.Name
                            from dbo.BeverageSizes bs
                            inner join dbo.Sizes s on bs.sizeId = s.Id
                            where 
	                            bs.BeverageId = @0 and bs.active = @1";

            return GetMany<BeverageSize>(sql, beverageId, 1);
        }

        public IEnumerable<Size> GetSizes()
        {
            return GetAll<Size>();
        }

        public BeverageSize InsertBeverageSize(BeverageSize beverageSize)
        {
            return Insert<BeverageSize>(beverageSize);
        }

        public bool InsertBeverageSizes(IList<BeverageSize> beverageSizes)
        {
            return InsertBulk<BeverageSize>(beverageSizes) > 0;
        }

        public Size InsertSize(Size size)
        {
            return Insert(size);
        }

        public bool UpdateBeverageSize(BeverageSize beverageSize)
        {
            return Update<BeverageSize>(beverageSize);
        }

        public bool UpdateBeverageSizeList(int beverageId, int sizeId, decimal price, bool add_remove)
        {
            var sql = string.Format("EXEC UpdateBeverageSizes @@beverageId = {0}, @@sizeId = {1}, @@price = {2}, @@add_remove = {3}",
                beverageId, sizeId, price, add_remove);
            return GetScalar<bool>(sql);
        }
    }
}