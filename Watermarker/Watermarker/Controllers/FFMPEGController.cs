using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // GET: FFMPEGController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FFMPEGController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
