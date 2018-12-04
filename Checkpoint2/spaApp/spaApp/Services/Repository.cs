using Microsoft.EntityFrameworkCore;
using spaApp.Data;
using spaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace spaApp.Services
{
    public class Repository : IRepository
    {

        private readonly spaAppContext _spaAppContext;
        private readonly IReadOnlyspaAppContext _readOnlyspaAppContext;

        public Repository(spaAppContext spaAppContext, IReadOnlyspaAppContext readOnlyspaAppContext)
        {
           _spaAppContext = spaAppContext;
           _readOnlyspaAppContext = readOnlyspaAppContext;
        }

        public IQueryable<Customer> Customers => _readOnlyspaAppContext.Customers;
        public IQueryable<Provider> Providers => _readOnlyspaAppContext.Providers;
        public IQueryable<UsersAppointment> UsersAppointments => _readOnlyspaAppContext.UserAppointments;

        public void Add(UsersAppointment usersAppointment)
        {
            //Method to Check Conflict in Appointments
            checkAppointment(usersAppointment);
            _spaAppContext.UsersAppointments.Add(usersAppointment);
            _spaAppContext.SaveChanges();

            /*Using Transaction when there is More than one Contexts*/

            //using (var transaction = _spaAppContext.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        checkAppointment(usersAppointment);
            //        _spaAppContext.UsersAppointments.Add(usersAppointment);
            //        _spaAppContext.SaveChanges();
                    
            //        transaction.Commit();
            //    }
           
            //     catch (Exception ex)
            //    {
            //        throw new Exception("Transaction failed", ex);
            //    }
            //}
        }



        public void Update(int id, UsersAppointment usersAppointment)
        {
             usersAppointment.Id = id;

             checkAppointment(usersAppointment);

            _spaAppContext.UsersAppointments.Update( usersAppointment);
            _spaAppContext.SaveChanges();
        }

        public void DeleteUsersAppointment(int id)
        {
            var toBeDeleted = _spaAppContext.UsersAppointments.First(SelectUserAppointmentById(id));
            _spaAppContext.UsersAppointments.Remove(toBeDeleted);
            _spaAppContext.SaveChanges();
            
        }

        public UsersAppointment GetUsersAppointment(int id)
        {
            return _readOnlyspaAppContext.UserAppointments
                .Include(x => x.Customer)
                .Include(x => x.Provider)
                .First(SelectUserAppointmentById(id));
            
        }


        public void Add(Customer customer)
        {

            _spaAppContext.Customers.Add(customer);
            _spaAppContext.SaveChanges();
            
        }

        public void Update(int id, Customer customer)
        {
            customer.Id = id;
           _spaAppContext.Customers.Update(customer);
            _spaAppContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var toBeDeleted = _spaAppContext.Customers.First(SelectCustomerById(id));
            _spaAppContext.Customers.Remove(toBeDeleted);
            _spaAppContext.SaveChanges();

        }

        public Customer GetCustomer(int id)
        {
            return _readOnlyspaAppContext.Customers.First(SelectCustomerById(id));
        }

        public void Add(Provider provider)
        {
            _spaAppContext.Providers.Add(provider);
            _spaAppContext.SaveChanges();
        }

        public void Update(int id, Provider provider)
        {
            provider.Id = id;
            _spaAppContext.Providers.Update(provider);
            _spaAppContext.SaveChanges();
        }

        public void DeleteProvider(int id)
        {
            var toBeDeleted = _spaAppContext.Providers.First(SelectProviderById(id));
            _spaAppContext.Providers.Remove(toBeDeleted);
            _spaAppContext.SaveChanges();
        }

        public Provider GetProvider(int id)
        {
            return _readOnlyspaAppContext.Providers.First(SelectProviderById(id));
        }

        public void  checkAppointment(UsersAppointment usersAppointment)
        {

            foreach (var x in _readOnlyspaAppContext.UserAppointments.Include(x => x.Customer).Include(x => x.Provider))
            {

                if (x.CustomerId.Equals(usersAppointment.CustomerId) && x.Create.Equals(usersAppointment.Create))
                {
                    throw new Exception("Customer has a conflicting appointment.");

                }

                if (x.ProviderId.Equals(usersAppointment.ProviderId) && x.Create.Equals(usersAppointment.Create))
                {

                    throw new ArgumentException("Provider has a conflicting appointment.");
                }
            }


        }

        #region Selector Functions
        private static Func<UsersAppointment, bool> SelectUserAppointmentById(int id)
        {
            return UsersAppointment => UsersAppointment.Id == id;
        }

        private static Func<Customer, bool> SelectCustomerById(int id)
        {
            return Customer => Customer.Id == id;
        }

        private static Func<Provider, bool> SelectProviderById(int id)
        {
            return Provider => Provider.Id == id;
        }

        public void Dispose()
        {
            _spaAppContext?.Dispose();
            (_readOnlyspaAppContext as IDisposable)?.Dispose();
        }
        #endregion



    }
}
