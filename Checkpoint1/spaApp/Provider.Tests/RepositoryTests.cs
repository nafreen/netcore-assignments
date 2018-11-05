using spaApp.Models;
using spaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Appointment.Tests
{
    
    public class RepositoryTests
    {
        [Fact]
        public void UpdateMethod_Repository()
        {
            //ASSEMBLE
            var testAppointment = new UsersAppointment
            { Id = 1,
              Create = DateTime.Now,
              customer = new Customer { Id = 1, Name = "John Meyor", Email = "john@meyor.com", PhoneNumber = "4172583698" },
              provider = new Provider { Id = 1, Name = "Mia Simpson", JobTitle = "Hair Stylist" }
            };
            

            //ACT
            Repository.Update(1, testAppointment);
            var result = Repository.usersAppointments.FirstOrDefault(x => x.Id == testAppointment.Id);

            //ASSERT
            
            Assert.Equal(testAppointment.customer.Name, result.customer.Name);
            Assert.Equal(testAppointment.customer.Id, result.customer.Id);
            Assert.Equal(testAppointment.Create, result.Create);
            Assert.Equal(testAppointment.provider.Name, result.provider.Name);
            Assert.Equal(testAppointment.provider.Id, result.provider.Id);
            
        }

    }
}
