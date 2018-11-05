using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spaApp.Models;
using spaApp.Services;

namespace spaApp.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            return View(Repository.providers);
        }

        // GET: Provider/Details/5
        public ActionResult Details(int id)
        {
            return View(Repository.GetProvider(id));
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Provider provider)
        {
            try
            {
                // TODO: Add insert logic here
                Repository.Add(provider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Provider/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.GetProvider(id));
        }

        // POST: Provider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Provider provider)
        {
            try
            {
                // TODO: Add update logic here
                Repository.Update(id, provider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repository.GetProvider(id));
        }

        // POST: Provider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Provider provider)
        {
            try
            {
                // TODO: Add delete logic here
                Repository.DeleteProvider(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}