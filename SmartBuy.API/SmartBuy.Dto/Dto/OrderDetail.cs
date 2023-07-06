using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Dto
{
    public class OrderDetailDto : BaseIdAuditEntityDto
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid CustomerId { get; set; }
    }
}
