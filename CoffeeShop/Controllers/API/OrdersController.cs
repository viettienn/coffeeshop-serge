using CoffeeShop.Components.Repositories;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoffeeShop.Controllers.API
{
    [RoutePrefix("service/orders")]
    public class OrdersController : ApiController
    {
        private IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [Route("getSummary")]
        public IHttpActionResult GetSummary()
        {
            return Ok(_ordersRepository.GetSummary());
        }

        public IHttpActionResult Get()
        {
            return Ok(_ordersRepository.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_ordersRepository.Get(id));
        }


        public IHttpActionResult Post(Order order)
        {
            return Ok(_ordersRepository.InsertOrder(order));
        }


        public IHttpActionResult Put(Order order)
        {
            return Ok(_ordersRepository.UpdateOrder(order));
        }

        public void Delete(int id)
        {
            _ordersRepository.Delete(id);
        }
    }
}