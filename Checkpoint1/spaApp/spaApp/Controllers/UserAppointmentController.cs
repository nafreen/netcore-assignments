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
    public class UserAppointmentController : Controller
    {
        // GET: UserAppointment
        public ActionResult Index()
        {
            return View(Repository.usersAppointments);
        }

        // GET: UserAppointment/Details/5
        public ActionResult Details(int id)
        {
            return View(Repository.GetUsersAppointment(id));
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
                    Repository.Add(userAppointment);
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
            return View(Repository.GetUsersAppointment(id));
        }

        // POST: UserAppointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsersAppointment usersAppointment)
        {
            try
            {
                // TODO: Add update logic here
                Repository.Update(id,usersAppointment);
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
            return View(Repository.GetUsersAppointment(id));
        }

        // POST: UserAppointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsersAppointment usersAppointment)
        {
            try
            {
                // TODO: Add delete logic here
                Repository.DeleteUsersAppointment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}