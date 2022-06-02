using Microsoft.AspNetCore.Mvc;
using SNSEcom.Domain;
using SNSEcom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Contrrollers
{
    public class CartController : Controller
    {
        private readonly ICartService _cart;
        public CartController(ICartService cart)
        {
            _cart = cart;
        }
        public IActionResult Index()
        {
            var data = _cart.GetCart();
            return View(data);
        }
        [Route("Cart/Edit/{id}")]
        public IActionResult Edit(int Id)
        {
            var data = _cart.UpdateCart(Id);
            return View(data);
        }
        public IActionResult Edit(Cart model)
        {
            var prod = _cart.Update(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
