using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    [TableName("BeveragePrices")]
    public class BeveragePrice : BaseModel
    {
        public int BeverageId { get; set; }
        public int BeverageSizeId { get; set; }
        public decimal Price { get; set; }
    }
}