using System;
using System.Collections.Generic;
using System.Text;

namespace ThisBuy.Dal.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public string Map { get; set; }
        public DateTime Time { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Pay> Pays { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<Sale> Sales { get; set; }
    }
}
