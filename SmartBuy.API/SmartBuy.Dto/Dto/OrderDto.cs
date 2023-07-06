using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Dto
{
    public class OrderDto : BaseIdAuditEntityDto
    {
        public Guid TransactionId { get; set; }
    }
}
