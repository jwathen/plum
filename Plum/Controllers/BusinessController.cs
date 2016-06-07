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
        private ActionResult _result = null;

        protected async Task<Models.Business> Business()
        {
            var routeValues = ControllerContext.RouteData.Values;
            if (routeValues["id"] != null)
            {
                int id = Convert.ToInt32(routeValues["id"]);
                var business = await Database.Businesses
                    .Include(x => x.Queues)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (business == null)
                {
                    _result = HttpNotFound();
                }
                else if (!Security.UserOwns(business))
                {
                    _result = NotAuthorized();
                }

                return business;
            }

            return null;
        }

        [Authorize]
        [GET("/business/{id:int}")]
        public virtual async Task<ActionResult> Show(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new ShowViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [GET("/business/{id:int}/business_information")]
        public virtual async Task<ActionResult> ShowBusinessInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new BusinessInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [GET("/business/{id:int}/edit_business_information")]
        public virtual async Task<ActionResult> EditBusinessInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new BusinessInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [PUT("/business/{id:int}/business_information")]
        public virtual async Task<ActionResult> UpdateBusinessInformation(BusinessInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Business.Views.EditBusinessInformation, model);
            }

            var business = await Business();
            if (_result != null) return _result;

            model.CopyTo(business);
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Business.ShowBusinessInformation(model.Id));
        }
    }
}