using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Plum.ViewModels.Home;
using Plum.Web;

namespace Plum.Controllers
{
    public partial class HomeController : AppControllerBase
    {
        [HttpGet, Route("")]
        public virtual ActionResult Index() => View();

        [HttpGet, Route("about")]
        public virtual ActionResult About() => View();

        [HttpGet, Route("page-not-found")]
        public virtual ActionResult NotFound() => View();

        [HttpGet, Route("error")]
        public virtual ActionResult Error() => View();

        [HttpGet, Route("not-authorized")]
        public virtual ActionResult NotAuthorized() => View();

        [HttpGet, Route("removed-from-list")]
        public virtual ActionResult RemovedFromList() => View();

        [HttpGet, Route("privacy-policy")]
        public virtual ActionResult PrivacyPolicy() => View();

        [HttpGet, Route("terms-of-use")]
        public virtual ActionResult TermsOfUse() => View();

        [HttpGet, Route("manifest")]
        public virtual ActionResult Manifest()
        {
            string json = JsonConvert.SerializeObject(AppManifest, Formatting.Indented);
            return Content(json, "application/manifest+json");
        }

        [HttpGet, Route("contact")]
        public virtual async Task<ActionResult> ContactUs()
        {
            var model = new ContactUsViewModel();
            if (AppSession.BusinessId.HasValue)
            {
                var business = await Database.Businesses.FindAsync(AppSession.BusinessId.Value);
                if (business != null)
                {
                    model.EmailAddress = business.Account.EmailAddress;
                }
            }
            return View(model);
        }

        [HttpPost, Route("contact")]
        public virtual ActionResult ContactUs(ContactUsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                string subject = "Message from Contact Us Form";
                if (AppSession.BusinessId.HasValue)
                {
                    subject += " - " + AppSession.BusinessId;
                }
                Email.Send(model.EmailAddress, AppSettings.App.Email.ComapanyEmailAddress, subject, model.Message, false);

                SuccessMessage("Your message has been sent!", "We'll get back to you as soon as possible.");
                return RedirectToAction(MVC.Home.ContactUs());
            }
        }
    }
}