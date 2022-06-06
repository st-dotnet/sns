using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SNSEcom.Domain
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}
