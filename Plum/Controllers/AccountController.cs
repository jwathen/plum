using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AttributeRouting.Web.Mvc;
using Plum.Models;
using Plum.ViewModels.Account;
using System.Data.Entity;

namespace Plum.Controllers
{
    public partial class AccountController : AppControllerBase
    {
        [GET("account/sign_up")]
        public virtual ActionResult SignUp()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [POST("account/sign_up")]
        public virtual async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var business = new Business();
            business.Name = model.BusinessName;
            business.Account = Account.Create(model.EmailAddress, model.Password);
            Database.Businesses.Add(business);
            await Database.SaveChangesAsync();

            AppSession.SignIn(business, false);

            return RedirectToAction(MVC.Home.Index());
        }

        [GET("account/sign_in")]
        public virtual ActionResult SignIn()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [POST("account/sign_in")]
        public virtual async Task<ActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var business = await Database.Businesses.FirstOrDefaultAsync(x => x.Account.EmailAddress == model.EmailAddress);
            bool success = business != null && business.Account.VerifyPassword(model.Password);

            if (success)
            {
                AppSession.SignIn(business, model.RememberMe);
                return RedirectToAction(MVC.Home.Index());
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email address or password is incorrect.");
                return View(model);
            }
        }

        [GET("account/sign_out")]
        public virtual ActionResult SignOut()
        {
            AppSession.SignOut();
            return RedirectToAction(MVC.Home.Index());
        }
    }
}