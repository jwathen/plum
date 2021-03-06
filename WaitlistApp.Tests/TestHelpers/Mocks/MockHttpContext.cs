﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace WaitlistApp.Tests.TestHelpers.Mocks
{
    public class MockHttpContext : HttpContextBase
    {
        private MockHttpItemsCollection _items = new MockHttpItemsCollection();
        private MockHttpRequest _request = new MockHttpRequest();
        private MockHttpResponse _response = new MockHttpResponse();
        private MockHttpSessionState _session = new MockHttpSessionState();
        private IPrincipal _user = null;

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }

        public MockHttpRequest MockRequest
        {
            get
            {
                return _request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return _response;
            }
        }

        public MockHttpResponse MockResponse
        {
            get
            {
                return _response;
            }
        }

        public override HttpSessionStateBase Session
        {
            get
            {
                return _session;
            }
        }

        public MockHttpSessionState MockSession
        {
            get
            {
                return _session;
            }
        }

        public void SetSession(MockHttpSessionState session)
        {
            _session = session;
        }

        public override IDictionary Items
        {
            get
            {
                return _items;
            }
        }

        public override object GetService(Type serviceType)
        {
            return null;
        }

        public override HttpServerUtilityBase Server
        {
            get
            {
                return new MockHttpServerUtility();
            }
        }

        public override IPrincipal User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
    }
}
