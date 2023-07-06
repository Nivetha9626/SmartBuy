using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Dto
{
    public class OrderDto : BaseIdAuditEntityDto
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid CustomerId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
