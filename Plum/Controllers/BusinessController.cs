using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using System.Data.Entity;

namespace Plum.Controllers
{
    public partial class BusinessController : AppControllerBase
    {
        protected async Task<Models.Business> Business()
        {
            var routeValues = ControllerContext.RouteData.Values;
            if (routeValues["id"] != null)
            {
                int id = Convert.ToInt32(routeValues["id"]);
                var business = await Database.Businesses
                    .Include(x => x.Queues)
                    .FirstOrDefaultAsync(x => x.Id == id);
                return business;
            }

            return null;
        }

        [Authorize]
        [GET("/business/{id:int}")]
        public virtual async Task<ActionResult> Show(int id)
        {
            var business = await Business();

            if (business == null)
            {
                return HttpNotFound();
            }
            else if (!Security.UserOwns(business))
            {
                return NotAuthorized();
            }

            return View(business);
        }
    }
}