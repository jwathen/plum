using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WaitlistApp.Controllers;
using WaitlistApp.Models;
using WaitlistApp.Tests.TestHelpers.Mocks;
using WaitlistApp.Tests.TestHelpers.Mvc;
using WaitlistApp.Web;

namespace WaitlistApp.Tests.TestHelpers
{
    public abstract class TestBase : IDisposable
    {
        private AppDataContext _db;

        static TestBase()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.AppDataContext, Migrations.Configuration>());
        }

        public TestBase()
        {
            MvcApplication.IS_TEST = true;
            _db = new AppDataContext();
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var testBusiness = ReadFixture<Business>("TestBusiness");
            var otherBusiness = ReadFixture<Business>("OtherBusiness");
            
            string[] testEmailAddresses = new string[] { "new_business@site.com", "test_business@site.com", "other_business@site.com", "brandnewemail@site.com" };
            Database.Businesses.RemoveRange(Database.Businesses.Where(x => testEmailAddresses.Contains(x.Account.EmailAddress)));
            Database.SaveChanges();

            ResetIdentity("Businesses");
            ResetIdentity("Queues");
            ResetIdentity("Customers");
            ResetIdentity("CustomerLogEntries");

            Database.Businesses.Add(testBusiness);
            Database.Businesses.Add(otherBusiness);
            Database.SaveChanges();
        }

        private T ReadFixture<T>(string fileName)
        {
            using (var reader = new StreamReader(@"Fixtures\" + fileName + ".yml"))
            {
                var deserializer = new YamlDotNet.Serialization.Deserializer();
                return deserializer.Deserialize<T>(reader);
            }
        }

        private void ResetIdentity(string table)
        {
            string stmt = $@"declare @maxId int;
                            select @maxId = coalesce(max(Id), 0) + 1 from {table}
                            DBCC CHECKIDENT ('{table}', RESEED, @maxId);";
            Database.Database.ExecuteSqlCommand(stmt);
        }

        public Business TestBusiness
        {
            get
            {
                return Database.Businesses.First(x => x.Account.EmailAddress == "test_business@site.com");
            }
        }

        public Business OtherBusiness
        {
            get
            {
                return Database.Businesses.First(x => x.Account.EmailAddress == "other_business@site.com");
            }
        }

        public Business NewBusiness
        {
            get
            {
                return Database.Businesses.First(x => x.Account.EmailAddress == "new_business@site.com");
            }
        }

        protected AppDataContext Database
        {
            get
            {
                return _db;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
