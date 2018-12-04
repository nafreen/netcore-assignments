using spaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spaApp.Data
{
    public interface IReadOnlyspaAppContext
    {
        IQueryable<Customer> Customers { get; }
        IQueryable<Provider> Providers { get; }
        IQueryable<UsersAppointment> UserAppointments { get; }
    }
}
