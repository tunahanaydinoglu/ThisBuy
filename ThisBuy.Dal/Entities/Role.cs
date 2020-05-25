using System;
using System.Collections.Generic;
using System.Text;

namespace ThisBuy.Dal.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }


        public List<User> Users { get; set; }

    }
}
