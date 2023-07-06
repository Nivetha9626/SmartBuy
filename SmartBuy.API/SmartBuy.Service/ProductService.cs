using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuy.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepo.GetAll();
        }

        public Product GetProductById(Guid id)
        {
            return _productRepo.Get(p => p.Id == id).FirstOrDefault();
        }

        public void DeleteProductById(Guid id)
        {
            var product = GetProductById(id);
            _productRepo.Delete(product);
            _productRepo.CommitChanges();
        }

        public Guid SaveProduct(ProductDto productDto)
        {
            //we have to do mapping using automapper

            var prod = GetProductById(productDto.Id);
            var product = new Product();

            if (prod != null)
            {
                prod.Id = productDto.Id;
                prod.Name = productDto.Name;
                prod.Price = productDto.Price;
                prod.Description = productDto.Description;
                prod.Stock = productDto.Stock;
                prod.ModifiedBy = productDto.ModifiedBy;
                prod.ModifiedOn = productDto.ModifiedOn;
                _productRepo.Update(prod);
            }
            else
            {
                product.Id = productDto.Id;
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Description = productDto.Description;
                product.Stock = productDto.Stock;
                product.ModifiedBy = productDto.ModifiedBy;
                product.ModifiedOn = productDto.ModifiedOn;

                product = _productRepo.Insert(product);
            }

            _productRepo.CommitChanges();
            return product.Id;
        }
    }
}