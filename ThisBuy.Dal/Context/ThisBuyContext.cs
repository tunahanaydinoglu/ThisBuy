using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisBuy.Dal.Entities;
using ThisBuy.Dal.Migrations;

namespace ThisBuy.Dal.Context
{
    public class ThisBuyContext : DbContext
    {
        public ThisBuyContext() : base("ThisBuyContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ThisBuyContext, Configuration>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
