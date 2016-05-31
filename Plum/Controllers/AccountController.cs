using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using Plum.Models;
using Plum.ViewModels.Account;

namespace Plum.Controllers
{
    public partial class AccountController : PlumControllerBase
    {
        [GET("account/signup")]
        public virtual ActionResult SignUp()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [POST("account/signup")]
        public virtual async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var business = new Business();
            business.Name = model.BusinessName;
            business.Account = Account.Create(model.EmailAddress, model.Password);
            _db.Businesses.Add(business);
            await _db.SaveChangesAsync();

            return RedirectToAction(MVC.Home.Index());
        }
    }
}