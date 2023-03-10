using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ProductDAO
    {
        public static ProductDAO instance = null;
        public static readonly object instanceLock = new();

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new();
                    }
                }

                return instance;
            }
        }


        public Product GetProductByID(int id)
        {
            using var context = new FstoreContext();
            Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public void Add(Product product)
        {
            using var context = new FstoreContext();
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            using var context = new FstoreContext();
            Product oldproduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);


            oldproduct.UnitPrice = product.UnitPrice;
            oldproduct.UnislnStock = product.UnislnStock;
            oldproduct.Weight = product.Weight;
            oldproduct.OrderDetails = product.OrderDetails;

            context.Products.Update(oldproduct);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            using var context = new FstoreContext();
            Product oldproduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

            context.Products.Remove(oldproduct);
            context.SaveChanges();
        }


        public List<Product> GetAllData()
        {
            using (var db = new FstoreContext())
            {
                return db.Products.ToList();
            }
        }
    }
}