

using System;

namespace SmartBuy.Domain
{
    public class Customer : BaseIdAuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
