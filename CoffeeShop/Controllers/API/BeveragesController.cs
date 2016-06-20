using CoffeeShop.Components.Repositories;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeShop.Controllers.API
{
    [RoutePrefix("service/beverages")]
    public class BeveragesController : ApiController
    {
        private IBeveragesRepository _beveragesRepository;
        IBeveragePricesRepository _beveragePricesRepository;
        IBeverageSizesRepository _beverageSizesRepository;

        public BeveragesController(IBeveragesRepository beveragesRepository, 
            IBeveragePricesRepository beveragePricesRepository, IBeverageSizesRepository beverageSizesRepository)
        {
            _beveragesRepository = beveragesRepository;
            _beveragePricesRepository = beveragePricesRepository;
            _beverageSizesRepository = beverageSizesRepository;
        }

        [Route("getTypes")]
        public IHttpActionResult GetTypes()
        {
            return Ok(_beveragesRepository.GetTypes());
        }

        // GET: service/Beverages
        public IHttpActionResult Get()
        {
            var beverages = _beveragesRepository.Get();
            var sizes = _beverageSizesRepository.GetSizes();
            var beveragesPrices = _beveragePricesRepository.Get();

            foreach (var beverage in beverages)
            {
                //beverage.BeveragesSizes = beverage.BeveragesSizes.Where(bs => bs.Active == true).ToList();
                beverage.BeveragesSizes.ToList()
                    .ForEach(y => y.Name = sizes.FirstOrDefault(z => z.Id == y.SizeId).Name);
                beverage.BeveragePrices = beveragesPrices.Where(y => y.BeverageId == beverage.Id).ToList();
            }
            
            return Ok(beverages);
        }

        // GET: service/Beverages/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_beveragesRepository.Get(id));
        }

        // POST: service/Beverages
        public IHttpActionResult Post(Beverage beverage)
        {
            //insert the beverage
            var b = _beveragesRepository.InsertBeverage(beverage);
            //extract beverage sizes
            var beverageSizes = beverage.BeveragePrices.Select(x => new BeverageSize
            {
                BeverageId = b.Id,
                SizeId = x.BeverageSizeId,
                Active = true
            });
            //insert bulk beverage sizes
            _beverageSizesRepository.InsertBeverageSizes(beverageSizes.ToList());

            //get beverages sizes from db
            var dbBeveragesSizes = _beverageSizesRepository.Get(b.Id);

            //update ids for the beverage prices
            beverage.BeveragePrices.ForEach(x => 
            {
                x.BeverageId = b.Id;
                x.BeverageSizeId = dbBeveragesSizes.FirstOrDefault(y => y.SizeId == x.BeverageSizeId).Id;
            });
            //insert bulk for beverage prices
            var result = _beveragePricesRepository.InsertPrices(beverage.BeveragePrices);

            return Ok(result);
        }

        // PUT: service/Beverages/5
        public IHttpActionResult Put(Beverage beverage)
        {
            return Ok(_beveragesRepository.UpdateBeverage(beverage));
        }

        // DELETE: service/Beverages/5
        public void Delete(int id)
        {
            _beveragesRepository.Delete(id);
        }
    }
}
