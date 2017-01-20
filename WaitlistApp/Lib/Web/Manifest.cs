using WaitlistApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace WaitlistApp.Web
{
    public class Manifest
    {
        public static Manifest Build(UrlHelper url, Brand brand)
        {
            var manifest = new Manifest();
            manifest.name = brand.Name;
            manifest.short_name = brand.Name;
            manifest.background_color = brand.BrandColor;
            manifest.theme_color = "white";
            manifest.display = "standalone";
            manifest.start_url = "/account/sign-up";
            manifest.scope = "/";
            manifest.AddIcons();
            return manifest;
        }

        public string name { get; set; }
        public string short_name { get; set; }
        public string background_color { get; set; }
        public string theme_color { get; set; }
        public List<ManifestImage> icons { get; set; } = new List<ManifestImage>();
        public string display { get; set; }
        public string start_url { get; set; }
        public string scope { get; set; }

        public void AddIcons()
        {
            string iconsPath = HostingEnvironment.MapPath("~/Content/Images/Icons/");
            if (!string.IsNullOrEmpty(iconsPath))
            {
                foreach (string path in Directory.EnumerateFiles(iconsPath))
                {
                    if (Regex.IsMatch(path, @"\d+x\d+\.png"))
                    {
                        string source = "/Content/Images/Icons/" + Path.GetFileName(path);
                        string sizes = Path.GetFileNameWithoutExtension(path);
                        icons.Add(new ManifestImage(sizes, source));
                    }
                }
            }
        }
    }

    public class ManifestImage
    {
        public ManifestImage(string size, string source)
        {
            try
            {
                this.size = int.Parse(size.Split('x')[0]);
                sizes = size;
                src = UrlUtility.FileVersionUrl(source);
            }
            catch { }
        }

        public int size { get; set; }
        public string src { get; set; }
        public string sizes { get; set; }
    }
}
