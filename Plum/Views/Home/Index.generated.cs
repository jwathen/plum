﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Humanizer;
    using Plum;
    using Plum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class _Views_Home_Index_cshtml : Plum.Web.ApplicationViewBase<dynamic>
    {
        public _Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Index";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row jumbo\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <h1");

WriteLiteral(" class=\"big hidden-xs hidden-sm\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 9 "..\..\Views\Home\Index.cshtml"
           Write(Html.ApplicationName());

            
            #line default
            #line hidden
WriteLiteral("\r\n            </h1>\r\n            <h1");

WriteLiteral(" class=\"hidden-md hidden-lg\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 12 "..\..\Views\Home\Index.cshtml"
           Write(Html.ApplicationName());

            
            #line default
            #line hidden
WriteLiteral("\r\n            </h1>\r\n            <p");

WriteLiteral(" class=\"lead\"");

WriteLiteral(">\r\n                Seat diners faster with this FREE service by taking advantage " +
"of the technology they\'re already using.\r\n            </p>\r\n            <p>\r\n   " +
"             <a");

WriteAttribute("href", Tuple.Create(" href=\"", 551), Tuple.Create("\"", 591)
            
            #line 18 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 558), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Account.SignUp())
            
            #line default
            #line hidden
, 558), false)
);

WriteLiteral(" class=\"btn btn-primary btn-lg\"");

WriteLiteral(">\r\n                    Sign Up\r\n                </a>\r\n                or\r\n       " +
"         <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                    Learn How It Works\r\n                </a>\r\n            </p>" +
"\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"hr\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 3316), Tuple.Create("\"", 3381)
            
            #line 75 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 3322), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Images.testimonial1_jpg)
            
            #line default
            #line hidden
, 3322), false)
);

WriteLiteral(" alt=\"Two young people holding hands.\"");

WriteLiteral(" class=\"img-responsive img-circle\"");

WriteLiteral(" />\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-md-8\"");

WriteLiteral(">\r\n                    <strong");

WriteLiteral(" class=\"tagline\"");

WriteLiteral(@">
                        John in Phoenix is pretty sure these two would say,
                    </strong>
                    <p>
                        We've been holding hands since we were 13 years old. It's made life difficult sometimes. Bathing . Dressing. All of these are struggles. Having only one free hand each,
                        being told to hold a bulky coaster cut our hand effectiveness by 50%. Thanks, ");

            
            #line 83 "..\..\Views\Home\Index.cshtml"
                                                                                                 Write(AppSettings.App.Name);

            
            #line default
            #line hidden
WriteLiteral(" for enabling our decisions!\r\n                    </p>\r\n                </div>\r\n " +
"           </div>\r\n            <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4219), Tuple.Create("\"", 4284)
            
            #line 89 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 4225), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Images.testimonial2_jpg)
            
            #line default
            #line hidden
, 4225), false)
);

WriteLiteral(" alt=\"Woman wearing a poncho in the park.\"");

WriteLiteral(" class=\"img-responsive img-circle\"");

WriteLiteral(" />\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"col-md-8\"");

WriteLiteral(">\r\n                    <strong");

WriteLiteral(" class=\"tagline\"");

WriteLiteral(@">
                        Christian in Los Angeles feels like this lady would say,
                    </strong>
                    <p>
                        When I'm not out taking poignant walks with my Friendship Poncho, I like patiently waiting for tables at trendy new restaurants. My thirst for a forgotten era is gone when I
                        experience true modern convenience and efficiency. Thanks, ");

            
            #line 97 "..\..\Views\Home\Index.cshtml"
                                                                              Write(AppSettings.App.Name);

            
            #line default
            #line hidden
WriteLiteral("!\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        " +
"</div>\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
