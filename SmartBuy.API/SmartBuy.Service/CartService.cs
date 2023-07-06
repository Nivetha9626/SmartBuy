using SmartBuy.Domain;
using SmartBuy.Domain.Interface;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Service
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepo;
        public CartService(IRepository<Cart> cartRepo)
        {

            _cartRepo = cartRepo;

        }
        public void DeleteCart(Guid id)
        {
            var cart = GetCartbyId(id);
            _cartRepo.Delete(cart);
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _cartRepo.GetAll();
        }

        public Cart GetCartbyId(Guid id)
        {
            return _cartRepo.Get(c => c.Id == id).FirstOrDefault();
        }

        public Guid SaveCart(CartDto cartDto)
        {
            var cart = new Cart()
            {
                Id = cartDto.Id,
                ProductId = cartDto.ProductId,
                ProductCount = cartDto.ProductCount,
                CreatedBy = cartDto.CreatedBy,
                CreatedOn = cartDto.CreatedOn,
                ModifiedBy = cartDto.ModifiedBy,
                ModifiedOn = cartDto.ModifiedOn,
            };
            cart = _cartRepo.Insert(cart);
            return cart.Id;



        }
    }
}
