using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Watermarker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {
            if (files.Count == 0)
                return BadRequest();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            
            foreach(var file in files) 
            {
                string filePath = Path.Combine(directoryPath, file.FileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var startInfo = new ProcessStartInfo
            {
                FileName = @"D:\Programs\ffmpeg\ffmpeg.exe",
                Arguments = "-y -i input.mp4 scale=540x380 test2.mp4",
                WorkingDirectory = @"D:\Programs\ffmpeg\",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }
            return Ok("Upload Complete");
        }
    }
}
