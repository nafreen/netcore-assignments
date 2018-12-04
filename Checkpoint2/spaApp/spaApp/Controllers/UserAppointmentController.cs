using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using spaApp.Models;
using spaApp.Services;

namespace spaApp.Controllers
{
    public class UserAppointmentController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<UserAppointmentController> _logger;


        public UserAppointmentController(IRepository repository, ILogger<UserAppointmentController> logger)
        {
            _repository = repository;
            _logger = logger;


        }
        // GET: UserAppointment
        public ActionResult Index()
        {
            return View(_repository.UsersAppointments
                                   .Include(x => x.Customer)
                                   .Include(x => x.Provider));
        }

        // GET: UserAppointment/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetUsersAppointment(id));
        }

        // GET: UserAppointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAppointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersAppointment userAppointment)
        {
            
                try
                {
                    // TODO: Add insert logic here
                    _repository.Add(userAppointment);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View();
                
               
                }    
            
        }
        
        // GET: UserAppointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.GetUsersAppointment(id));
        }

        // POST: UserAppointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsersAppointment usersAppointment)
        {
            try
            {
                // TODO: Add update logic here
                _repository.Update(id,usersAppointment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        // GET: UserAppointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetUsersAppointment(id));
        }

        // POST: UserAppointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsersAppointment usersAppointment)
        {
            try
            {
                // TODO: Add delete logic here
                _repository.DeleteUsersAppointment(id);
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