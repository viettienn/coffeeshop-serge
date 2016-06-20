using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    [TableName("Orders")]
    public class Order : BaseModel
    {
        public int BeverageId { get; set; }
        public int BeverageSizeId { get; set; }
        public int BeveragePriceId { get; set; }
        public bool Canceled { get; set; }
        public string CancelationReason { get; set; }
        [ResultColumn]
        public DateTime TsCreated { get; set; }

        [ResultColumn]
        public string BeverageName { get; set; }
        [ResultColumn]
        public string BeverageSize { get; set; }
        [ResultColumn]
        public decimal Price { get; set; }
        [ResultColumn]
        public int TotalCount { get; set; }
        [ResultColumn]
        public decimal TotalAmount { get; set; }

    }
}