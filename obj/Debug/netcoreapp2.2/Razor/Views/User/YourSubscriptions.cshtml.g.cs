#pragma checksum "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b2411"
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
#line 1 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\_ViewImports.cshtml"
using SoftSpace_web;

#line default
#line hidden
#line 2 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\_ViewImports.cshtml"
using SoftSpace_web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b2411", @"/Views/User/YourSubscriptions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a7567d2189ad0d954acaa4c6e3d3b2b6565305a5ce075782787651b828a1d811", @"/Views/_ViewImports.cshtml")]
    public class Views_User_YourSubscriptions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm-2 btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SubToDev_View", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Previous"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "YourSubscriptions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-numb_page", "this_page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Next"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#line 1 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
  
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
#line 27 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(449, 346, true);
            WriteLiteral(@"
<h1>Ваши подписки</h1>


<table class=""table"">
  <thead class=""thead-light"">
    <tr>
      
      <th scope=""col"">Тип подписки  </th>
      <th scope=""col"">Разработчик   </th>
      <th scope=""col"">Дата начала   </th>
      <th scope=""col"">Дата конца    </th>
      <th scope=""col""></th> 
      
    </tr>
  </thead>
  <tbody>
");
            EndContext();
#line 44 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
 foreach( var a in @ViewBag.Subs.list) 
{

#line default
#line hidden
            BeginContext(839, 32, true);
            WriteLiteral("    <tr>\r\n      <th scope=\"row\">");
            EndContext();
            BeginContext(872, 4, false);
#line 47 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                 Write(a[0]);

#line default
#line hidden
            EndContext();
            BeginContext(876, 17, true);
            WriteLiteral("</th>\r\n      <td>");
            EndContext();
            BeginContext(894, 4, false);
#line 48 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
     Write(a[1]);

#line default
#line hidden
            EndContext();
            BeginContext(898, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(916, 4, false);
#line 49 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
     Write(a[2]);

#line default
#line hidden
            EndContext();
            BeginContext(920, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(938, 4, false);
#line 50 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
     Write(a[3]);

#line default
#line hidden
            EndContext();
            BeginContext(942, 26, true);
            WriteLiteral("</td>\r\n      <td>\r\n       ");
            EndContext();
            BeginContext(968, 144, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b24118955", async() => {
                BeginContext(1099, 9, true);
                WriteLiteral(" Продлить");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id_dev", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                                                                                                WriteLiteral(a[4]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id_dev"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id_dev", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id_dev"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1112, 26, true);
            WriteLiteral("\r\n      </td>\r\n    </tr>\r\n");
            EndContext();
#line 55 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
   
}

#line default
#line hidden
            BeginContext(1146, 18, true);
            WriteLiteral("\r\n</table>\r\n\r\n\r\n\r\n");
            EndContext();
#line 62 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
 if(@ViewBag.Subs.count_pages > 1 )
{

#line default
#line hidden
            BeginContext(1204, 51, true);
            WriteLiteral("<nav aria-label=\"...\">\r\n  <ul class=\"pagination\">\r\n");
            EndContext();
#line 66 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
     if(this_page > 0)
    {

#line default
#line hidden
            BeginContext(1286, 34, true);
            WriteLiteral("    <li class=\"page-item\">\r\n      ");
            EndContext();
            BeginContext(1320, 240, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b241112678", async() => {
                BeginContext(1452, 104, true);
                WriteLiteral("\r\n        <span aria-hidden=\"true\">&laquo;</span>\r\n        <span class=\"sr-only\">Previous</span>\r\n      ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 69 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
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
            BeginContext(1560, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 74 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
    }

#line default
#line hidden
            BeginContext(1580, 18, true);
            WriteLiteral("\r\n    \r\n    \r\n\r\n\r\n");
            EndContext();
#line 80 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
     if(this_page < 12)
    {
      

#line default
#line hidden
#line 82 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
       for(int i = 0;i < 19; i++ )
      {
        int nn_page = i;
         

#line default
#line hidden
#line 85 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
          if(nn_page == this_page)
        {

#line default
#line hidden
            BeginContext(1748, 53, true);
            WriteLiteral("          <li class=\"page-item active\">\r\n            ");
            EndContext();
            BeginContext(1801, 169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b241116590", async() => {
                BeginContext(1913, 13, false);
#line 88 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                                                                                                                      Write(this_page + 1);

#line default
#line hidden
                EndContext();
                BeginContext(1927, 39, true);
                WriteLiteral(" <span class=\"sr-only\">(current)</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
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
            BeginContext(1970, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 90 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"

        }
        else{
          if((i < @ViewBag.Subs.count_pages)&&(i >= 0))
          {

#line default
#line hidden
            BeginContext(2087, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2099, 127, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b241120070", async() => {
                BeginContext(2210, 11, false);
#line 95 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                                                                                                                     Write(nn_page + 1);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 95 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
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
            BeginContext(2226, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 96 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
          }
        }

#line default
#line hidden
#line 97 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
         
      }

#line default
#line hidden
#line 98 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
       
      
    }
    else
    {
      

#line default
#line hidden
#line 103 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
       for( int i =  Convert.ToInt32(this_page) - 9 ;
        i < Convert.ToInt32(this_page) + 10; i++)
      {
        
        int nn_page = i;
        
        

#line default
#line hidden
#line 109 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
         if(nn_page == this_page)
        {

#line default
#line hidden
            BeginContext(2500, 53, true);
            WriteLiteral("          <li class=\"page-item active\">\r\n            ");
            EndContext();
            BeginContext(2553, 168, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b241124142", async() => {
                BeginContext(2664, 13, false);
#line 112 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                                                                                                                     Write(this_page + 1);

#line default
#line hidden
                EndContext();
                BeginContext(2678, 39, true);
                WriteLiteral(" <span class=\"sr-only\">(current)</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2721, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 114 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"

        }
        else{
          if((i < @ViewBag.Subs.count_pages)&&(i >= 0))
          {

#line default
#line hidden
            BeginContext(2838, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2850, 127, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b241127097", async() => {
                BeginContext(2961, 11, false);
#line 119 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                                                                                                                     Write(nn_page + 1);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 119 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
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
            BeginContext(2977, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 120 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
          }
        }

#line default
#line hidden
#line 121 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
         
      }

#line default
#line hidden
#line 122 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
       


    }

#line default
#line hidden
            BeginContext(3023, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 127 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
     if(next < @ViewBag.Subs.count_pages)
    {

#line default
#line hidden
            BeginContext(3075, 34, true);
            WriteLiteral("    <li class=\"page-item\">\r\n      ");
            EndContext();
            BeginContext(3109, 227, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80b77d74a3582aa729049df3d54a27c1711014d4030f1a396a9a2a67e99b241130934", async() => {
                BeginContext(3232, 100, true);
                WriteLiteral("\r\n        <span aria-hidden=\"true\">&raquo;</span>\r\n        <span class=\"sr-only\">Next</span>\r\n      ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-numb_page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 130 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
                                                                                            WriteLiteral(next);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3336, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 135 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
    }

#line default
#line hidden
            BeginContext(3356, 19, true);
            WriteLiteral("\r\n  </ul>\r\n</nav>\r\n");
            EndContext();
#line 139 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\YourSubscriptions.cshtml"
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
