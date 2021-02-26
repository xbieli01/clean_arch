using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNewProject.Data.Orders;
using MyNewProject.Domain.Orders;

namespace MyNewProject.Framework.DataSources
{
    public class InMemoryOrdersSource: IOrdersSource
    {
        public async Task<IReadOnlyList<Order>> GetAll()
        {
            await Task.Delay(1000);
            return new List<Order>
            {
                    new Order
                    {
                        OrderId = 1001,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1002,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1003,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1004,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1005,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1006,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1007,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1008,
                        DeliveryTime = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 1009,
                        DeliveryTime = DateTime.Now
                    }
            };
        }
    }
}
