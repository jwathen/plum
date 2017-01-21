using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WaitlistApp.ViewModels.Brand
{
    [Validator(typeof(BrandViewModelValidator))]
    public class BrandViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string BrandColor { get; set; }
        public string SecondaryColor { get; set; }
        public string JumboColor { get; set; }
        public string JumboImageUrl { get; set; }
        public string FontUrl { get; set; }
        public string FontName { get; set; }
        public string DomainNames { get; set; }

        public void CleanUp()
        {
            Name = (Name ?? string.Empty).Trim();
            BrandColor = CleanColor(BrandColor);
            SecondaryColor = CleanColor(SecondaryColor);
            JumboColor = CleanColor(JumboColor);
        }

        private string CleanColor(string color)
        {
            color = (color ?? string.Empty).Trim().ToLower();
            if (color.Length == 6 && !color.StartsWith("#"))
            {
                color = "#" + color;
            }
            return color;
        }
    }

    public class BrandViewModelValidator : AbstractValidator<BrandViewModel>
    {
        public BrandViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Brand name is required.");
            RuleFor(x => x.Name)
                .Length(0, 40)
                .WithMessage("Brand name must be less than 40 characters.");
            RuleFor(x => x.BrandColor)
                .Must(BeAValidColor)
                .WithMessage("Brand color is not a valid color.");
            RuleFor(x => x.SecondaryColor)
                .Must(BeAValidColor)
                .WithMessage("Secondary color is not a valid color.");
            RuleFor(x => x.JumboColor)
                .Must(BeAValidColor)
                .WithMessage("Jumbo color is not a valid color.");
            RuleFor(x => x.JumboImageUrl)
                .Must(MustBeAValidUrl)
                .WithMessage("Jumbo image URL is invalid.");
            RuleFor(x => x.JumboImageUrl)
                .Must(MustBeAnImgurUrl)
                .WithMessage("Jumbo image URL must start with https://i.imgur.com/.");
        }

        private bool BeAValidColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
            {
                return true;
            }

            try
            {
                ColorTranslator.FromHtml(color);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool MustBeAValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return true;
            }

            Uri parsedUrl;
            return Uri.TryCreate(url, UriKind.Absolute, out parsedUrl);
        }

        private bool MustBeAnImgurUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return true;
            }

            return url.ToLower().StartsWith("https://i.imgur.com/");
        }
    }
}