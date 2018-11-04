using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lesson3HomeWork.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int? statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Error404");
                case 500:
                    return View("Error500");
                default:
                    return View();
            }
            
        }
    }
}