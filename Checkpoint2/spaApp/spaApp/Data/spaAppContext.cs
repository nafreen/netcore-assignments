using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using spaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spaApp.Data
{
    public class spaAppContext : DbContext, IReadOnlyspaAppContext
    {
        public spaAppContext( DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersAppointment>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<UsersAppointment>().Property(x => x.Id).UseSqlServerIdentityColumn();

            modelBuilder.Entity<UsersAppointment>().HasOne(x => x.Customer).WithMany(x => x.UsersAppointments).HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<UsersAppointment>().HasIndex(x => x.CustomerId).HasName($"IX_{nameof(UsersAppointments)}_{nameof(UsersAppointment.Customer)}");

            modelBuilder.Entity<UsersAppointment>().HasOne(x => x.Provider).WithMany(x => x.UsersAppointments).HasForeignKey(x => x.ProviderId);
            modelBuilder.Entity<UsersAppointment>().HasIndex(x => x.ProviderId).HasName($"IX_{nameof(UsersAppointment)}_{nameof(UsersAppointment.Provider)}");

            modelBuilder.Entity<Customer>().HasMany(x => x.UsersAppointments).WithOne(x => x.Customer);
            modelBuilder.Entity<Provider>().HasMany(x => x.UsersAppointments).WithOne(x => x.Provider);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<UsersAppointment> UsersAppointments { get; set; }

        IQueryable<Customer> IReadOnlyspaAppContext.Customers { get => Customers.AsNoTracking(); }

        IQueryable<Provider> IReadOnlyspaAppContext.Providers { get => Providers.AsNoTracking(); }

        IQueryable<UsersAppointment> IReadOnlyspaAppContext.UserAppointments { get => UsersAppointments.AsNoTracking(); }
    }
}
