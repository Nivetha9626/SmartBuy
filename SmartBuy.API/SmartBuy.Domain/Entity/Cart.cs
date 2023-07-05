using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Domain
{
    public class Cart : BaseIdAuditEntity
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
