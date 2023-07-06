using Microsoft.AspNetCore.Mvc;
using SmartBuy.Domain;
using SmartBuy.Dto;
using System;

namespace SmartBuy.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpPost("save")]
        public IActionResult SaveProducts(ProductDto productDto)
        {
            return Ok(_productService.SaveProduct(productDto));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            _productService.DeleteProductById(id);
            return Ok();
        }
    }
}