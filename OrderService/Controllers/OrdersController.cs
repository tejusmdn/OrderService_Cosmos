using CafeCommon;
using CafeCommon.Models;
using Microsoft.AspNetCore.Mvc;
using OrderService.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: <OrderController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderRepository.GetAll();
        }

        // GET <OrderController>/5
        [HttpGet("{id}")]
        public Order? Get(string id)
        {
            var order = _orderRepository.Get(id);
            return order;
        }

        // POST <OrderController>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            if (string.IsNullOrEmpty(order.Id))
            {
                order.Id = Guid.NewGuid().ToString();
            }

            _orderRepository.Add(order);
        }

        // PUT <OrderController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Order order)
        {
            _orderRepository.Update(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
