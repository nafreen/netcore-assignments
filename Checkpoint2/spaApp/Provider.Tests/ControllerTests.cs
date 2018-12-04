using Microsoft.AspNetCore.Mvc;
using spaApp.Controllers;
using spaApp.Models;
using spaApp.Services;
using System;
using Xunit;

namespace Appointment.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void UserAppointmentController()
        {
            //Assemble
            var controller = new UserAppointmentController();
            var userAppointment = new UsersAppointment
            {
                Id = 1,
                Create = DateTime.Now,
                Customer = new Customer { Id = 1, Name = "John Meyor", Email = "john@meyor.com", PhoneNumber = "4172583698" },
                Provider = new Provider { Id = 1, Name = "Mia Simpson", JobTitle = "Hair Stylist" }
            };

            // Act
            var result = controller.Create(userAppointment);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);

        }
        
        [Fact]
        public void ProviderController()
        { 
            // Arrange
            ProviderController controller = new ProviderController();

            // Act
            ViewResult result = controller.Create() as ViewResult;
            
            // Assert
            Assert.NotNull(result);
        }


            [Fact]
            public void CustomerIndex()
            {
                
                // Arrange
                CustomerController controller = new CustomerController();

                // Act
                ViewResult result = controller.Index() as ViewResult;

                // Assert
                Assert.IsType<ViewResult>(result);
            }

        }
    }

