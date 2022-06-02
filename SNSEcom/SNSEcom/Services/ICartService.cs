using SNSEcom.Domain;
using System.Collections.Generic;

namespace SNSEcom.Services
{
    public interface ICartService
    {
        List<Cart> GetCart();
        Cart GetCartById(int Id);
        bool UpdateCart(int Id);
        bool DeleteProduct(int Id);
        bool Update(Cart cart);
    }
}
