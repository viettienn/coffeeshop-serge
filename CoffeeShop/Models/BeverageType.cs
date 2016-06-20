using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    [TableName("BeverageTypes")]
    public class BeverageType : BaseModel
    {
        public string Name { get; set; }
    }
}