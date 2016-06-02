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

namespace Plum.Web
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ApplicationName(this HtmlHelper html)
        {
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("brand-font");
            span.SetInnerText(AppSettings.ApplicationName);
            return new HtmlString(span.ToString());
        }

        public static string FileVersionUrl(this HtmlHelper html, string rootRelativePath)
        {
            if (HttpRuntime.Cache[rootRelativePath] == null)
            {
                string filePath = HostingEnvironment.MapPath("~" + rootRelativePath);
                if (File.Exists(filePath))
                {
                    BigInteger fileHash = 0;
                    using (var md5 = MD5.Create())
                    {
                        using (var fileStream = File.OpenRead(filePath))
                        {
                            fileHash = new BigInteger(md5.ComputeHash(fileStream));
                        }
                    }

                    int index = rootRelativePath.LastIndexOf('/');
                    string result = rootRelativePath.Insert(index, "/v-" + fileHash);
                    HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(filePath));
                }
            }

            return HttpRuntime.Cache[rootRelativePath] as string;
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
    }
}