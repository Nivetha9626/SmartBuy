using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;

namespace SmartBuy.Domain
{
    public interface ICustomerService
    {
        void DeleteCustomerById(Guid id);
        Customer GetCustomerById(Guid id);
        IEnumerable<Customer> GetCustomers();
        Guid SaveCustomer(CustomerDto customerDto);
    }
}