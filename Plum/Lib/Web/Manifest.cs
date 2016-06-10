using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;

namespace Plum.Web
{
    public class Manifest
    {
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
            foreach(string path in Directory.EnumerateFiles(HostingEnvironment.MapPath("~/Content/Images/Icons/")))
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

    public class ManifestImage
    {
        public ManifestImage(string size, string source)
        {
            sizes = size;
            src = UrlUtility.FileVersionUrl(source);
        }

        public string src { get; set; }
        public string sizes { get; set; }
    }
}
