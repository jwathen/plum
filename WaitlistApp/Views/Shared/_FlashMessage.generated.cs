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
    using WaitlistApp;
    using WaitlistApp.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_FlashMessage.cshtml")]
    public partial class _Views_Shared__FlashMessage_cshtml : WaitlistApp.Web.ApplicationViewBase<WaitlistApp.ViewModels.Shared.FlashMessage>
    {
        public _Views_Shared__FlashMessage_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Shared\_FlashMessage.cshtml"
 if (!string.IsNullOrWhiteSpace(Model?.Text) || !string.IsNullOrWhiteSpace(Model?.MinorText))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 159), Tuple.Create("\"", 229)
, Tuple.Create(Tuple.Create("", 167), Tuple.Create("alert", 167), true)
, Tuple.Create(Tuple.Create(" ", 172), Tuple.Create("alert-dismissible", 173), true)
, Tuple.Create(Tuple.Create(" ", 190), Tuple.Create("alert-", 191), true)
            
            #line 5 "..\..\Views\Shared\_FlashMessage.cshtml"
, Tuple.Create(Tuple.Create("", 197), Tuple.Create<System.Object, System.Int32>(Model.Type.ToString().ToLower()
            
            #line default
            #line hidden
, 197), false)
);

WriteLiteral(">\r\n        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"alert\"");

WriteLiteral(">&times;</button>\r\n");

            
            #line 7 "..\..\Views\Shared\_FlashMessage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Shared\_FlashMessage.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.Text))
        {

            
            #line default
            #line hidden
WriteLiteral("            <strong>");

            
            #line 9 "..\..\Views\Shared\_FlashMessage.cshtml"
               Write(Model.Text);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n");

            
            #line 10 "..\..\Views\Shared\_FlashMessage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 11 "..\..\Views\Shared\_FlashMessage.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.MinorText))
        {

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 13 "..\..\Views\Shared\_FlashMessage.cshtml"
             Write(Model.MinorText);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 14 "..\..\Views\Shared\_FlashMessage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 16 "..\..\Views\Shared\_FlashMessage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\_FlashMessage.cshtml"
          
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591