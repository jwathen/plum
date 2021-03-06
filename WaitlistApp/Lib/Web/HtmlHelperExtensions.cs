﻿using WaitlistApp.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WaitlistApp.Web
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ApplicationName(this HtmlHelper html)
        {
            var brand = ((AppControllerBase)html.ViewContext.Controller).Brand;

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("brand-font");
            span.SetInnerText(brand.Name);
            return new HtmlString(span.ToString());
        }

        public static HtmlString ApplicationNameWithIcon(this HtmlHelper html, bool brandColor = true)
        {
            var brand = ((AppControllerBase)html.ViewContext.Controller).Brand;

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("brand-font");
            TagBuilder img = new TagBuilder("img");
            img.AddCssClass("brand-icon");
            if (brandColor)
            {
                img.MergeAttribute("src", html.FileVersionUrl(Links.Content.Images.bear_icon_brand_svg));
            }
            else
            {
                img.MergeAttribute("src", html.FileVersionUrl(Links.Content.Images.bear_icon_white_svg));
            }
            span.InnerHtml = img.ToString() + " " + brand.Name;
            return new HtmlString(span.ToString());
        }

        public static string FileVersionUrl(this HtmlHelper html, string rootRelativePath)
        {
            return UrlUtility.FileVersionUrl(rootRelativePath);
        }
         
        public static HtmlString AntiForgeryToken2(this HtmlHelper html)
        {
            if (HttpContext.Current == null)
            {
                return new HtmlString(string.Empty);
            }
            else
            {
                return html.AntiForgeryToken();
            }
        }

        public static HtmlString FlashMessage(this HtmlHelper html)
        {
            var flashMessage = html.ViewContext.TempData["FlashMessage"] as ViewModels.Shared.FlashMessage;
            if (flashMessage != null)
            {
                return html.Partial(MVC.Shared.Views._FlashMessage, flashMessage);
            }
            return new HtmlString(string.Empty);
        }

        public static HtmlString PhoneNumber(this HtmlHelper html, string phoneNumber)
        {
            phoneNumber = phoneNumber ?? string.Empty;
            phoneNumber = phoneNumber.Trim();
            if (phoneNumber.Length == 10 && phoneNumber.All(x => char.IsDigit(x)))
            {
                string format = "({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}";
                return new HtmlString(string.Format(format, 
                    phoneNumber[0],
                    phoneNumber[1],
                    phoneNumber[2],
                    phoneNumber[3],
                    phoneNumber[4],
                    phoneNumber[5],
                    phoneNumber[6],
                    phoneNumber[7],
                    phoneNumber[8],
                    phoneNumber[9]));
            }
            else
            {
                return new HtmlString(phoneNumber);
            }
        }

        public static HtmlString PhoneNumberDashes(this HtmlHelper html, string phoneNumber)
        {
            phoneNumber = phoneNumber ?? string.Empty;
            phoneNumber = phoneNumber.Trim();
            if (phoneNumber.Length == 10 && phoneNumber.All(x => char.IsDigit(x)))
            {
                string format = "{0}{1}{2}-{3}{4}{5}-{6}{7}{8}{9}";
                return new HtmlString(string.Format(format,
                    phoneNumber[0],
                    phoneNumber[1],
                    phoneNumber[2],
                    phoneNumber[3],
                    phoneNumber[4],
                    phoneNumber[5],
                    phoneNumber[6],
                    phoneNumber[7],
                    phoneNumber[8],
                    phoneNumber[9]));
            }
            else
            {
                return new HtmlString(phoneNumber);
            }
        }

        public static HtmlString CdnScript(this HtmlHelper html, string cdnUrl, string fallbackUrl, string test)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine($"<script src=\"{html.AttributeEncode(cdnUrl)}\"></script>");
            markup.AppendLine($"<script>{test} || document.write('<script src=\"{UrlUtility.FileVersionUrl(fallbackUrl)}\">\\x3C/script>')</script>");
            return new HtmlString(markup.ToString());
        }
    }
}