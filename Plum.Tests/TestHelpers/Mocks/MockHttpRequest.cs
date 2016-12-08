using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Plum.Tests.TestHelpers.Mocks
{
    public class MockHttpRequest : HttpRequestBase
    {
        private const string IE11_USER_AGENT = "Mozilla / 5.0(Windows NT 6.3; WOW64; Trident / 7.0; Touch; rv: 11.0) like Gecko";
        private static HttpBrowserCapabilities _ie11BrowserCapabilities = GetHttpBrowserCapabilities(new NameValueCollection(), IE11_USER_AGENT);

        private HttpCookieCollection _cookies = new HttpCookieCollection();
        private Uri _url;
        private Uri _urlReferrer;
        private string _userAgent = IE11_USER_AGENT;
        private HttpBrowserCapabilities _browser = _ie11BrowserCapabilities;
        private NameValueCollection _headers = new NameValueCollection();
        private NameValueCollection _serverVariables = new NameValueCollection();
        private NameValueCollection _form = new NameValueCollection();
        private NameValueCollection _queryString = new NameValueCollection();
        private string _httpMethod = "GET";
        private string _userHostAddress;
        private bool _isAuthenticated;

        public override Uri Url
        {
            get
            {
                if (_url == null)
                {
                    SetUrl("/");
                }
                return _url;
            }
        }

        public override Uri UrlReferrer
        {
            get
            {
                if (_urlReferrer == null)
                {
                    SetUrl("/");
                }
                return _urlReferrer;
            }
        }

        public override bool IsSecureConnection
        {
            get
            {
                return _url.Scheme == "https";
            }
        }

        public override string RawUrl
        {
            get
            {
                if (_url == null)
                {
                    SetUrl("/");
                }
                return _url.PathAndQuery;
            }
        }

        public void SetAbsoluteUrl(string url)
        {
            _url = new Uri(url);
        }

        public void SetUrl(string url)
        {
            if (url.StartsWith("http"))
            {
                _url = new Uri(url);
            }
            else
            {
                if (!url.StartsWith("/"))
                {
                    url = "/" + url;
                }
                url = "https://plumlist.com" + url;
                _url = new Uri(url);
            }

            if (!string.IsNullOrWhiteSpace(_url.Query))
            {
                _queryString = HttpUtility.ParseQueryString(_url.Query);
            }
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return _cookies;
            }
        }

        public override string UserAgent
        {
            get
            {
                return _userAgent;
            }
        }

        public void SetUserAgent(string userAgent)
        {
            _userAgent = userAgent;
        }

        public override HttpBrowserCapabilitiesBase Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new InvalidOperationException("MockHttpRequset.SetUserAgent must be called before accessing the Browser property.");
                }
                return new HttpBrowserCapabilitiesWrapper(_browser);
            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return _headers;
            }
        }

        public override NameValueCollection ServerVariables
        {
            get
            {
                return _serverVariables;
            }
        }
        public override NameValueCollection Form
        {
            get
            {
                return _form;
            }
        }

        private static HttpBrowserCapabilities GetHttpBrowserCapabilities(NameValueCollection headers, string userAgent)
        {
            var factory = new BrowserCapabilitiesFactory();
            var browserCaps = new HttpBrowserCapabilities();
            var hashtable = new Hashtable(180, StringComparer.OrdinalIgnoreCase);
            hashtable[string.Empty] = userAgent;
            browserCaps.Capabilities = hashtable;
            factory.ConfigureBrowserCapabilities(headers, browserCaps);
            factory.ConfigureCustomCapabilities(headers, browserCaps);
            return browserCaps;
        }

        public override bool IsLocal
        {
            get
            {
                return false;
            }
        }

        public override string ApplicationPath
        {
            get
            {
                return "/";
            }
        }

        public override NameValueCollection QueryString
        {
            get
            {
                return _queryString;
            }
        }

        public override string HttpMethod
        {
            get
            {
                return _httpMethod;
            }
        }

        public override bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
        }

        public void SetIsAuthenticated(bool isAuthenticated)
        {
            _isAuthenticated = isAuthenticated;
        }

        public override string UserHostAddress
        {
            get
            {
                return _userHostAddress;
            }
        }

        public void SetHttpMethod(string httpMethod)
        {
            _httpMethod = httpMethod;
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return "~/";
            }
        }

        public override string PathInfo
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
