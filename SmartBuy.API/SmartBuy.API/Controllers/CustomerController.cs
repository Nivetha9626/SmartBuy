using Microsoft.AspNetCore.Mvc;
using SmartBuy.Domain;
using SmartBuy.Dto;
using System;

namespace SmartBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("list")]
        public IActionResult GetCustomers()
        {
            return Ok(_customerService.GetCustomers());
        }

        [HttpPost("save")]
        public IActionResult SaveCustomers(CustomerDto CustomerDto)
        {
            return Ok(_customerService.SaveCustomer(CustomerDto));
        }

        [HttpGet]
        public IActionResult GetCustomer(Guid id)
        {
            return Ok(_customerService.GetCustomerById(id));
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(Guid id)
        {
            _customerService.DeleteCustomerById(id);
            return Ok();
        }
    }
}