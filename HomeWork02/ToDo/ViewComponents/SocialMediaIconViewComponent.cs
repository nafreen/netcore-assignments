using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.ViewComponents
{
    public class SocialMediaIconViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();

        }
        
    }
}
