using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Watermarker.Controllers
{
    public class FFMPEGController : Controller
    {
        // GET: FFMPEGController
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
        [HttpPost]
        public IActionResult Create()
        {
            var process = new ProcessStartInfo
            {
                FileName = @"D:\Programs\ffmpeg\ffmpeg.exe",
                Arguments = "-y -i input.mp4 scale=540x380 test2.mp4",
                WorkingDirectory = @"D:\Programs\ffmpeg\",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(process);
            return Ok("Watermark added");
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
