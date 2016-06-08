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
        public virtual ActionResult Index() => View();

        [HttpGet, Route("page_not_found")]
        public virtual ActionResult NotFound() => View();

        [HttpGet, Route("error")]
        public virtual ActionResult Error() => View();

        [HttpGet, Route("not_authorized")]
        public virtual ActionResult NotAuthorized() => View();

        [HttpGet, Route("removed_from_list")]
        public virtual ActionResult RemovedFromList() => View();
    }
}