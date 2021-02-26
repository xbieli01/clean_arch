using System.Collections.Generic;
using System.Linq;
using MyNewProject.Domain.Orders;
using MyNewProject.Service.Models.Repository;

namespace MyNewProject.Service.Models.DataManager
{
    public class OrderManager : IDataRepository<Order>
    {
        readonly MyNewProjectContext _dbContext;

        public OrderManager(MyNewProjectContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order Get(long id)
        {
            return _dbContext.Orders.FirstOrDefault(e => e.OrderId == id);
        }

        public void Add(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Order entity)
        {
            var order = _dbContext.Orders.FirstOrDefault(e => e.OrderId == entity.OrderId);
            order.DeliveryMethod = entity.DeliveryMethod;
            order.DeliveryTime = entity.DeliveryTime;
            order.OrderStatus = entity.OrderStatus;

            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var order = _dbContext.Orders.FirstOrDefault(e => e.OrderId == id);
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
