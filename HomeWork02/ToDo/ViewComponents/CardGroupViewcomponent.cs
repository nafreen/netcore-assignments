using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewComponents
{
    public class CardGroupViewComponent : ViewComponent
    {
        private readonly IRepository repository;

        public CardGroupViewComponent(IRepository repository)
        {
            this.repository = repository;
        }
        public IViewComponentResult Invoke()
        {
                       
            var oldestToDos = repository.ToDos.OrderBy(x => x.Created).Take(4).Select(todo => new CardViewModel
            {
                Title = todo.Title,

                Summary = todo.Description

            });
            return View(oldestToDos);
        }
    }
}
