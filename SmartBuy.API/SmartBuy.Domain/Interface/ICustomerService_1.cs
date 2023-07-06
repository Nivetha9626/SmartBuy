using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;

namespace SmartBuy.Domain
{
    public interface ICustomerService
    {
        void DeleteProductById(Guid id);
        Product GetProductById(Guid id);
        IEnumerable<Product> GetProducts();
        Guid SaveProduct(ProductDto productDto);
    }
}