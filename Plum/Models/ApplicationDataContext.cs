using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Plum.Models
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext() : base("Plum")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ComplexType<Account>().Property(x => x.EmailAddress).HasMaxLength(128).IsRequired();
            modelBuilder.ComplexType<Account>().Property(x => x.PasswordHash).IsRequired();
            modelBuilder.ComplexType<Account>().Property(x => x.PasswordSalt).IsRequired();

            modelBuilder.Entity<Business>().Property(x => x.Name).HasMaxLength(256).IsRequired();
        }

        public DbSet<Business> Businesses { get; set; }
    }
}