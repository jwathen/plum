using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plum.Models;

namespace Plum.Controllers
{
    [RequireHttps]
    public abstract class PlumControllerBase : Controller
    {
        protected PlumDataContext _db = new PlumDataContext();

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}