using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;
using Xunit.Abstractions;

namespace CoffeeShop.Tests
{
    [Collection("CoffeeShop Collection")]
    public class OrdersControllerTest
    {
        private CoffeeShopFixtureClass _fixture;

        private readonly ITestOutputHelper _testOutputHelper;

        public OrdersControllerTest(ITestOutputHelper helper, CoffeeShopFixtureClass fixture)
        {
            _fixture = fixture;
            _testOutputHelper = helper;
        }

        [Fact]
        public void CheckThatGetIsCalledAndReturnsCorrectResult()
        {
            var result = _fixture.OrdersController.Get()
                as OkNegotiatedContentResult<IEnumerable<Order>>;

            Assert.IsType(typeof(List<Order>), result.Content.ToList());
        }

        [Fact]
        public void CheckInsertionResult()
        {
            var result = _fixture.OrdersController.Post(new Order
            {
                BeverageId = 1,
                BeverageSizeId = 1,
                BeveragePriceId = 1
            }) as OkNegotiatedContentResult<Order>;

            Assert.IsType(typeof(Order), result.Content);
        }
    }
}
