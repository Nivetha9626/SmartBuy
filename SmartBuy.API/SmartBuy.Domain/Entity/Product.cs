﻿using System;


namespace SmartBuy.Domain
{
    public class Product : BaseIdAuditEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
