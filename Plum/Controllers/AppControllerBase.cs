using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plum.Models;
using Plum.Web;

namespace Plum.Controllers
{
    [RequireHttps]
    public abstract class AppControllerBase : Controller
    {
        private readonly ApplicationDataContext _db;

        public AppControllerBase()
        {
            _db = new ApplicationDataContext();            
        }

        protected AppSession AppSession
        {
            get
            {
                return new AppSession(HttpContext);
            }
        }

        public ApplicationDataContext Database
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