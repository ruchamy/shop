using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core.data
{
    public interface IOrderData
    {
        List<Order> GetAllOrders();
        Order GetById(int id);
        List<Order> GetByUserId(int id);
        List<Order> GetByDate(DateTime date);
        void addOrder(Order order);
        void updateOrder(Order order);
        void removeOrder(int id);
    }
}
