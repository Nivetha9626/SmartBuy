using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBuy.Domain;
using SmartBuy.Dto;

namespace SmartBuy.API.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(_productService.GetProducts());
        }

        [HttpGet("save")]
        public IActionResult SaveProducts(ProductDto productDto)
        {
            return Ok(_productService.SaveProduct(productDto));
        }
    }
}
