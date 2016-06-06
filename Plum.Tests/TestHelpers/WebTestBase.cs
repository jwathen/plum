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
    public abstract class WebTestBase<TController> : TestBase where TController : AppControllerBase, new()
    {
        private RouteData _routeData = new RouteData();
        private MockHttpContext _httpContext = new MockHttpContext();
        protected readonly TController _controller;

        public WebTestBase() : base()
        {
            MvcApplication.IS_TEST = true;

            _controller = new TController();
            var requestContext = new RequestContext(HttpContext, RouteData);
            _controller.InitializePublic(requestContext);
            _controller.ControllerContext = new ControllerContext(HttpContext, RouteData, _controller);
            _controller.Url = new UrlHelper(requestContext);
            _controller.Database = Database;
            WebApplicationTestEnvironment.Setup<TController>();
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

        protected void SetRouteId(int id)
        {
            RouteValues.Add("id", id);
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
