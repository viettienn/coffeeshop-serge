using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsNew () {

            return Id > 0;
        }
    }
}