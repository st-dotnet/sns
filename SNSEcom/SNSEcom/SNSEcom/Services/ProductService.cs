using Microsoft.EntityFrameworkCore;
using SNSEcom.Data;
using SNSEcom.Domain;
using SNSEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Services
{
    public class ProductService : IProductService
    {
        #region Constructor

        private readonly SNSContext _context;
        public ProductService(SNSContext context)
        {
            _context = context;
        }
        
        #endregion

        public bool AddProducts(Products products)
        {
            try
            {
             _context.product.Add(products);
             _context.SaveChanges();
             return true;
            }
            catch (Exception ex)
            {
              throw new Exception(ex.Message);
            }
        }

        public bool AddToCart(Products products)
        {
            ShoppingCart storeDB = new ShoppingCart();
            var cartItem = _context.ShoppingCart.SingleOrDefault(c => c.ProductId == products.ProductId);
            if (cartItem == null)
            {
                ShoppingCart cartItems = new()
                {
                    ProductId = products.ProductId,
                    DateCreated = DateTime.Now,
                    Count=1,
                    Quantity=products.Quantity,
                    Description=products.Description,

                };
                _context.ShoppingCart.Add(cartItems);
               
            }
            else { cartItem.Count++; }
            _context.SaveChanges();
            return true;
        }
        public bool DeleteProducts(int Id)
        {
            try
            {
                var data = _context.product.Where(x => x.ProductId == Id).FirstOrDefault();
                if (data == null)
                    throw new NullReferenceException();
                _context.product.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Products> GetProducts()
        {
            try
            {
                var data = _context.product.ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Products GetProductsById(int Id)
        {
            try
            {
                var data = _context.product.Find(Id);
                if (data == null)
                    throw new NullReferenceException();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Save(Products product)
        {
            _context.product.Update(product);
            _context.SaveChanges();
            return true;
        }

        public Products UpdateProducts(int Id)
        {
            var data = _context.product.Where(x => x.ProductId == Id).FirstOrDefault();
            return data;
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
