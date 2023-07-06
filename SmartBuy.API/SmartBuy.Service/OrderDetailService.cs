using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepository<OrderDetail> _orderDetailRepo;

        public OrderDetailService(IRepository<OrderDetail> orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }


        public void DeleteOrderDetail(Guid Id)
        {
            var orderDetail = GetOrderDetailById(Id);
            _orderDetailRepo.Delete(orderDetail);
            _orderDetailRepo.CommitChanges();
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepo.GetAll();

        }

        public OrderDetail GetOrderDetailById(Guid Id)
        {
            return _orderDetailRepo.Get(o => o.Id == Id).FirstOrDefault();

        }

        public OrderDetail SaveOrderDetail(OrderDetailDto orderDetailDto)
        {
            var orderDetail = new OrderDetail()
            {
                OrderId = orderDetailDto.OrderId,
                UnitPrice = orderDetailDto.UnitPrice,
                ProductId = orderDetailDto.ProductId,
                CreatedBy = orderDetailDto.CreatedBy,
                CreatedOn = orderDetailDto.CreatedOn,
                ModifiedOn = orderDetailDto.ModifiedOn,
                ModifiedBy = orderDetailDto.ModifiedBy,
                Id = orderDetailDto.Id,
                ProductCount = orderDetailDto.ProductCount
            };

            orderDetail = _orderDetailRepo.Insert(orderDetail);
            _orderDetailRepo.CommitChanges();
            return orderDetail;

        }
    }
}
