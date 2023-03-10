using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDAO
    {
        public static OrderDAO instance = null;
        public static readonly object instanceLock = new();

        public static OrderDAO Instance
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

        public void Add(Order order)
        {
            using (var db = new FstoreContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new FstoreContext())
            {
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }

        public void Delete(int orderId)
        {
            using (var db = new FstoreContext())
            {
                db.Orders.Remove(db.Orders.FirstOrDefault(order => order.OrderId == orderId));
                db.SaveChanges();
            }
        }

        public List<Order> GetAllData()
        {
            using (var db = new FstoreContext())
            {
                return db.Orders.ToList();
            }
        }
    }
}