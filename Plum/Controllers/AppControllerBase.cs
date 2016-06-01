using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Plum.Models;
using Plum.Web;

namespace Plum.Controllers
{
    [RequireHttps]
    public abstract class AppControllerBase : Controller
    {
        private AppDataContext _db;
        private AppSession _appSession;
        private AppSecurity _appSecurity;

        public void InitializePublic(RequestContext requestContext)
        {
            // Expose to tests.
            Initialize(requestContext);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _db = new AppDataContext();
            _appSession = new AppSession(requestContext.HttpContext);
            _appSecurity = new AppSecurity(_appSession);
        }

        protected AppSession AppSession
        {
            get
            {
                return _appSession;
            }
        }

        protected AppSecurity Security
        {
            get
            {
                return _appSecurity;
            }
        }

        public AppDataContext Database
        {
            get
            {
                return _db;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}