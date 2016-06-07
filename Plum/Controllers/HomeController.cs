using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plum.Controllers
{
    public partial class HomeController : AppControllerBase
    {
        [HttpGet, Route("")]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("page_not_found")]
        public virtual ActionResult NotFound()
        {
            return View();
        }

        [HttpGet, Route("error")]
        public virtual ActionResult Error()
        {
            return View();
        }

        [HttpGet, Route("not_authorized")]
        public virtual ActionResult NotAuthorized()
        {
            return View();
        }
    }
}