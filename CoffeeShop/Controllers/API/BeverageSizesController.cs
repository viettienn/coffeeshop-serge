using CoffeeShop.Components.Repositories;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoffeeShop.Controllers.API
{
    [RoutePrefix("service/beveragesizes")]
    public class BeverageSizesController : ApiController
    {
        private IBeverageSizesRepository _beverageSizesRepository;
        private IBeveragePricesRepository _beveragePricesRepository;

        public BeverageSizesController(IBeverageSizesRepository beverageSizeRepository, 
            IBeveragePricesRepository beveragePricesRepository)
        {
            _beverageSizesRepository = beverageSizeRepository;
            _beveragePricesRepository = beveragePricesRepository;
        }


        [Route("getSizes")]
        public IHttpActionResult GetSizes()
        {
            return Ok(_beverageSizesRepository.GetSizes());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_beverageSizesRepository.Get(id));
        }

        [Route("insertSize")]
        public IHttpActionResult InsertSize(Size size)
        {
            return Ok(_beverageSizesRepository.InsertSize(size));
        }

        public IHttpActionResult Post(BeverageSize beverageSize)
        {
            return Ok(_beverageSizesRepository.InsertBeverageSize(beverageSize));
        }

        [HttpPost, Route("updateSizes/{beverageId}/{sizeId}/{price}/{add_remove}")]
        public IHttpActionResult UpdateSizes(int beverageId, int sizeId, decimal price, bool add_remove)
        {
            return Ok(_beverageSizesRepository.UpdateBeverageSizeList(beverageId, sizeId, price, add_remove));
        }


        public IHttpActionResult Put(BeverageSize beverageSize)
        {
            return Ok(_beverageSizesRepository.UpdateBeverageSize(beverageSize));
        }

        public void Delete(int id)
        {
            _beverageSizesRepository.Delete(id);
        }
    }
}