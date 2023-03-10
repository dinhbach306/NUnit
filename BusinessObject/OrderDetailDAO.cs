using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetailDAO
    {
        public static OrderDetailDAO instance = null;
        public static readonly object instanceLock = new();

        public static OrderDetailDAO Instance
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

        public void Add(OrderDetail entity)
        {
            using (var db = new FstoreContext())
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new FstoreContext())
            {
                db.OrderDetails.Remove(db.OrderDetails.FirstOrDefault(orderDetail => orderDetail.OrderId == id));
                db.SaveChanges();
            }
        }

        public void Update(OrderDetail entity)
        {
            using (var db = new FstoreContext())
            {
                db.OrderDetails.Update(entity);
                db.SaveChanges();
            }
        }

        public List<OrderDetail> GetAllData()
        {
            using (var db = new FstoreContext())
            {
                return db.OrderDetails.ToList();
            }
        }
    }
}