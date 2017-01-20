using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plum.Controllers
{
    public partial class BrandController : AppControllerBase
    {
        [HttpGet]
        [Route("Brand/Stylesheet")]
        public virtual ActionResult Stylesheet()
        {
            
            string cssPath = Server.MapPath("~/Content/Styles/Site.css");
            string css = System.IO.File.ReadAllText(cssPath);
            css = css.Replace("#F25C05", Brand.BrandColor);
            css = css.Replace("#505050", Brand.JumboColor);
            css = css.Replace("'Raleway', sans-serif", Brand.FontName);
            return Content(css, "text/css");
        }
    }
}