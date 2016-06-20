using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeShop.Tests
{
    [CollectionDefinition("CoffeeShop Collection")]
    public class CoffeeShopCollection : ICollectionFixture<CoffeeShopFixtureClass>
    {
    }
}
