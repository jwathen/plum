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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Business/ShowBusinessInformation.cshtml")]
    public partial class _Views_Business_ShowBusinessInformation_cshtml : Plum.Web.ApplicationViewBase<Plum.ViewModels.Business.BusinessInformationViewModel>
    {
        public _Views_Business_ShowBusinessInformation_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Business\ShowBusinessInformation.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 6 "..\..\Views\Business\ShowBusinessInformation.cshtml"
Write(Html.FlashMessage());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\Business\ShowBusinessInformation.cshtml"
Write(Html.DisplayForModel());

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>initAjaxLoadLinks(\'#BusinessInformationPanel\');</script>");

        }
    }
}
#pragma warning restore 1591
