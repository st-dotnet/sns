using Microsoft.AspNetCore.Mvc;
using SNSEcom.Models;
using SNSEcom.Services;

namespace SNSEcom.Contrrollers
{
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }
        public ActionResult Index()
        {
            SingleFileModel model = new SingleFileModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Upload(SingleFileModel models)
        {

           _uploadService.Upload(models);
            models.IsResponse = models.IsResponse;
            models.IsSuccess = models.IsResponse;
            models.Message = models.Message;
            return View("Index", models);
            }
    }
}

