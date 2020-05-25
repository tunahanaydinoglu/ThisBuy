using System;
using System.Collections.Generic;
using System.Text;

namespace ThisBuy.Dal.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
