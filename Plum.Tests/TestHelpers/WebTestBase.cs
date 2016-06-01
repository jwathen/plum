﻿using System;
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
    public abstract class WebTestBase<TController> where TController : AppControllerBase, new()
    {
        private RouteData _routeData = new RouteData();
        private MockHttpContext _httpContext = new MockHttpContext();
        protected readonly TController _controller;

        public WebTestBase()
        {
            MvcApplication.IS_TEST = true;

            _controller = new TController();
            var requestContext = new RequestContext(HttpContext, RouteData);
            _controller.InitializePublic(requestContext);
            _controller.ControllerContext = new ControllerContext(HttpContext, RouteData, _controller);
            _controller.Url = new UrlHelper(requestContext);
            WebApplicationTestEnvironment.Setup<TController>();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var testBusiness = ReadFixture<Business>("TestBusiness");
            var otherBusiness = ReadFixture<Business>("OtherBusiness");

            Database.Businesses.RemoveRange(Database.Businesses.Where(x => x.Account.EmailAddress == testBusiness.Account.EmailAddress));
            Database.Businesses.RemoveRange(Database.Businesses.Where(x => x.Account.EmailAddress == otherBusiness.Account.EmailAddress));
            Database.SaveChanges();

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

        protected void SignInAs(Business business)
        {
            Request.SetIsAuthenticated(true);
            HttpContext.User = new GenericPrincipal(new GenericIdentity(business.Id.ToString()), new string[] { });
        }

        protected void SignIn()
        {
            SignInAs(TestBusiness);
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

        protected AppDataContext Database
        {
            get
            {
                return _controller.Database;
            }
        }

        protected MockHttpContext HttpContext
        {
            get
            {
                return _httpContext;
            }
        }

        protected MockHttpRequest Request
        {
            get
            {
                return _httpContext.MockRequest;
            }
        }

        protected MockHttpResponse Response
        {
            get
            {
                return _httpContext.MockResponse;
            }
        }

        protected MockHttpSessionState Session
        {
            get
            {
                return _httpContext.MockSession;
            }
        }

        protected AppSession AppSession
        {
            get
            {
                return new AppSession(_httpContext);
            }
        }

        protected RouteData RouteData
        {
            get
            {
                return _routeData;
            }
        }

        protected RouteValueDictionary RouteValues
        {
            get
            {
                return _routeData.Values;
            }
        }

        protected TempDataDictionary TempData
        {
            get
            {
                return _controller.TempData;
            }
        }
    }
}