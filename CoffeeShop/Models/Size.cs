using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    [TableName("Sizes")]
    public class Size : BaseModel
    {
        public string Name { get; set; }
    }
}