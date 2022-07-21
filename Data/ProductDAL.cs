using CRUDUsingEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUDUsingEF.Data
{
    public class ProductDAL
    {
        ApplicationDbContext db;
        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            // return db.Products.ToList();
            var result = from p in db.Products
                         select p;
            return result;
        }
        public Product GetProductById(int id)
        {
            Product p = db.Products.Where(x => x.Pid == id).FirstOrDefault();
            return p;
        }
        public int AddProduct(Product prod)
        {
            db.Products.Add(prod);
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateProduct(Product prod)
        {
            int result = 0;
            Product p = db.Products.Where(x => x.Pid == prod.Pid).FirstOrDefault();
            if(p!=null)
            {
                p.Pname = prod.Pname;
                p.Price = prod.Price;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            Product p = db.Products.Where(x => x.Pid == id).FirstOrDefault();
            if (p != null)
            {
                db.Products.Remove(p);
                result = db.SaveChanges();
            }
            return result;

        }



    }
}

