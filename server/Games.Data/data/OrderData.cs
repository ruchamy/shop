using Games.Core;
using Games.Core.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Data.data
{
    public class OrderData : IOrderData
    {
        private readonly DataContext dataContext;
        public OrderData(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public void addOrder(Order order)
        {
            dataContext.orders.Add(order);
            dataContext.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return dataContext.orders.Include(x=>x.User).ToList();
        }

        public Order GetById(int id)
        {
            return dataContext.orders.Include(x=>x.User).FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetByUserId(int id)
        {
            return dataContext.orders.Where(x=>x.UserId == id).Include(x => x.User).ToList();
        }

        public List<Order> GetByDate(DateTime date)
        {
            return dataContext.orders.Where(x => x.Date.Equals(date)).Include(x => x.User).ToList();
        }

        public void removeOrder(int id)
        {
            Order o = GetById(id);
            if (o != null)
            {
                dataContext.orders.Remove(o);
                dataContext.SaveChanges();
            }
        }

        public void updateOrder(Order order)
        {
            Order o = GetById(order.Id);
            if (o != null)
            {
                o.Date = order.Date;
                o.User = order.User;
                o.UserId = order.UserId;
                o.Sum = order.Sum;
                dataContext.SaveChanges();
            }
        }
    }
}
