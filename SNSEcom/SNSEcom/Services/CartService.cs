using SNSEcom.Data;
using SNSEcom.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SNSEcom.Services
{
    public class CartService : ICartService
    {
        #region Constructor

        private readonly SNSContext _context;
        public CartService(SNSContext context)
        {
            _context = context;
        }

        #endregion
        public bool DeleteProduct(int Id)
        {
            try
            {
                var data = _context.cart.Where(e => e.Id == Id).FirstOrDefault();
                if (data == null)
                    throw new NullReferenceException();
                _context.cart.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Cart> GetCart()
        {
            try
            {
                var data = _context.cart.ToList();
           
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Cart GetCartById(int Id)
        {
            try
            {
                var data = _context.cart.Find(Id);
                if(data == null)
                    throw new NullReferenceException();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Update(Cart cart)
        {
            try
            {
             var data =  _context.cart.Update(cart);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateCart(int Id)
        {
            try
            {
                var data = _context.cart.Where(c => c.Id == Id).FirstOrDefault();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
