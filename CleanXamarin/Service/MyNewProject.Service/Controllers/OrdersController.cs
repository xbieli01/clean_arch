using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNewProject.Domain.Orders;
using MyNewProject.Service.Models;
using MyNewProject.Service.Models.Repository;

namespace MyNewProject.Service.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDataRepository<Order> _dataRepository;

        public OrderController(IDataRepository<Order> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Domain.Orders.Order> orders = _dataRepository.GetAll();
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Order order = _dataRepository.Get(id);

            if (order == null)
            {
                return NotFound("The Order record couldn't be found.");
            }

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is null.");
            }

            _dataRepository.Add(order);
            return CreatedAtRoute(
                  "Get",
                  new { Id = order.OrderId },
                  order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is null.");
            }

            Order orderToUpdate = _dataRepository.Get(id);
            if (orderToUpdate == null)
            {
                return NotFound("The Order record couldn't be found.");
            }

            _dataRepository.Update(orderToUpdate);
            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Order order = _dataRepository.Get(id);
            if (order == null)
            {
                return NotFound("The Order record couldn't be found.");
            }

            _dataRepository.Delete(order.OrderId);
            return NoContent();
        }
    }
}
