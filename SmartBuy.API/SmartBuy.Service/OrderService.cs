using SmartBuy.Domain;
using SmartBuy.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;
        public OrderService(IRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void DeleteOrder(Guid Id)
        {
            var order = GetOrderById(Id);
            _orderRepo.Delete(order);
            _orderRepo.CommitChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetAll();

        }

        public Order GetOrderById(Guid Id)
        {
            return _orderRepo.Get(o => o.Id == Id).FirstOrDefault();

        }

        public Order SaveOrder(OrderDto orderDto)
        {
            var order = new Order()
            {
                Id = orderDto.Id,
                TransactionId = orderDto.TransactionId,
                CreatedBy = orderDto.CreatedBy,
                CreatedOn = orderDto.CreatedOn,
                ModifiedBy = orderDto.ModifiedBy,
                ModifiedOn = orderDto.ModifiedOn,
            };

            order = _orderRepo.Insert(order);
            _orderRepo.CommitChanges();
            return order;

        }
    }
}
