using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;

namespace SmartBuy.Domain
{
    public interface IOrderDetailService
    {
        void DeleteOrderDetail(Guid Id);
        IEnumerable<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailById(Guid Id);
        OrderDetail SaveOrderDetail(OrderDetailDto orderDetailDto);
    }
}