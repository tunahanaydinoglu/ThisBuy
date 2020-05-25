using System;
using System.Collections.Generic;
using System.Text;

namespace ThisBuy.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string About { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Pay> Pays { get; set; }
        public virtual List<Sale> Sales { get; set; }
    }
}
