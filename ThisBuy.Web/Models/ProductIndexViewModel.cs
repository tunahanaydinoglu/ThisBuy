using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThisBuy.Dal.Entities;

namespace ThisBuy.Web.Models
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}