using CoffeeShop.Enums;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    [TableName("Beverages")]
    public class Beverage : BaseModel
    {
        [Column("BeverageTypeId")]
        public BeverageTypes BeverageType { get; set; }
        public string Name { get; set; }

        [ResultColumn]
        public List<BeveragePrice> BeveragePrices { get; set; }

        [ResultColumn]
        public List<BeverageSize> BeveragesSizes { get; set; }
    }
}