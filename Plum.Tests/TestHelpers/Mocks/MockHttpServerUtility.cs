using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Plum.Tests.TestHelpers.Mocks
{
    public class MockHttpServerUtility : HttpServerUtilityBase
    {
        public override string MapPath(string path)
        {
            path = path.Replace("~", string.Empty).Replace("/", @"\");
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        public override string HtmlDecode(string s)
        {
            return HttpUtility.HtmlDecode(s);
        }

        public override string HtmlEncode(string s)
        {
            return HttpUtility.HtmlEncode(s);
        }

        public override void HtmlDecode(string s, TextWriter output)
        {
            output.Write(HtmlDecode(s));
        }

        public override void HtmlEncode(string s, TextWriter output)
        {
            output.Write(HtmlEncode(s));
        }

        public override string UrlDecode(string s)
        {
            return HttpUtility.UrlDecode(s);
        }

        public override void UrlDecode(string s, TextWriter output)
        {
            output.Write(HttpUtility.UrlDecode(s));
        }

        public override string UrlEncode(string s)
        {
            return HttpUtility.UrlDecode(s);
        }

        public override void UrlEncode(string s, TextWriter output)
        {
            output.Write(HttpUtility.UrlEncode(s));
        }

        public override string UrlPathEncode(string s)
        {
            return HttpUtility.UrlPathEncode(s);
        }

        public override void Execute(IHttpHandler handler, TextWriter writer, bool preserveForm)
        {
            writer.Write("Child actions are not supported for testing.");
        }
    }
}
