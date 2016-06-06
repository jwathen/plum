using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace Plum.Controllers
{
    public partial class BusinessController : AppControllerBase
    {
        [Authorize]
        [GET("/business/{id:int}")]
        public virtual async Task<ActionResult> Show(int id)
        {
            return View();
        }
    }
}