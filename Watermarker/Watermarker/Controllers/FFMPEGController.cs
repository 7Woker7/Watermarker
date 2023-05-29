using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Watermarker.Controllers
{
    public class FFMPEGController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FFMPEGController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: FFMPEGController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: FFMPEGController/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadVideo(IFormFile video)
        {
            var mine = video.FileName.Split('.').Last();
            var fileName = string.Concat(Path.GetRandomFileName(), ".", mine);
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            var savePath = Path.Combine(directoryPath, fileName);

            await using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                await video.CopyToAsync(fileStream);
            }

            await Task.Run(() =>
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(_webHostEnvironment.ContentRootPath, "ffmpeg", "ffmpeg.exe"),
                    Arguments = "-i input.mp4 -i watermark.png -filter_complex \"overlay = 5:5\"  D:\\output.mp4",
                    WorkingDirectory = directoryPath,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                ProcessStartInfo startInfo2 = new ProcessStartInfo(@"ffmpeg\\ffmpeg.exe");
                Process.Start(startInfo2);
                startInfo2.Arguments = $"-i input.mp4 -i watermark.png D:\\output.mp4";
                Process.Start(startInfo2);
                //using (var process = new Process { StartInfo = startInfo2 })
                //{
                //    process.Start();
                //    process.WaitForExit();
                //}
            });
            return Ok();

        }

        // GET: FFMPEGController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FFMPEGController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FFMPEGController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FFMPEGController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
