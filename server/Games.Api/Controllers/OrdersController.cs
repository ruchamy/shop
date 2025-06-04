using AutoMapper;
using Games.Core;
using Games.Core.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Games.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService _orderService, IMapper _mapper)
        {
            orderService = _orderService;
            mapper = _mapper;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        [Authorize]
        //לשימוש מנהל בלבד 
        public IEnumerable<OrderDTO> Get()
        {
            var orders = orderService.GetAllOrders();
            return mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("GetById/{id}")]
        public ActionResult<OrderDTO> GetById(int id)
        {
            var order = orderService.GetById(id);
            if (order == null) return new NotFoundResult();
            return Ok( mapper.Map<OrderDTO>(order));
        }

        // GET api/<OrdersController>/UserId
        [HttpGet("GetByUserId/{id}")]
        public IEnumerable<OrderDTO> GetByUserId(int id)
        {
            var orders = orderService.GetByUserId(id);
            return mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        // GET api/<OrdersController>/Date
        [HttpGet("GetByDate/{date}")]
        public IEnumerable<OrderDTO> GetByDate(DateTime date)
        {
            var orders = orderService.GetByDate(date);
            return mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] OrderDTO orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            orderService.addOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDTO orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            order.Id = id;
            orderService.updateOrder(order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderService.removeOrder(id);
        }
    }
}
