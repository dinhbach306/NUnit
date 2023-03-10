using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository<OrderDetail>
    {
        public void Add(OrderDetail entity) => OrderDetailDAO.Instance.Add(entity);

        public void Delete(int id) => OrderDetailDAO.Instance.Delete(id);

        public void Update(OrderDetail entity) => OrderDetailDAO.Instance.Update(entity);

        public List<OrderDetail> GetAll() => OrderDetailDAO.Instance.GetAllData();
    }
}
