using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThisBuy.Dal.Entities;

namespace ThisBuy.Web.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Pay> Pays { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public Comment Comment { get; set; }
        public Pay Pay { get; set; }
    }
}