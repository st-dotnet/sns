﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public int? Total { get; set; }
        public int Quantity { get; set; }
        public ICollection<CartItem> Carts { get; set; }
    }
}
