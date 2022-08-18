using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCol
{
    internal class Order
    {
        public Order(string userId, float orderTotal, float orderTax, DateTime orderDate)
        {
            UserId = userId;
            OrderTotal = orderTotal;
            OrderTax = orderTax;
            OrderDate = orderDate;
        }

        public string OrderId { get; set; }
        public string UserId { get; set; }
        public float OrderTotal { get; set; }
        public float OrderTax { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
