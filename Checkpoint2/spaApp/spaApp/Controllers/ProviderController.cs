using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spaApp.Models;
using spaApp.Services;

namespace spaApp.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProviderController> _logger;


        public ProviderController(IRepository repository, ILogger<ProviderController> logger)
        {
            _repository = repository;
            _logger = logger;

        }
        // GET: Provider
        public ActionResult Index()
        {
            return View(_repository.Providers);
        }

        // GET: Provider/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetProvider(id));
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
                _repository.Add(provider);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: Provider/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.GetProvider(id));
        }

        // POST: Provider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Provider provider)
        {
            try
            {
                // TODO: Add update logic here
                _repository.Update(id, provider);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetProvider(id));
        }

        // POST: Provider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Provider provider)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.DeleteProvider(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ErrorView(Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Unknown Error");
            _logger.LogError(ex, "Unknown Error");
            return View();
        }
    }
}