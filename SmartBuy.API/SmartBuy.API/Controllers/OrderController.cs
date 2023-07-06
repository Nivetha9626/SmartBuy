using Microsoft.AspNetCore.Mvc;
using SmartBuy.Domain;
using SmartBuy.Dto;
using System;

namespace SmartBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("list")]
        public IActionResult GetOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpPost("save")]
        public IActionResult SaveOrders(OrderDto OrderDto)
        {
            return Ok(_orderService.SaveOrder(OrderDto));
        }

        [HttpGet]
        public IActionResult GetOrder(Guid id)
        {
            return Ok(_orderService.GetOrderById(id));
        }

        [HttpDelete]
        public IActionResult DeleteOrder(Guid id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}