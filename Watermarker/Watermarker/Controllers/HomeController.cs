using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Watermarker.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _env;
        public HomeController (IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WatermarkUpload(IFormFile file)
        {
            
            string dir = Path.Combine(_env.ContentRootPath, "UploadedFiles");
            string filePath = Path.Combine(dir, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            
            return RedirectToAction("Index");
        }
    }
}
