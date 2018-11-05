using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewComponents;
using Xunit;

namespace ToDoApp.Tests
{
    public class CardViewComponentTests
    {
        public class CardGroupViewComponentTests
        {
            [Fact]
            public void Component_ShouldGet4ToDoItemsWhichAreTheOldest()
            {
                // Assemble
                var fakeData = new List<ToDo>
            {
                new ToDo
                {
                    Title = "Oldest",
                    Created = new DateTime(1990, 10, 1)
                },
                new ToDo
                {
                    Title = "2nd Oldest",
                    Created = new DateTime(1990, 10, 2)
                },
                new ToDo
                {
                    Title = "3rd Oldest",
                    Created = new DateTime(1990, 10, 3)
                },
                new ToDo
                {
                    Title = "4th Oldest",
                    Created = new DateTime(1990, 10, 4)
                },
                new ToDo
                {
                    Title = "Youngest",
                    Created = new DateTime(2020, 10, 1)
                }
            };
                Mock<IRepository> mockRepository = new Mock<IRepository>();
                mockRepository.SetupGet(x => x.ToDos)
                    .Returns(fakeData);
                IRepository repository = mockRepository.Object;

                var component = new CardGroupViewComponent(repository);

                // Act
                var result = component.Invoke() as ViewViewComponentResult;

                // Assert
                var viewModel = result.ViewData.Model as IEnumerable<CardViewModel>;
                Assert.Contains(viewModel, x => x.Title == "Oldest");
                Assert.Contains(viewModel, x => x.Title == "2nd Oldest");
                Assert.Contains(viewModel, x => x.Title == "3rd Oldest");
                Assert.Contains(viewModel, x => x.Title == "4th Oldest");
                Assert.Equal(4, viewModel.Count());
            }
        }
    }
}