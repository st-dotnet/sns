using Microsoft.AspNetCore.Mvc;
using SNSEcom.Domain;
using SNSEcom.Services;

namespace SNSEcom.Contrrollers
{
    public class ProductController : Controller
    {
        #region Constructor
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        #endregion
        public IActionResult Index()
        {
            var data = _service.GetProducts();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products products)
        {
            var data = _service.AddProducts(products);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("/Product/Edit/{id}")]
        public IActionResult Edit(int Id)
        {
            var data = _service.UpdateProducts(Id);
            return View(data);
        }
        public IActionResult Save(Products model)
        {
            var prod = _service.Save(model);
            return RedirectToAction(nameof(Index));
        }
 
        public IActionResult Delete(int Id)
        {
            var data = _service.DeleteProducts(Id);
            if(Id==0)
            {
                return NotFound();
            }
          return  RedirectToAction(nameof(Index));
        }
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}
