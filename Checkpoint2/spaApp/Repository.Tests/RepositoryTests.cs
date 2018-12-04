using Moq;
using spaApp.Data;
using spaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;
using spaApp.Services;

namespace AppointmentRepository.Tests
{
    public class RepositoryTests
    {
        private IReadOnlyspaAppContext CreateTestReadOnlyContext()
        {
            var testReadOnlyContext = new Mock<IReadOnlyspaAppContext>();
            var testAppts = new List<UsersAppointment>(){
                new UsersAppointment()
                {
                   Id = 1,
                   Create = new DateTime(2018, 12, 01, 11, 00, 00),
                   ProviderId = 1,
                   CustomerId = 1
                   
                }
             };
        
            testReadOnlyContext.Setup(x => x.UserAppointments).Returns(testAppts.AsQueryable());
            return testReadOnlyContext.Object;
        }

        //HELPER METHOD THAT INSTANTIATES THE SPAAPPCONTEXT
        private spaAppContext CreateSpaAppContext()
        {
            var testContext = new Mock<spaAppContext>(new DbContextOptionsBuilder<spaAppContext>().Options);
            testContext.Setup(c => c.Add(It.IsAny<UsersAppointment>())).Returns<EntityEntry<UsersAppointment>>(null);
            testContext.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(Task.FromResult(0));

            return testContext.Object;
        }
        [Fact]
        public void AddAppointmentMethod_ThrowsNoException()
        {
            // ARRANGE
            var newAppt = new UsersAppointment
            {
                Id = 1,
                Create = new DateTime(2018, 12, 1, 11, 00, 00),
                ProviderId = 2
            };
            var testRepo = new Repository(CreateSpaAppContext(), CreateTestReadOnlyContext());

            //ACT
            try
            {
                testRepo.Add(newAppt);
            }
            //ASSERT
            catch (Exception)
            {
                Assert.True(false, "Succeed");
            }
        }

        //TESTS THE ADDAPPOINTMENT() METHOD
        [Fact]
        public void AddAppointmentMethod_ThrowsExceptionWhenProviderIsNotAvailable()
        {
            // ARRANGE
            var newAppt = new UsersAppointment
            {
                Id = 2,
                Create = new DateTime(2018, 12, 1, 11, 00, 00),
                ProviderId = 1,
                CustomerId = 1
            };
            var testRepo = new Repository(CreateSpaAppContext(), CreateTestReadOnlyContext());

            //ACT & ASSERT
            Assert.Throws<System.Exception>(() => testRepo.Add(newAppt));
        }
    }
}
