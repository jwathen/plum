using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Plum.Models;

namespace Plum.Web
{
    public class AppSession
    {
        private readonly HttpContextBase _httpContext;

        public AppSession(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public string BusinessName
        {
            get
            {
                string businessName = (string)_httpContext.Session["BusinessName"];
                if (businessName == null && _httpContext.Request.IsAuthenticated)
                {
                    RegenerateSession();
                }
                return (string)_httpContext.Session["BusinessName"];
            }
            set
            {
                _httpContext.Session["BusinessName"] = value;
            }
        }

        public int? BusinessId
        {
            get
            {
                if (_httpContext.Request.IsAuthenticated)
                {
                    return int.Parse(_httpContext.User.Identity.Name);
                }
                else
                {
                    return null;
                }
            }
        }

        public void SignIn(Business business, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(business.Id.ToString(), rememberMe);
            RegenerateSession(business);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            _httpContext.Session.Clear();
        }

        private void RegenerateSession(Business business = null)
        {
            if (business == null)
            {
                using (var db = new ApplicationDataContext())
                {
                    business = db.Businesses.Find(BusinessId.Value);
                }
            }

            BusinessName = business.Name;
        }
    }
}