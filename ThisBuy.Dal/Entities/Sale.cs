using System;
using System.Collections.Generic;
using System.Text;

namespace ThisBuy.Dal.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
