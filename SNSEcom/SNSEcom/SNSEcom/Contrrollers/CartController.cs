using Microsoft.AspNetCore.Mvc;
using SNSEcom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Contrrollers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService  cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var data = _cartService.GetCartItems();
            return View(data);
        }
        public IActionResult Delete(int Id)
        {
            var data = _cartService.DeleteCartItem(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
