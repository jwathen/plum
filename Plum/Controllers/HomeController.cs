using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace Plum.Controllers
{
    public partial class HomeController : Controller
    {
        [GET("")]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}