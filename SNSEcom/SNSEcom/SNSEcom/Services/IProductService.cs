using SNSEcom.Domain;
using SNSEcom.Models;
using System.Collections.Generic;

namespace SNSEcom.Services
{
    public interface IProductService
    {
        List<Products> GetProducts();
        Products GetProductsById(int Id);
        bool AddProducts(Products products);
        Products UpdateProducts(int Id);
        bool DeleteProducts(int Id);
        bool Save(Products product);

        bool AddToCart(Products products);
        List<ShoppingCart> GetCartItems();
    }
}
