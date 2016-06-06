using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Plum.Controllers;
using Plum.Models;
using Plum.Tests.TestHelpers.Mocks;
using Plum.Tests.TestHelpers.Mvc;
using Plum.Web;

namespace Plum.Tests.TestHelpers
{
    public abstract class TestBase : IDisposable
    {
        private AppDataContext _db;

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

            string[] testEmailAddresses = new string[] { "new_business@site.com", "test_business@site.com", "other_business@site.com" };
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
