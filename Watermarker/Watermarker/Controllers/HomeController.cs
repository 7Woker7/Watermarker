using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Xabe.FFmpeg;

namespace Watermarker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public HomeController (IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile watermark, IFormFile video, int position)
        {
            string dir = Path.Combine(_env.ContentRootPath, "UploadedFiles");
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            
            // Watermark upload
            string watermarkExt = watermark.FileName.Split('.').Last();
            string fileName = string.Concat(Path.GetRandomFileName(), ".", watermarkExt);
            string filePath = Path.Combine(dir, fileName);
            await using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await watermark.CopyToAsync(stream);
            }

            // Video upload
            string videoExt = video.FileName.Split('.').Last();
            string videoName = string.Concat(Path.GetRandomFileName(), ".", videoExt);
            string videoPath = Path.Combine(dir, videoName);
            await using(var stream = new FileStream(videoPath, FileMode.Create, FileAccess.Write))
            {
                await video.CopyToAsync(stream);
            }

            // Video 
            string outputName = string.Concat(Path.GetRandomFileName(), ".mp4");
            string outputPath = Path.Combine(dir, outputName);
            IConversion conversion = await FFmpeg.Conversions.FromSnippet.SetWatermark(videoPath, outputPath, filePath, (Position)position);
            IConversionResult result = await conversion.Start();
            var bytes = await System.IO.File.ReadAllBytesAsync(outputPath);
            return File(bytes, "text/plain", Path.GetFileName(outputPath));

        }
    }
}
