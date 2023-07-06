using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Domain.Interface
{
    public interface IOrderService
    {
        Order SaveOrder(OrderDto orderDto);

        Order GetOrderById(Guid Id);

        IEnumerable<Order> GetAllOrders();
        void DeleteOrder(Guid Id);

    }
}
