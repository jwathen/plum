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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Queue/CustomerViewQueueList.cshtml")]
    public partial class _Views_Queue_CustomerViewQueueList_cshtml : Plum.Web.ApplicationViewBase<Plum.Models.Customer>
    {
        public _Views_Queue_CustomerViewQueueList_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
  
    Layout = null;
    int numberOfPartiesAheadOfCustomer = Model.Queue.NumberOfPartiesAheadOf(Model);

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
 if (numberOfPartiesAheadOfCustomer == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <p>You are next in line.</p>\r\n");

            
            #line 11 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
}
else if (numberOfPartiesAheadOfCustomer == 1)
{

            
            #line default
            #line hidden
WriteLiteral("    <p>There is one party ahead of you.</p>\r\n");

            
            #line 15 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
}
else if (numberOfPartiesAheadOfCustomer <= 6)
{

            
            #line default
            #line hidden
WriteLiteral("    <p>There are ");

            
            #line 18 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
            Write(numberOfPartiesAheadOfCustomer.ToWords());

            
            #line default
            #line hidden
WriteLiteral(" parties ahead of you.</p>\r\n");

            
            #line 19 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <p>There are ");

            
            #line 22 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
            Write(numberOfPartiesAheadOfCustomer);

            
            #line default
            #line hidden
WriteLiteral(" parties ahead of you.</p>\r\n");

            
            #line 23 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<ul");

WriteLiteral(" class=\"list-group text-center\"");

WriteLiteral(">\r\n");

            
            #line 25 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
     foreach (var customer in Model.Queue.OrderedCustomers())
    {

            
            #line default
            #line hidden
WriteLiteral("        <li");

WriteAttribute("class", Tuple.Create(" class=\"", 671), Tuple.Create("\"", 749)
, Tuple.Create(Tuple.Create("", 679), Tuple.Create("list-group-item", 679), true)
            
            #line 27 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
, Tuple.Create(Tuple.Create(" ", 694), Tuple.Create<System.Object, System.Int32>(customer == Model ? "list-group-item-active" : null
            
            #line default
            #line hidden
, 695), false)
);

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
       Write(customer.ObfuscateName(Model));

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 28 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
                                       Write(customer.NumberInParty);

            
            #line default
            #line hidden
WriteLiteral(") Waited ");

            
            #line 28 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
                                                                       Write(customer.TimeWaitedWords());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </li>\r\n");

            
            #line 30 "..\..\Views\Queue\CustomerViewQueueList.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</ul>");

        }
    }
}
#pragma warning restore 1591