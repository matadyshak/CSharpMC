using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCNameEntry.Controllers
{
    public class NameEntryController : Controller
    {
        // GET: NameEntryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NameEntryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NameEntryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NameEntryController/Create
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

        // GET: NameEntryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NameEntryController/Edit/5
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

        // GET: NameEntryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NameEntryController/Delete/5
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
