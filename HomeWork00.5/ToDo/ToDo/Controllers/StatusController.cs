using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class StatusController : Controller
    {
        private static List<Status> list = new List<Status>
        {
            new Status { Id = 1, Value = "Not Started" },
            new Status { Id = 2, Value = "In Progress" },
            new Status { Id = 3, Value = "Done" } 
        };

        public IActionResult Index()
        {
            return View(list);
        }
    }
}