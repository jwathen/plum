using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plum.Controllers;
using Plum.Models;

namespace Plum.Web
{
    public abstract class ApplicationViewBase : WebViewPage
    {
        private AppSession _appSession;

        public override void InitHelpers()
        {
            base.InitHelpers();
            _appSession = new AppSession(ViewContext.HttpContext);
        } 
        protected AppSession AppSession
        {
            get
            {
                return _appSession;
            }
        }
    }

    public abstract class ApplicationViewBase<T> : WebViewPage<T>
    {
        private AppSession _appSession;

        public override void InitHelpers()
        {
            base.InitHelpers();
            _appSession = new AppSession(ViewContext.HttpContext);
        }
        protected AppSession AppSession
        {
            get
            {
                return _appSession;
            }
        }

        protected Manifest AppManifest
        {
            get
            {
                return ((AppControllerBase)ViewContext.Controller).AppManifest;
            }
        }

        protected Brand Brand
        {
            get
            {
                return ((AppControllerBase)ViewContext.Controller).Brand;
            }
        }
    }
}