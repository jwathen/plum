using System;
using System.Collections.Generic;
using System.Linq;
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
            _controller.ControllerContext = new ControllerContext(HttpContext, RouteData, _controller);
            _controller.Url = new UrlHelper(new RequestContext(HttpContext, RouteData));
            WebApplicationTestEnvironment.Setup<TController>();

            // Seed
            Database.Businesses.RemoveRange(Database.Businesses.Where(x => x.Account.EmailAddress == "test_business@site.com"));
            Database.SaveChanges();

            var testBusiness = new Business();
            testBusiness.Name = "Test Business";
            testBusiness.Account = Account.Create("test_business@site.com", "passw0rd");
            Database.Businesses.Add(testBusiness);
            Database.SaveChanges();
        }

        public Business TestBusiness
        {
            get
            {
                return Database.Businesses.First(x => x.Account.EmailAddress == "test_business@site.com");
            }
        }

        protected ApplicationDataContext Database
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
