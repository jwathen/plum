using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WaitlistApp.Controllers
{
    public partial class BrandController : AppControllerBase
    {
        [HttpGet]
        [Route("Brand/Stylesheet")]
        public virtual ActionResult Stylesheet()
        {
            string primaryColor = "#f25c05";
            string primaryColorL6 = "#d45104";
            string primaryColorL10 = "#c04904";
            string primaryColorL11 = "#b64504";
            string primaryColorL15 = "#a74003";
            string secondaryColor = "#f25c06";

            string cssPath = Server.MapPath("~/Content/Styles/Site.css");
            string css = System.IO.File.ReadAllText(cssPath);
            css = css.Replace(primaryColor, Brand.BrandColor);
            css = css.Replace(primaryColorL6, ChangeColorBrightness(Brand.BrandColor, -0.06f));
            css = css.Replace(primaryColorL10, ChangeColorBrightness(Brand.BrandColor, -0.10f));
            css = css.Replace(primaryColorL11, ChangeColorBrightness(Brand.BrandColor, -0.11f));
            css = css.Replace(primaryColorL15, ChangeColorBrightness(Brand.BrandColor, -0.15f));
            css = css.Replace(secondaryColor, Brand.SecondaryColor);
            css = css.Replace("#505050", Brand.JumboColor);
            css = css.Replace("'Raleway', sans-serif", Brand.FontName);
            return Content(css, "text/css");
        }

        public static string ChangeColorBrightness(string hex, float correctionFactor)
        {
            Color color = ColorTranslator.FromHtml(hex);
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            string reuslt = ColorTranslator.ToHtml(Color.FromArgb(color.A, (int)red, (int)green, (int)blue));
            return reuslt;
        }
    }
}