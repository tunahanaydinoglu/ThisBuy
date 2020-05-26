using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisBuy.Dal.Context;
using ThisBuy.Dal.Entities;

namespace ThisBuy.Dal.Concrete
{
    public class ProductDAL
    {
        ThisBuyContext db = new ThisBuyContext();

        public IEnumerable<Product> GetAllProduct()
        {
            return db.Products;
        }

        public Product GetProductById(int id)
        {
            return db.Products.Find(id);
        }

        public Product CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
        }

    }
}
