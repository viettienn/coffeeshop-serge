using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    [TableName("BeverageSizes")]
    public class BeverageSize : BaseModel
    {
        public int BeverageId { get; set; }
        [Column("sizeId")]
        public int SizeId { get; set; }
        [ResultColumn]
        public bool Active { get; set; }
        [ResultColumn]
        public string Name { get; set; }
    }
}