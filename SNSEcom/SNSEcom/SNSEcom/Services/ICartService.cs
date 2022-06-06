using SNSEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Services
{
  public interface ICartService
    {
        List<ShoppingCart> GetCartItems();
        int DeleteCartItem(int Id);
    }
}
