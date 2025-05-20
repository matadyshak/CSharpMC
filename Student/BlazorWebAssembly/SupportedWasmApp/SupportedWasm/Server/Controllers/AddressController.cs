using Microsoft.AspNetCore.Mvc;
using SupportedWasm.Shared.Models;

namespace SupportedWasm.Server.Controllers
{
    public class AddressController : Controller
    {
        private ILogger<AddressController> _logger;

        private AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }

        // GET: AddressController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddressController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddressController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressModel address)
        {
            _logger.LogInformation("Posted Address: {AddressLine1} {AddressLine2} {City} {State}  {Zipcode}",
                address.AddressLine1, address.AddressLine2, address.City, address.State, address.Zipcode);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddressController/Edit/5
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

        // GET: AddressController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressController/Delete/5
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
