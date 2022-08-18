using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCol
{
    internal class OrderRepository
    {
        List<Order> _orders;

        public Order FetchOrderById(string orderId)
        {
            return null;
        }

        public List<Order> FetchOrders()
        {
            return new List<Order>();
        }

        public List<Order> FetchOrders(String userId)
        {
            return new List<Order>();
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                _orders = new List<Order> { order };
            }
            else
            {
                _orders.Add(order);
            }
        }

        public void AddDummyOrder()
        {
            if (_orders == null) _orders = new List<Order>();

            _orders.Add(new Order("user_xyz", 2300f, 10f, DateTime.Now));
        }
    }
}
