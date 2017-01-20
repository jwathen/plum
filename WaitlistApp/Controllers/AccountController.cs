using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WaitlistApp.Models;
using WaitlistApp.ViewModels.Account;
using System.Data.Entity;
using WaitlistApp.ViewModels.Shared;

namespace WaitlistApp.Controllers
{
    public partial class AccountController : AppControllerBase
    {
        [HttpGet, Route("account/sign-up")]
        public virtual ActionResult SignUp()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction(MVC.Queue.Show());
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("account/sign-up")]
        public virtual async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var business = new Business();
            business.Name = model.BusinessName;
            business.Account = Account.Create(model.EmailAddress, model.Password);
            business.TextMessageLimit = 1000;
            var queue = new Queue { Name = "Default" };
            business.Queues.Add(queue);
            Database.Businesses.Add(business);

            await Database.SaveChangesAsync();

            AppSession.SignIn(business, false);

            return RedirectToAction(MVC.Queue.Show(queue.Id));
        }

        [HttpGet, Route("account/sign-in")]
        public virtual ActionResult SignIn()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("account/sign-in")]
        public virtual async Task<ActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var business = await Database.Businesses
                .FirstOrDefaultAsync(x => x.Account.EmailAddress == model.EmailAddress);
            bool success = business != null && business.Account.VerifyPassword(model.Password);

            if (success)
            {
                AppSession.SignIn(business, model.RememberMe);
                int queueId = business.Queues.First().Id;
                Log.Info($"Business {business.Id} signed in.");

                if (!string.IsNullOrWhiteSpace(Request.QueryString["ReturnUrl"]))
                {
                    return Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    return RedirectToAction(MVC.Queue.Show(queueId));
                }
            }
            else
            {
                Log.Warn($"Sign in failed for {model.EmailAddress}");
                ModelState.AddModelError(string.Empty, "Email address or password is incorrect.");
                return View(model);
            }
        }

        [HttpGet, Route("account/sign-out")]
        public virtual ActionResult SignOut()
        {
            AppSession.SignOut();
            SuccessMessage("You have been signed out.");
            return RedirectToAction(MVC.Account.SignIn());
        }
    }
}