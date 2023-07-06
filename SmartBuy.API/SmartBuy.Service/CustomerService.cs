using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuy.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepo;

        public CustomerService(IRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepo.GetAll();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _customerRepo.Get(p => p.Id == id).FirstOrDefault();
        }

        public void DeleteCustomerById(Guid id)
        {
            var customer = GetCustomerById(id);
            _customerRepo.Delete(customer);
            _customerRepo.CommitChanges();
        }

        public Guid SaveCustomer(CustomerDto customerDto)
        {
            //we have to do mapping using automapper

            var customer = new Customer()
            {
                Id = customerDto.Id,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                DOB = customerDto.DOB,
                Email = customerDto.Email,
                Address = customerDto.Address,
                CreatedBy = customerDto.CreatedBy,
                CreatedOn = customerDto.CreatedOn,
                ModifiedBy = customerDto.ModifiedBy,
                ModifiedOn = customerDto.ModifiedOn,
            };

            customer = _customerRepo.Insert(customer);
            _customerRepo.CommitChanges();
            return customer.Id;
        }
    }
}