using Microsoft.AspNetCore.Mvc;
using SmartBuy.Domain;
using SmartBuy.Dto;
using System;

namespace SmartBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICustomerService _productService;

        public ProductController(ICustomerService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpPost("save")]
        public IActionResult SaveProducts(ProductDto productDto)
        {
            return Ok(_productService.SaveProduct(productDto));
        }

        [HttpGet]
        public IActionResult GetProduct(Guid id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpDelete]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProductById(id);
            return Ok();
        }
    }
}