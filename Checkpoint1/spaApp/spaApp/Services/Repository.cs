using spaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace spaApp.Services
{
    public class Repository
    {

        private static int customerKeyCounter = 3;
        private static int providerKeyCounter = 3;
        private static int userKeyCounter = 2;

        
        private static List<Customer> _customer = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Meyor", Email="john@meyor.com", PhoneNumber="4172583698" },
            new Customer { Id = 2, Name = "Tyler Perry", Email="tyler@perry.com", PhoneNumber="8174556398"},
            new Customer { Id = 3, Name = "Taylor Swift", Email="Taylor@swift.com", PhoneNumber="1725189845" }
        };

        private static List<Provider> _provider = new List<Provider>
        {
            new Provider { Id = 1, Name = "Mia Simpson", JobTitle = "Hair Stylist"},
            new Provider { Id = 2, Name = "Jake Henry", JobTitle = "Message Therapist"},
            new Provider { Id = 3, Name = "Terry Hudson", JobTitle = "Message Therapist"}
        };

        private static List<UsersAppointment> _usersAppointment = new List<UsersAppointment>
        {

            new UsersAppointment { Id = 1, Create = DateTime.Now, customer = _customer[1], provider = _provider[1]},
            new UsersAppointment { Id = 2, Create = DateTime.Now.AddMinutes(45), customer = _customer[2], provider = _provider[2] }
            
        };

        public static IReadOnlyList<Customer> customers => _customer;
        public static IReadOnlyList<Provider> providers => _provider;
        public static IReadOnlyList<UsersAppointment> usersAppointments => _usersAppointment;

        public static void Add(UsersAppointment usersAppointment)
        {
            usersAppointment.Id = Interlocked.Increment(ref userKeyCounter);
            usersAppointment.customer = _customer.Find(x => x.Id == usersAppointment.customer?.Id);
            usersAppointment.provider = _provider.Find(x => x.Id == usersAppointment.provider?.Id);

            //Checking for User should be able to book any customer with any service provider, as long 
            //as there is not already a appointment at that time.

            foreach (var x in _usersAppointment)
            {
                if (x.customer.Id.Equals(usersAppointment.customer.Id) && x.Create.Equals(usersAppointment.Create))
                {
                    throw new ArgumentException("Sorry the appointment time is not available.");
                    
                }

                if (x.provider.Id.Equals(usersAppointment.provider.Id) && x.Create.Equals(usersAppointment.Create))
                {

                    throw new ArgumentException("Sorry the Provider is not available.");
                }
            }


            _usersAppointment.Add(usersAppointment);
            
          
        }


        public static void Update(int id, UsersAppointment usersAppointment)
        {
            var index = _usersAppointment.FindIndex(x => x.Id == id);
            _usersAppointment.RemoveAt(index);
            usersAppointment.Id = id;
            usersAppointment.customer = _customer.Find(x => x.Id == usersAppointment.customer?.Id);
            usersAppointment.provider = _provider.Find(x => x.Id == usersAppointment.provider?.Id);

            _usersAppointment.Insert(index, usersAppointment);
        }

        public static void DeleteUsersAppointment(int id)
        {
            var index = _usersAppointment.FindIndex(x => x.Id == id);
            _usersAppointment.RemoveAt(index);
        }

        public static UsersAppointment GetUsersAppointment(int id)
        {
            return _usersAppointment.Find(x => x.Id == id);
        }


        public static void Add(Customer customer)
        {
            customer.Id = Interlocked.Increment(ref customerKeyCounter);
            _customer.Add(customer);
        }

        public static void Update(int id, Customer customer)
        {
            var index = _customer.FindIndex(x => x.Id == id);
            _customer.RemoveAt(index);
            customer.Id = id;
            _customer.Insert(index, customer);
        }

        public static void DeleteCustomer(int id)
        {
            var index = _customer.FindIndex(x => x.Id == id);
            _customer.RemoveAt(index);
        }

        public static Customer GetCustomer(int id)
        {
            return _customer.Find(x => x.Id == id);
        }

        public static void Add(Provider provider)
        {
            provider.Id = Interlocked.Increment(ref providerKeyCounter);
            _provider.Add(provider);
        }

        public static void Update(int id, Provider provider)
        {
            var index = _provider.FindIndex(x => x.Id == id);
            _provider.RemoveAt(index);
            provider.Id = id;
            _provider.Insert(index, provider);
        }

        public static void DeleteProvider(int id)
        {
            var index = _provider.FindIndex(x => x.Id == id);
            _provider.RemoveAt(index);
        }

        public static Provider GetProvider(int id)
        {
            return _provider.Find(x => x.Id == id);
        }

          
    }
}
