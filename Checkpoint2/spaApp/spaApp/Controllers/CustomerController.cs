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
    public class CustomerController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(IRepository repository, ILogger<CustomerController> logger)
        {
            _repository = repository;
            _logger = logger;


        }

        public ActionResult Index()
        {
            return View(_repository.Customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetCustomer(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                _repository.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.GetCustomer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                _repository.Update(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetCustomer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.DeleteCustomer(id);
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