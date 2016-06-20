using CoffeeShop.Components.Repositories;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoffeeShop.Controllers.API
{
    [RoutePrefix("service/beverageprices")]
    public class BeveragePricesController : ApiController
    {
        private IBeveragePricesRepository _beveragePricesRepository;

        public BeveragePricesController(IBeveragePricesRepository beveragePricesRepository)
        {
            _beveragePricesRepository = beveragePricesRepository;
        }

        [Route("{beverageId}/{beverageSizeId}")]
        public IHttpActionResult Get(int beverageId, int beverageSizeId)
        {
            return Ok(_beveragePricesRepository.Get(beverageId, beverageSizeId));
        }

        
        public IHttpActionResult Post(BeveragePrice beveragePrice)
        {
            return Ok(_beveragePricesRepository.InsertPrice(beveragePrice));
        }

        
        public IHttpActionResult Put(BeveragePrice beveragePrice)
        {
            return Ok(_beveragePricesRepository.UpdatePrice(beveragePrice));
        }
        
    }
}