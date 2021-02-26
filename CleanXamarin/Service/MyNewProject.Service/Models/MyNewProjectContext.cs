using System;
using Microsoft.EntityFrameworkCore;
using MyNewProject.Domain.Orders;

namespace MyNewProject.Service.Models
{
    public class MyNewProjectContext : DbContext
    {
        public MyNewProjectContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                OrderStatus = OrderStatus.PENDING,
                DeliveryMethod = DeliveryMethod.STORE,
                DeliveryTime = new DateTime(2020, 04, 25, 19, 00,00)

            }, new Order
            {
                OrderId = 2,
                OrderStatus = OrderStatus.REJECTED,
                DeliveryMethod = DeliveryMethod.STORE,
                DeliveryTime = new DateTime(2020, 04, 25, 19, 00, 00)
            });
        }
    }
}
