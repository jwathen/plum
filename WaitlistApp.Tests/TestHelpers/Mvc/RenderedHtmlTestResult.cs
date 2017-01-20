using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;
using WaitlistApp.Controllers;

namespace WaitlistApp.Tests.TestHelpers.Mvc
{
    public class RenderedHtmlResultTest<TController> where TController : AppControllerBase
    {
        private readonly ControllerResultTest<TController> _controllerResultTest;
        private readonly ViewResultTest _viewResultTest;
        private readonly string _html;
        private HtmlDocument _htmlDocument;

        public RenderedHtmlResultTest(ControllerResultTest<TController> controllerResultTest, ViewResultTest viewResultTest, string html)
        {
            _controllerResultTest = controllerResultTest;
            _viewResultTest = viewResultTest;
            html = RemoveHtmlComments(html);
            _html = html;
        }

        public ControllerResultTest<TController> Controller
        {
            get
            {
                return _controllerResultTest;
            }
        }

        public ViewResultTest View
        {
            get
            {
                return _viewResultTest;
            }
        }

        public string Html
        {
            get
            {
                return _html;
            }
        }

        public HtmlNode HtmlDocument
        {
            get
            {
                if (_htmlDocument == null)
                {
                    _htmlDocument = new HtmlDocument();
                    _htmlDocument.LoadHtml(_html);
                }
                return _htmlDocument.DocumentNode;
            }
        }

        private string RemoveHtmlComments(string html)
        {
            if (html == null)
            {
                return html;
            }
            else
            {
                Regex htmlComment = new Regex(@"<!--.*?-->");
                return htmlComment.Replace(html, string.Empty);
            }
        }
    }
}
