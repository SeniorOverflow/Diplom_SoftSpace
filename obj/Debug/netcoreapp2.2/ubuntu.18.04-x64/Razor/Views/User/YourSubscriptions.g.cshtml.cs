#pragma checksum "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4b0ed97885edfa6f774ab0546a3ea66711a67a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_YourSubscriptions), @"mvc.1.0.view", @"/Views/User/YourSubscriptions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/YourSubscriptions.cshtml", typeof(AspNetCore.Views_User_YourSubscriptions))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\diploma_project_here\SoftSpace_web\Views\_ViewImports.cshtml"
using SoftSpace_web;

#line default
#line hidden
#line 2 "E:\diploma_project_here\SoftSpace_web\Views\_ViewImports.cshtml"
using SoftSpace_web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4b0ed97885edfa6f774ab0546a3ea66711a67a0", @"/Views/User/YourSubscriptions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d30cee2550be9db46aaba39048f361d201242e2", @"/Views/_ViewImports.cshtml")]
    public class Views_User_YourSubscriptions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "YourSubscriptions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Previous"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-numb_page", "this_page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Next"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
  
  int previous  = 0;
  int next = 1;
  int this_page = 0;
    
    if(@ViewBag.Subs.currect_number < 0)
      {
        this_page = 0;
      }
    else
      {
        this_page = @ViewBag.Subs.currect_number;
      }

    if(this_page > 0) 
      {
        previous = this_page - 1;
      }
    else
      {
        this_page = 0;
      }
    
    next = this_page  +1 ;

#line default
#line hidden
            BeginContext(402, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(405, 44, false);
#line 27 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(449, 296, true);
            WriteLiteral(@"
<h1>Your Subscriptions</h1>


<table class=""table"">
  <thead class=""thead-light"">
    <tr>
      
      <th scope=""col""> Type sub</th>
      <th scope=""col""> Dev</th>
      <th scope=""col"">Date Begin</th>
      <th scope=""col"">Date End</th>
      
    </tr>
  </thead>
  <tbody>
");
            EndContext();
#line 43 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
 foreach( var a in @ViewBag.Subs.list) 
{

#line default
#line hidden
            BeginContext(789, 32, true);
            WriteLiteral("    <tr>\r\n      <th scope=\"row\">");
            EndContext();
            BeginContext(822, 4, false);
#line 46 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                 Write(a[0]);

#line default
#line hidden
            EndContext();
            BeginContext(826, 17, true);
            WriteLiteral("</th>\r\n      <td>");
            EndContext();
            BeginContext(844, 4, false);
#line 47 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
     Write(a[1]);

#line default
#line hidden
            EndContext();
            BeginContext(848, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(866, 4, false);
#line 48 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
     Write(a[2]);

#line default
#line hidden
            EndContext();
            BeginContext(870, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(888, 4, false);
#line 49 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
     Write(a[3]);

#line default
#line hidden
            EndContext();
            BeginContext(892, 25, true);
            WriteLiteral("</td>\r\n     \r\n    </tr>\r\n");
            EndContext();
#line 52 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
   
}

#line default
#line hidden
            BeginContext(925, 18, true);
            WriteLiteral("\r\n</table>\r\n\r\n\r\n\r\n");
            EndContext();
#line 59 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
 if(@ViewBag.Subs.count_pages > 1 )
{

#line default
#line hidden
            BeginContext(983, 51, true);
            WriteLiteral("<nav aria-label=\"...\">\r\n  <ul class=\"pagination\">\r\n");
            EndContext();
#line 63 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
     if(this_page > 0)
    {

#line default
#line hidden
            BeginContext(1065, 34, true);
            WriteLiteral("    <li class=\"page-item\">\r\n      ");
            EndContext();
            BeginContext(1099, 240, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4b0ed97885edfa6f774ab0546a3ea66711a67a08830", async() => {
                BeginContext(1231, 104, true);
                WriteLiteral("\r\n        <span aria-hidden=\"true\">&laquo;</span>\r\n        <span class=\"sr-only\">Previous</span>\r\n      ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 66 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                            WriteLiteral(previous);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1339, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 71 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
    }

#line default
#line hidden
            BeginContext(1359, 18, true);
            WriteLiteral("\r\n    \r\n    \r\n\r\n\r\n");
            EndContext();
#line 77 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
     if(this_page < 12)
    {
      

#line default
#line hidden
#line 79 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
       for(int i = 0;i < 19; i++ )
      {
        int nn_page = i;
         

#line default
#line hidden
#line 82 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
          if(nn_page == this_page)
        {

#line default
#line hidden
            BeginContext(1527, 53, true);
            WriteLiteral("          <li class=\"page-item active\">\r\n            ");
            EndContext();
            BeginContext(1580, 169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4b0ed97885edfa6f774ab0546a3ea66711a67a012662", async() => {
                BeginContext(1692, 13, false);
#line 85 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                                      Write(this_page + 1);

#line default
#line hidden
                EndContext();
                BeginContext(1706, 39, true);
                WriteLiteral(" <span class=\"sr-only\">(current)</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 85 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                  WriteLiteral(this_page);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1749, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 87 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"

        }
        else{
          if((i < @ViewBag.Subs.count_pages)&&(i >= 0))
          {

#line default
#line hidden
            BeginContext(1866, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1878, 127, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4b0ed97885edfa6f774ab0546a3ea66711a67a016085", async() => {
                BeginContext(1989, 11, false);
#line 92 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                                     Write(nn_page + 1);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 92 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                  WriteLiteral(nn_page);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2005, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 93 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
          }
        }

#line default
#line hidden
#line 94 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
         
      }

#line default
#line hidden
#line 95 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
       
      
    }
    else
    {
      

#line default
#line hidden
#line 100 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
       for( int i =  Convert.ToInt32(this_page) - 9 ;
        i < Convert.ToInt32(this_page) + 10; i++)
      {
        
        int nn_page = i;
        
        

#line default
#line hidden
#line 106 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
         if(nn_page == this_page)
        {

#line default
#line hidden
            BeginContext(2279, 53, true);
            WriteLiteral("          <li class=\"page-item active\">\r\n            ");
            EndContext();
            BeginContext(2332, 168, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4b0ed97885edfa6f774ab0546a3ea66711a67a020056", async() => {
                BeginContext(2443, 13, false);
#line 109 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                                     Write(this_page + 1);

#line default
#line hidden
                EndContext();
                BeginContext(2457, 39, true);
                WriteLiteral(" <span class=\"sr-only\">(current)</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2500, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 111 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"

        }
        else{
          if((i < @ViewBag.Subs.count_pages)&&(i >= 0))
          {

#line default
#line hidden
            BeginContext(2617, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2629, 127, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4b0ed97885edfa6f774ab0546a3ea66711a67a022965", async() => {
                BeginContext(2740, 11, false);
#line 116 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                                     Write(nn_page + 1);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 116 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                                  WriteLiteral(nn_page);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2756, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 117 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
          }
        }

#line default
#line hidden
#line 118 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
         
      }

#line default
#line hidden
#line 119 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
       


    }

#line default
#line hidden
            BeginContext(2802, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 124 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
     if(next < @ViewBag.Subs.count_pages)
    {

#line default
#line hidden
            BeginContext(2854, 34, true);
            WriteLiteral("    <li class=\"page-item\">\r\n      ");
            EndContext();
            BeginContext(2888, 227, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4b0ed97885edfa6f774ab0546a3ea66711a67a026712", async() => {
                BeginContext(3011, 100, true);
                WriteLiteral("\r\n        <span aria-hidden=\"true\">&raquo;</span>\r\n        <span class=\"sr-only\">Next</span>\r\n      ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 127 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
                                                                                            WriteLiteral(next);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3115, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 132 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
    }

#line default
#line hidden
            BeginContext(3135, 19, true);
            WriteLiteral("\r\n  </ul>\r\n</nav>\r\n");
            EndContext();
#line 136 "E:\diploma_project_here\SoftSpace_web\Views\User\YourSubscriptions.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
