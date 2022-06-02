using System;

namespace SNSEcom.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public int CartId { get; set; }
        public string Quentity { get; set; }
        public DateTime DateCreated { get; set; }
        public  int ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Products Products { get; set; }
    }
}
