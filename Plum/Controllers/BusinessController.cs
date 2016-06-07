using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using System.Data.Entity;
using Plum.ViewModels.Business;

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

        [Authorize]
        [GET("/business/{id:int}/edit")]
        public virtual async Task<ActionResult> Edit(int id)
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

            var model = new BusinessViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [PUT("/business/{id:int}")]
        public virtual async Task<ActionResult> Update(BusinessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var business = await Business();

            if (business == null)
            {
                return HttpNotFound();
            }
            else if (!Security.UserOwns(business))
            {
                return NotAuthorized();
            }

            model.CopyTo(business);
            await Database.SaveChangesAsync();
            SuccessMessage("Business information updated.");

            return RedirectToAction(MVC.Business.Show(business.Id));
        }
    }
}