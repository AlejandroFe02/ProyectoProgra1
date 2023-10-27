using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoProg1.Controllers
{
    public class PrecioController : Controller
    {
        // GET: PrecioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PrecioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrecioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrecioController/Create
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

        // GET: PrecioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrecioController/Edit/5
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

        // GET: PrecioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrecioController/Delete/5
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
