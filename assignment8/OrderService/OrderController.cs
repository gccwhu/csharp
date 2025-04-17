using OrderApp;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OrderApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly OrderService orderService;

        public OrdersController()
        {
            orderService = new OrderService(); // 假设 OrderService 是无状态的
        }

        // 查询所有订单
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllOrders()
        {
            var orders = orderService.Orders;
            return Ok(orders);
        }

        // 根据订单ID查询订单
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetOrderById(string id)
        {
            var order = orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // 添加订单
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("订单数据不能为空");
            }

            try
            {
                orderService.AddOrder(order);
                return Created($"api/orders/{order.OrderId}", order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 更新订单
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateOrder(string id, [FromBody] Order order)
        {
            if (order == null || order.OrderId != id)
            {
                return BadRequest("订单数据无效");
            }

            try
            {
                orderService.UpdateOrder(order);
                return Ok(order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 删除订单
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteOrder(string id)
        {
            try
            {
                orderService.RemoveOrder(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
