using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("Plum")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ComplexType<Account>().Property(x => x.EmailAddress).HasMaxLength(128).IsRequired();
            modelBuilder.ComplexType<Account>().Property(x => x.PasswordHash).IsRequired();
            modelBuilder.ComplexType<Account>().Property(x => x.PasswordSalt).IsRequired();

            modelBuilder.Entity<Business>().Property(x => x.Name).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Queue>().Property(x => x.Name).HasMaxLength(256);

            modelBuilder.Entity<Customer>().Property(x => x.Name).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.PhoneNumber).HasMaxLength(10);
            modelBuilder.Entity<Customer>().Property(x => x.UrlToken).HasMaxLength(12).IsRequired();
        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}