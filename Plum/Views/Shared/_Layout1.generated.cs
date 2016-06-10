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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : Plum.Web.ApplicationViewBase<dynamic>
    {

#line 1 "..\..\Views\Shared\_Layout.cshtml"
public System.Web.WebPages.HelperResult controller()
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 2 "..\..\Views\Shared\_Layout.cshtml"
 
    

#line default
#line hidden

#line 3 "..\..\Views\Shared\_Layout.cshtml"
WriteTo(__razor_helper_writer, ViewContext.RouteData.GetRequiredString("controller").Underscore().Dasherize());


#line default
#line hidden

#line 3 "..\..\Views\Shared\_Layout.cshtml"
                                                                                   ;


#line default
#line hidden
});

#line 4 "..\..\Views\Shared\_Layout.cshtml"
}
#line default
#line hidden

#line 5 "..\..\Views\Shared\_Layout.cshtml"
public System.Web.WebPages.HelperResult action()
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 6 "..\..\Views\Shared\_Layout.cshtml"
 
    

#line default
#line hidden

#line 7 "..\..\Views\Shared\_Layout.cshtml"
WriteTo(__razor_helper_writer, (ViewContext.RouteData.GetRequiredString("controller") + ViewContext.RouteData.GetRequiredString("action")).Underscore().Dasherize());


#line default
#line hidden

#line 7 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                           ;


#line default
#line hidden
});

#line 8 "..\..\Views\Shared\_Layout.cshtml"
}
#line default
#line hidden

        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <link");

WriteLiteral(" href=\"https://fonts.googleapis.com/css?family=Great+Vibes\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" href=\"https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.cs" +
"s\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 528), Tuple.Create("\"", 590)
            
            #line 15 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 535), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Styles.Site_min_css)
            
            #line default
            #line hidden
, 535), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <title>");

            
            #line 16 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"application-version\"");

WriteAttribute("content", Tuple.Create(" content=\"", 760), Tuple.Create("\"", 820)
            
            #line 18 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 770), Tuple.Create<System.Object, System.Int32>(AppSettings.Version
            
            #line default
            #line hidden
, 770), false)
, Tuple.Create(Tuple.Create(" ", 790), Tuple.Create("(", 791), true)
            
            #line 18 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 792), Tuple.Create<System.Object, System.Int32>(AppSettings.ReleaseProfile
            
            #line default
            #line hidden
, 792), false)
, Tuple.Create(Tuple.Create("", 819), Tuple.Create(")", 819), true)
);

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"mobile-web-app-capable\"");

WriteLiteral(" content=\"yes\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"manifest\"");

WriteLiteral(" href=\"/manifest.json\"");

WriteLiteral(">\r\n</head>\r\n<body");

WriteAttribute("class", Tuple.Create(" class=\"", 945), Tuple.Create("\"", 976)
            
            #line 22 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 953), Tuple.Create<System.Object, System.Int32>(controller()
            
            #line default
            #line hidden
, 953), false)
            
            #line 22 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create(" ", 966), Tuple.Create<System.Object, System.Int32>(action()
            
            #line default
            #line hidden
, 967), false)
);

WriteLiteral(">\r\n    <nav");

WriteLiteral(" class=\"navbar navbar-default\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\"#main-navigation\"");

WriteLiteral(" class=\"navbar-toggle collapsed\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle Navigation</span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                </button>\r\n                <a");

WriteLiteral(" href=\"/\"");

WriteLiteral(" class=\"navbar-brand text-info\"");

WriteLiteral(">");

            
            #line 32 "..\..\Views\Shared\_Layout.cshtml"
                                                      Write(Html.ApplicationName());

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </div>\r\n            <div");

WriteLiteral(" id=\"main-navigation\"");

WriteLiteral(" class=\"collapse navbar-collapse\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n");

            
            #line 36 "..\..\Views\Shared\_Layout.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Shared\_Layout.cshtml"
                     if (Request.IsAuthenticated)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li>\r\n                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1832), Tuple.Create("\"", 1868)
            
            #line 39 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1839), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Queue.Show())
            
            #line default
            #line hidden
, 1839), false)
);

WriteLiteral(">Wait List</a>\r\n                        </li>\r\n");

WriteLiteral("                        <li>\r\n                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1976), Tuple.Create("\"", 2042)
            
            #line 42 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1983), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Business.Show(AppSession.BusinessId.Value))
            
            #line default
            #line hidden
, 1983), false)
);

WriteLiteral(">Settings</a>\r\n                        </li>\r\n");

            
            #line 44 "..\..\Views\Shared\_Layout.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <li>\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">How It Works</a>\r\n                        </li>\r\n");

WriteLiteral("                        <li>\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">About</a>\r\n                        </li>\r\n");

            
            #line 53 "..\..\Views\Shared\_Layout.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <li>\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2467), Tuple.Create("\"", 2507)
            
            #line 55 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2474), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.ContactUs())
            
            #line default
            #line hidden
, 2474), false)
);

WriteLiteral(">Contact Us</a>\r\n                    </li>\r\n                </ul>\r\n");

            
            #line 58 "..\..\Views\Shared\_Layout.cshtml"
                
            
            #line default
            #line hidden
            
            #line 58 "..\..\Views\Shared\_Layout.cshtml"
                 if (Request.IsAuthenticated)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <ul");

WriteLiteral(" class=\"nav navbar-nav navbar-right\"");

WriteLiteral(">\r\n                        <li>\r\n                            <span");

WriteLiteral(" class=\"navbar-text\"");

WriteLiteral(">");

            
            #line 62 "..\..\Views\Shared\_Layout.cshtml"
                                                 Write(AppSession.BusinessName);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </li>\r\n                        <li>\r\n           " +
"                 <form");

WriteAttribute("action", Tuple.Create(" action=\"", 2914), Tuple.Create("\"", 2957)
            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2923), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Account.SignOut())
            
            #line default
            #line hidden
, 2923), false)
);

WriteLiteral(">\r\n                                <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default navbar-btn\"");

WriteLiteral(">Sign Out</button>\r\n                            </form>\r\n                        " +
"</li>\r\n                    </ul>\r\n");

            
            #line 70 "..\..\Views\Shared\_Layout.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3246), Tuple.Create("\"", 3286)
            
            #line 73 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3253), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Account.SignIn())
            
            #line default
            #line hidden
, 3253), false)
);

WriteLiteral(" class=\"btn btn-default navbar-btn navbar-right\"");

WriteLiteral(">Sign In</a>\r\n");

            
            #line 74 "..\..\Views\Shared\_Layout.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n    </nav>\r\n");

WriteLiteral("    ");

            
            #line 78 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                <hr />\r\n                <ul");

WriteLiteral(" class=\"list-inline\"");

WriteLiteral(">\r\n                    <li>&copy; ");

            
            #line 84 "..\..\Views\Shared\_Layout.cshtml"
                          Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 84 "..\..\Views\Shared\_Layout.cshtml"
                                             Write(AppSettings.App.Company);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 85 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Privacy Policy", MVC.Home.PrivacyPolicy()));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>");

            
            #line 86 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Terms of Use", MVC.Home.TermsOfUse()));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"app-icon hidden\"");

WriteLiteral(">\r\n            <span>\r\n                Plum\r\n            </span>\r\n        </div>\r" +
"\n    </div>\r\n    <div");

WriteLiteral(" id=\"ConfirmModal\"");

WriteLiteral(" class=\"modal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"vertical-alignment-helper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-dialog vertical-align-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-label=\"Close\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">&times;</span></button>\r\n                        <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral("></h4>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                        <p></p>\r\n                    </div>\r\n                 " +
"   <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default pull-left\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">No</button>\r\n                        <button");

WriteLiteral(" id=\"ConfirmModal-Yes\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">Yes</button>\r\n                    </div>\r\n                </div>\r\n            </" +
"div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 115 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 115 "..\..\Views\Shared\_Layout.cshtml"
     using (Html.BeginForm(null, null, FormMethod.Post, new { id = "__AjaxAntiForgeryForm" }))
    {
        
            
            #line default
            #line hidden
            
            #line 117 "..\..\Views\Shared\_Layout.cshtml"
   Write(Html.AntiForgeryToken2());

            
            #line default
            #line hidden
            
            #line 117 "..\..\Views\Shared\_Layout.cshtml"
                                 
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 119 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js", Links.Content.Scripts.CdnFallbacks.jquery_2_2_4_min_js, "window.jQuery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 120 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js", Links.Content.Scripts.CdnFallbacks.bootstrap_3_3_6_min_js, "$.fn.modal"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 121 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://ajax.aspnetcdn.com/ajax/jquery.validate/1.14.0/jquery.validate.min.js", Links.Content.Scripts.CdnFallbacks.jquery_validate_1_14_0_min_js, "$.fn.validate"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 122 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://ajax.aspnetcdn.com/ajax/mvc/5.2.3/jquery.validate.unobtrusive.min.js", Links.Content.Scripts.CdnFallbacks.jquery_validate_unobtrusive_5_2_3_min_js, "$.validate.unobtrusive"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 123 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://cdnjs.cloudflare.com/ajax/libs/formatter.js/0.1.5/jquery.formatter.min.js", Links.Content.Scripts.CdnFallbacks.jquery_formatter_0_1_5_min_js, "$.fn.formatter"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 124 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://ajax.aspnetcdn.com/ajax/signalr/jquery.signalr-2.2.0.min.js", Links.Content.Scripts.CdnFallbacks.jquery_signalr_2_2_0_min_js, "$.signalR"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 125 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.CdnScript("https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js", Links.Content.Scripts.CdnFallbacks.jquery_ui_1_11_4_min_js, "$.ui"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 6390), Tuple.Create("\"", 6481)
            
            #line 126 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 6396), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Scripts.jquery_ui_touch_punch_improved_es5_min_js)
            
            #line default
            #line hidden
, 6396), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 6505), Tuple.Create("\"", 6525)
, Tuple.Create(Tuple.Create("", 6511), Tuple.Create<System.Object, System.Int32>(Href("~/signalr/hubs")
, 6511), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 6549), Tuple.Create("\"", 6629)
            
            #line 128 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 6555), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Scripts.jquery_unobtrusive_ajax_min_js)
            
            #line default
            #line hidden
, 6555), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 6653), Tuple.Create("\"", 6718)
            
            #line 129 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 6659), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Scripts.Site_es5_min_js)
            
            #line default
            #line hidden
, 6659), false)
);

WriteLiteral("></script>\r\n");

WriteLiteral("    ");

            
            #line 130 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 131 "..\..\Views\Shared\_Layout.cshtml"
Write(StackExchange.Profiling.MiniProfiler.RenderIncludes());

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
