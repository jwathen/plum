using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WaitlistApp.ViewModels.Business;

namespace WaitlistApp.Controllers
{
    public partial class BusinessController : AppControllerBase
    {
        protected async Task<Models.Business> Business()
        {
            return await Entity<Models.Business>(
                business => business.Include(x => x.Queues),
                business => Security.UserOwns(business));
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
        [HttpGet, Route("business/{id:int}/business-information")]
        public virtual async Task<ActionResult> ShowBusinessInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new BusinessInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/edit-business-information")]
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
        [HttpPut, Route("business/{id:int}/business-information")]
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
            AppSession.BusinessName = business.Name;
            SuccessMessage("Your business information has been updated.");

            return RedirectToAction(MVC.Business.ShowBusinessInformation(model.Id));
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/sign-in-information")]
        public virtual async Task<ActionResult> ShowSignInInformation(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new SignInInformationViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/edit-sign-in-information")]
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
        [HttpPut, Route("business/{id:int}/sign-In-information")]
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

        [Authorize]
        [HttpGet, Route("business/{id:int}/text-messages")]
        public virtual async Task<ActionResult> ShowTextMessages(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new TextMessagesViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [HttpGet, Route("business/{id:int}/edit-text-messages")]
        public virtual async Task<ActionResult> EditTextMessages(int id)
        {
            var business = await Business();
            if (_result != null) return _result;

            var model = new TextMessagesViewModel();
            model.CopyFrom(business);

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPut, Route("business/{id:int}/text-messages")]
        public virtual async Task<ActionResult> UpdateTextMessages(TextMessagesViewModel model)
        {
            var business = await Business();
            if (_result != null) return _result;

            if (!ModelState.IsValid)
            {
                model.Business = business;
                return View(MVC.Business.Views.EditTextMessages, model);
            }

            model.CopyTo(business);
            await Database.SaveChangesAsync();
            AppSession.BusinessName = business.Name;
            SuccessMessage("Your text message templates have been updated.");

            return RedirectToAction(MVC.Business.ShowTextMessages(model.Id));
        }
    }
}