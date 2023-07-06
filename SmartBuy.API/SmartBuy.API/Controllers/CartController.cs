using Microsoft.AspNetCore.Mvc;
using SmartBuy.Domain.Interface;
using SmartBuy.Dto;
using System;

namespace SmartBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("list")]
        public IActionResult GetCarts()
        {
            return Ok(_cartService.GetAllCarts());
        }

        [HttpPost("save")]
        public IActionResult SaveCarts(CartDto CartDto)
        {
            return Ok(_cartService.SaveCart(CartDto));
        }

        [HttpGet]
        public IActionResult GetCart(Guid id)
        {
            return Ok(_cartService.GetCartbyId(id));
        }

        [HttpDelete]
        public IActionResult DeleteCart(Guid id)
        {
            _cartService.DeleteCart(id);
            return Ok();
        }
    }
}