using System;
using System.Collections.Generic;

namespace MyNewProject.Domain.Orders
{
    public class Order
    {
        public Order(){ }

        public long OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
