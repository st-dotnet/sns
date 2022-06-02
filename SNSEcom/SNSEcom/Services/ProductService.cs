using SNSEcom.Data;
using SNSEcom.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                _context.product.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Products UpdateProducts(int Id)
        {
            try
            {
                var data = _context.product.Where(x => x.ProductId == Id).FirstOrDefault();
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
