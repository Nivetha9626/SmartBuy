using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Dto
{
    public class CartDto : BaseIdAuditEntityDto
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
