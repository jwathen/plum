using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Plum.Models;
using Plum.Services;
using Plum.ViewModels.Shared;
using Plum.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Plum.Models.Annotations;

namespace Plum.Controllers
{
    [RequireHttps]
    public abstract class AppControllerBase : Controller
    {
        protected ActionResult _result = null;
        private AppDataContext _db;
        private AppSession _appSession;
        private AppSecurity _appSecurity;
        private AppSecrets _appSecrets;
        private TextMessageService _textMessageService;
        private EmailService _emailService;

        public void InitializePublic(RequestContext requestContext)
        {
            // Expose to tests.
            Initialize(requestContext);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _db = new AppDataContext();
            _appSession = new AppSession(requestContext.HttpContext);

            string secretsFilePath = Server.MapPath("~/App_Data/Secrets.json");
            _appSecrets = new AppSecrets(secretsFilePath);
            _appSecurity = new AppSecurity(_appSession);
            _textMessageService = new TextMessageService(_appSecrets);
            _emailService = new EmailService(_appSecrets);
        }

        protected AppSession AppSession
        {
            get
            {
                return _appSession;
            }
        }

        protected AppSecurity Security
        {
            get
            {
                return _appSecurity;
            }
        }

        public AppDataContext Database
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public AppSecrets Secrets
        {
            get
            {
                return _appSecrets;
            }
        }

        public TextMessageService TextMessaging
        {
            get
            {
                return _textMessageService;
            }
        }

        public EmailService Email
        {
            get
            {
                return _emailService;
            }
        }

        protected RedirectToRouteResult NotAuthorized()
        {
            return RedirectToAction(MVC.Home.ActionNames.NotAuthorized, MVC.Home.Name);
        }

        protected ContentResult JavaScriptRedirect(string url)
        {
            return new ContentResult
            {
                Content = $"<script>window.location.href = '{url}';</script>",
                ContentType = "text/html"
            };
        }

        protected async Task<T> Entity<T>(Func<IDbSet<T>, IQueryable<T>> query, Func<T, bool> auth) where T : class, IIntegerIdEntity
        {
            var routeValues = ControllerContext.RouteData.Values;
            if (routeValues["id"] != null)
            {
                int id = Convert.ToInt32(routeValues["id"]);
                T entity = await query(Database.Set<T>()).FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                {
                    _result = HttpNotFound();
                }
                else if (!auth(entity))
                {
                    _result = NotAuthorized();
                }

                return entity;
            }

            _result = HttpNotFound();
            return null;
        }

        protected void SetFlash(FlashMessage.AlertType alertType, string text, string minorText = null)
        {
            TempData["FlashMessage"] = new FlashMessage
            {
                Type = alertType,
                Text = text,
                MinorText = minorText
            };
        }

        protected void SuccessMessage(string text, string minorText = null)
        {
            SetFlash(FlashMessage.AlertType.Success, text, minorText);
        }

        protected void ErrorMessage(string text, string minorText = null)
        {
            SetFlash(FlashMessage.AlertType.Danger, text, minorText);
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}