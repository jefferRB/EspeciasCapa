using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EspeciasCapa.Controllers
{
    public class RecuperarController : Controller
    {
        // GET: RecuperarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RecuperarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecuperarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecuperarController/Create
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

        // GET: RecuperarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecuperarController/Edit/5
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

        // GET: RecuperarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecuperarController/Delete/5
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
