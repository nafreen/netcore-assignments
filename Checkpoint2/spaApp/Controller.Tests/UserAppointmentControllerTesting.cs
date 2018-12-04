using Microsoft.AspNetCore.Mvc;
using Moq;
using spaApp.Controllers;
using spaApp.Services;
using spaApp.Models;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Controller.Tests
{
    public class UserAppointmentControllerTesting
    { 
        private readonly Mock<ILogger<UserAppointmentController>> _mockLogger;
        private readonly Mock<ILogger<CustomerController>> _mockCustomerLogger;
        private readonly Mock<ILogger<ProviderController>> _mockProviderLogger;
        private readonly Mock<IRepository> _mockRepo;
        private readonly UserAppointmentController _userController;
        private readonly CustomerController _customerController;
        private readonly ProviderController _providerController;
        List<UsersAppointment> userAppointmentList;

        public UserAppointmentControllerTesting()
        {

            _mockRepo = new Mock<IRepository>();
            _mockLogger = new Mock<ILogger<UserAppointmentController>>();
            _mockCustomerLogger = new Mock<ILogger<CustomerController>>();
            _mockProviderLogger = new Mock<ILogger<ProviderController>>();
            _userController = new UserAppointmentController(_mockRepo.Object, _mockLogger.Object);
            _customerController = new CustomerController(_mockRepo.Object, _mockCustomerLogger.Object);
            _providerController = new ProviderController(_mockRepo.Object, _mockProviderLogger.Object);
            userAppointmentList = new List<UsersAppointment>(){
                new UsersAppointment()
                {
                    Id = 1,
                    Create = DateTime.Now,
                    Customer = new Customer { Id = 1, Name = "John Meyor", Email = "john@meyor.com", PhoneNumber = "4172583698" },
                    Provider = new Provider { Id = 1, Name = "Mia Simpson", JobTitle = "Hair Stylist" }

                }
             };

        }

        [Fact]
        public void UserAppointmentController_Create_Test()
        {

            var userAppointment = new UsersAppointment();

            // Arrange
            _mockRepo.Setup(c => c.Add(userAppointment));


            // Act
            var result = _userController.Create(userAppointment);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);

        }

        [Fact]
        public void UserAppointmentController_Create_Error_Test()
        {
            
            var userAppointment = new UsersAppointment()
            {
                Id = 1,
                Create = DateTime.Now,
                CustomerId = 1,
                ProviderId = 1

            };
            
            _mockRepo.Setup(c => c.Add(userAppointment)).Throws<Exception>(); 

            //Act
            var result = (ViewResult)_userController.Create(userAppointment);

            //Assert
            
            Assert.False(result.ViewData.ModelState.IsValid);

        }

        [Fact]
        public void UserAppointmentController_Edit_Test()
        {
            int Id = 1;
            var userAppointment = new UsersAppointment()
            {
                Id = 1,
                Create = DateTime.Now,
                CustomerId = 1,
                ProviderId = 1

            };
            _mockRepo.Setup(c => c.Update(Id, userAppointment));

            // Act
            var result = _userController.Edit(Id, userAppointment);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);


        }

        [Fact]
        public void UserAppointmentController_Edit_Error_Test()
        {
            
            int Id = 1;
            var userAppointment = new UsersAppointment()
            {
                Id = 1,
                Create = DateTime.Now,
                CustomerId = 1,
                ProviderId = 1
                
            };
            
            _mockRepo.Setup(c => c.Update(Id, userAppointment)).Throws<Exception>();

            //Act
            var result = (ViewResult)_userController.Edit(Id, userAppointment);

            //Assert
            
            Assert.False(result.ViewData.ModelState.IsValid);
            

        }

        [Fact]
        public void ProviderController_Details_Test()
        {
            int Id = 1;
            var provider = new Provider()
            {
                Id = 1,
                Name = "Mia Simpson",
                JobTitle = "Hair Stylist"

            };
            // Arrange
            
            _mockRepo.Setup(c => c.GetProvider(provider.Id)).Returns(provider);

            // Act
            var result = _providerController.Details(Id);

            // Assert
            var contentResult = Assert.IsType<ViewResult>(result);
            
            Assert.Null(contentResult.ViewName);
                      

        }

        [Fact]
        public void CustomerController_Delete_Test()
        {
            int Id = 1;
            var Customer = new Customer { Id = 1, Name = "John Meyor", Email = "john@meyor.com", PhoneNumber = "4172583698" };
            // Arrange

            _mockRepo.Setup(c => c.DeleteCustomer(Id));

            // Act
            var result = _customerController.Delete(Id, Customer);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);


        }

        [Fact]
        public void CustomerController_Delete_Fail_Test()
        {
            int Id = 1;
            var Customer = new Customer { Id = 1, Name = "John Meyor", Email = "john@meyor.com", PhoneNumber = "4172583698" };
            // Arrange

            _mockRepo.Setup(c => c.DeleteCustomer(Id)).Throws<Exception>(); ;

            // Act
            var result = _customerController.Delete(Id, Customer);

            // Assert
            var contentResult = Assert.IsType<ViewResult>(result);
            Assert.Null(contentResult.ViewName);
       
        }
    }
}

