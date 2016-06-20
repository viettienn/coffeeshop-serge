using CoffeeShop.Components.Repositories;
using CoffeeShop.Controllers.API;
using CoffeeShop.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Tests
{
    public class CoffeeShopFixtureClass
    {
        private Mock<IOrdersRepository> _mockIOrdersRepository = new Mock<IOrdersRepository>();
        public OrdersController OrdersController { get; set; }

        public CoffeeShopFixtureClass()
        {
            OrdersController = new OrdersController(_mockIOrdersRepository.Object);

            //mocking insertion
            _mockIOrdersRepository.Setup(x => x.InsertOrder(It.IsAny<Order>())).Returns(new Order
            {
                Id = 0,
                BeverageId = 1,
                BeverageSizeId = 1,
                BeveragePriceId = 1
            });

            _mockIOrdersRepository.Setup(x => x.Get()).Returns(GetOrders());
        }

        public IEnumerable<Order> GetOrders()
        {
            IList<Order> orders = new List<Order>();

            orders.Add(new Order
            {
                BeverageId = 1,
                BeverageSizeId = 1,
                BeveragePriceId = 1
            });
            orders.Add(new Order
            {
                BeverageId = 1,
                BeverageSizeId = 2,
                BeveragePriceId = 2
            });
            return orders;
        }
    }
}
