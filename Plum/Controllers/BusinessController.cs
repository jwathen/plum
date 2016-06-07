using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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

            _result = HttpNotFound();
            return null;
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}")]
        public virtual async Task<ActionResult> Show(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new ShowViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/business_information")]
        public virtual async Task<ActionResult> ShowBusinessInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new BusinessInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/edit_business_information")]
        public virtual async Task<ActionResult> EditBusinessInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new BusinessInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPut, Route("business/{id:int}/business_information")]
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
            SuccessMessage("Your business information has been updated.");

            return RedirectToAction(MVC.Business.ShowBusinessInformation(model.Id));
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/sign_in_information")]
        public virtual async Task<ActionResult> ShowSignInInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new SignInInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/edit_sign_in_information")]
        public virtual async Task<ActionResult> EditSignInInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new SignInInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPut, Route("business/{id:int}/sign_In_information")]
        public virtual async Task<ActionResult> UpdateSignInInformation(SignInInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(MVC.Business.Views.EditSignInInformation, model);
            }

            var business = await Business();
            if (_result != null) return _result;

            bool anyChanges = model.EmailAddress.Trim() != business.Account.EmailAddress.Trim()
                || !string.IsNullOrWhiteSpace(model.NewPassword);
            if (anyChanges)
            {
                if (!business.Account.VerifyPassword(model.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "Current password is incorrect.");
                    return View(MVC.Business.Views.EditSignInInformation, model);
                }
                else
                {
                    string password = model.CurrentPassword;
                    if (!string.IsNullOrWhiteSpace(model.NewPassword))
                    {
                        password = model.NewPassword;
                    }
                    business.Account = Models.Account.Create(model.EmailAddress, password);
                    await Database.SaveChangesAsync();
                    SuccessMessage("Your sign in information has been updated.");
                }
            }

            return RedirectToAction(MVC.Business.ShowSignInInformation(model.Id));
        }
    }
}