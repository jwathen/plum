using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WaitlistApp.ViewModels.Brand;

namespace WaitlistApp.Controllers
{
    public partial class BrandController : AppControllerBase
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Result = new HttpNotFoundResult();
        }

        protected async Task<Models.Brand> GetBrand()
        {
            return await Entity<Models.Brand>(
                brand => brand,
                brand => true);
        }

        [HttpGet, Route("brands")]
        public virtual async Task<ActionResult> List()
        {
            var model = await Database.Brands.ToListAsync();
            return View(model);
        }

        [HttpGet, Route("brand/create")]
        public virtual ActionResult Create()
        {
            var model = new BrandViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("brand/create")]
        public virtual async Task<ActionResult> Create(BrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CleanUp();
            var brand = new Models.Brand
            {
                BrandColor = model.BrandColor,
                DomainNames = model.DomainNames,
                FontName = model.FontName,
                FontUrl = model.FontUrl,
                IsActive = false,
                JumboColor = model.JumboColor,
                JumboImageUrl = model.JumboImageUrl,
                Name = model.Name,
                SecondaryColor = model.SecondaryColor
            };
            Database.Brands.Add(brand);
            await Database.SaveChangesAsync();
            return RedirectToAction(MVC.Brand.List());
        }

        [HttpGet, Route("brand/{id}/edit")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            var brand = await GetBrand();
            var model = new BrandViewModel();
            model.BrandColor = brand.BrandColor;
            model.DomainNames = brand.DomainNames;
            model.FontName = brand.FontName;
            model.FontUrl = brand.FontUrl;
            model.IsActive = brand.IsActive;
            model.JumboColor = brand.JumboColor;
            model.JumboImageUrl = brand.JumboImageUrl;
            model.Name = brand.Name;
            model.SecondaryColor = brand.SecondaryColor;

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("brand/{id}/edit")]
        public virtual async Task<ActionResult> Edit(BrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CleanUp();
            var brand = await GetBrand();
            brand.BrandColor = model.BrandColor;
            brand.DomainNames = model.DomainNames;
            brand.FontName = model.FontName;
            brand.FontUrl = model.FontUrl;
            brand.JumboColor = model.JumboColor;
            brand.JumboImageUrl = model.JumboImageUrl;
            brand.Name = model.Name;
            brand.SecondaryColor = model.SecondaryColor;
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Brand.List());
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("brand/{id}/destroy")]
        public virtual async Task<ActionResult> Destroy(int id)
        {
            var brand = await GetBrand();
            if (brand != null)
            {
                Database.Brands.Remove(brand);
            }
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Brand.List());
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("brand/activate")]
        public virtual async Task<ActionResult> Activate(int id)
        {
            foreach(var brand in await Database.Brands.ToListAsync())
            {
                brand.IsActive = brand.Id == id;
            }
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Brand.List());
        }

        [ValidateAntiForgeryToken]
        [HttpPost, Route("brand/deactivate")]
        public virtual async Task<ActionResult> Dectivate()
        {
            foreach (var brand in await Database.Brands.ToListAsync())
            {
                brand.IsActive = false;
            }
            await Database.SaveChangesAsync();

            return RedirectToAction(MVC.Brand.List());
        }

        [HttpGet]
        [Route("brand/stylesheet")]
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
            if (Brand.JumboImageUrl != null)
            {
                css = css.Replace("/Content/Images/line.jpg", Brand.JumboImageUrl);
            }
            return Content(css, "text/css");
        }

        private static string ChangeColorBrightness(string hex, float correctionFactor)
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