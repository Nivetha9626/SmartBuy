using SmartBuy.Dto;
using System;
using System.Collections.Generic;

namespace SmartBuy.Domain
{
    public interface IOrderService
    {
        Order SaveOrder(OrderDto orderDto);

        Order GetOrderById(Guid Id);

        IEnumerable<Order> GetAllOrders();

        void DeleteOrder(Guid Id);
    }
}