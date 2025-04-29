using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCMessageWall.Controllers
{
    public class MessageWallController : Controller
    {
        // GET: MessageWall
        public ActionResult Index()
        {
            return View();
        }

        // GET: MessageWall/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MessageWall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageWall/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageWall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MessageWall/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageWall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MessageWall/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}