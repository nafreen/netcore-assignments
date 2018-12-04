using System.Collections.Generic;
using System.Linq;
using spaApp.Models;

namespace spaApp.Services
{
    public interface IRepository
    {
        IQueryable<Customer> Customers { get; }
        IQueryable<Provider> Providers { get; }
        IQueryable<UsersAppointment> UsersAppointments { get; }

        void Add(Customer customer);
        void Add(Provider provider);
        void Add(UsersAppointment usersAppointment);
        void checkAppointment(UsersAppointment usersAppointment);
        void DeleteCustomer(int id);
        void DeleteProvider(int id);
        void DeleteUsersAppointment(int id);
        Customer GetCustomer(int id);
        Provider GetProvider(int id);
        UsersAppointment GetUsersAppointment(int id);
        void Update(int id, Customer customer);
        void Update(int id, Provider provider);
        void Update(int id, UsersAppointment usersAppointment);
    }
}