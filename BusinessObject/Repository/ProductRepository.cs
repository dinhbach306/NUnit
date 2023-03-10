using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product) => ProductDAO.Instance.Add(product);

        public void Delete(Product product) => ProductDAO.Instance.Delete(product);

        public void Update(Product product) => ProductDAO.Instance.Update(product);

        public void GetProductByID(int productId) => ProductDAO.Instance.GetProductByID(productId);

        public List<Product> GetAll() => ProductDAO.Instance.GetAllData();
    }
}