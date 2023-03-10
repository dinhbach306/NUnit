using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class OrderRepository : IOrderRepository<Order>
    {
        public void Add(Order order) => OrderDAO.Instance.Add(order);

        public void Delete(int id) => OrderDAO.Instance.Delete(id);

        public void Update(Order order) => OrderDAO.Instance.Update(order);

        public List<Order> GetAll() => OrderDAO.Instance.GetAllData();
    }
}
