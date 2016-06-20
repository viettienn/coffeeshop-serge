using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoffeeShop.Components.Repositories
{
    public interface IBeveragesRepository
    {
        IEnumerable<BeverageType> GetTypes();
        IEnumerable<Beverage> Get();
        Beverage Get(int id);
        Beverage InsertBeverage(Beverage beverage);
        bool UpdateBeverage(Beverage beverage);
        void Delete(int id);
    }
    public class BeveragesRepository : BaseRepository, IBeveragesRepository
    {
        public void Delete(int id)
        {
            DeleteById<Beverage>(id);
        }

        public IEnumerable<Beverage> Get()
        {
            return GetAllWithChildren<Beverage, BeverageSize>("BeverageId");
        }

        public Beverage Get(int id)
        {
            return GetById<Beverage>(id);
        }

        public IEnumerable<BeverageType> GetTypes()
        {
            return GetAll<BeverageType>();
        }

        public Beverage InsertBeverage(Beverage beverage)
        {
            return Insert(beverage);
        }

        public bool UpdateBeverage(Beverage beverage)
        {
            return Update(beverage);
        }
    }
}