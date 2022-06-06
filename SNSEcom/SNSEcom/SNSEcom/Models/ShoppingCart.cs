using SNSEcom.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public string Quantity { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public string Description { get; set; }



    }
}
