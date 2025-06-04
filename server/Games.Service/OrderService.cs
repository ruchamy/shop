using Games.Core;
using Games.Core.data;
using Games.Core.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderData orderData;
        public OrderService(IOrderData _orderData)
        {
            orderData = _orderData;
        }
        public void addOrder(Order order)
        {
            orderData.addOrder(order);
        }

        public List<Order> GetAllOrders()
        {
           return orderData.GetAllOrders();
        }

        public List<Order> GetByDate(DateTime date)
        {
            return orderData.GetByDate(date);
        }

        public Order GetById(int id)
        {
            return orderData.GetById(id);
        }

        public List<Order> GetByUserId(int id)
        {
            return orderData.GetByUserId(id);
        }

        public void removeOrder(int id)
        {
            orderData.removeOrder(id);
        }

        public void updateOrder(Order order)
        {
           orderData.updateOrder(order);
        }
    }
}
