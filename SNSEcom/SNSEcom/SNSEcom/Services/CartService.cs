using SNSEcom.Data;
using SNSEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Services
{
    public class CartService : ICartService
    {
        private readonly SNSContext _context;

        public CartService(SNSContext context)
        {
            _context = context;
        }
        public int DeleteCartItem(int Id)
        {
            try
            {
                var data = _context.ShoppingCart.Where(x => x.CartId == Id).FirstOrDefault();
                int itemCount = 0;
                if (data == null)
                    throw new NullReferenceException();
                _context.ShoppingCart.Remove(data);
                _context.SaveChanges();
                if (data != null)
                {
                    if (data.Count > 1)
                    {
                        data.Count--;
                        itemCount = data.Count;
                    }
                    else
                    {
                        _context.ShoppingCart.Remove(data);
                    }
                }
                return itemCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ShoppingCart> GetCartItems()
        {
            try
            {
                var data = _context.ShoppingCart.ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
