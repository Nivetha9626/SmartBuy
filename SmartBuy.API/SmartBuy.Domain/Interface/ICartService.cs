using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Domain.Interface
{
    public interface ICartService
    {
        Guid SaveCart(CartDto cartDto);
        void DeleteCart(Guid id);
        Cart GetCartbyId(Guid id);

        IEnumerable<Cart> GetAllCarts();
    }
}
