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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Business/EditTextMessages.cshtml")]
    public partial class _Views_Business_EditTextMessages_cshtml : Plum.Web.ApplicationViewBase<Plum.ViewModels.Business.TextMessagesViewModel>
    {
        public _Views_Business_EditTextMessages_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Business\EditTextMessages.cshtml"
   
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 6 "..\..\Views\Business\EditTextMessages.cshtml"
 using (Ajax.BeginForm(MVC.Business.UpdateTextMessages(), new AjaxOptions { OnBegin = "setLoading", OnComplete = "clearLoading", UpdateTargetId = "TextMessagesPanel" }))
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Business\EditTextMessages.cshtml"
Write(Html.EditorForModel());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Business\EditTextMessages.cshtml"
                          
}

            
            #line default
            #line hidden
WriteLiteral("<script>initAjaxLoadLinks(\'#TextMessagesPanel\');</script>");

        }
    }
}
#pragma warning restore 1591
