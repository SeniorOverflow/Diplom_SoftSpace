#pragma checksum "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec22fbbcdb162e923e791241b29ec6e5cf9f6221"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_GiveRole_View), @"mvc.1.0.view", @"/Views/Admin/GiveRole_View.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/GiveRole_View.cshtml", typeof(AspNetCore.Views_Admin_GiveRole_View))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec22fbbcdb162e923e791241b29ec6e5cf9f6221", @"/Views/Admin/GiveRole_View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d30cee2550be9db46aaba39048f361d201242e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_GiveRole_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GiveRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form_line"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GiveRole_View", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Previous"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-numb_page", "this_page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Next"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
  
  int previous  = 0;
  int next = 1;
  int this_page = 0;
    
    if(@ViewBag.Users.currect_number < 0)
      {
        this_page = 0;
      }
    else
      {
        this_page = @ViewBag.Users.currect_number;
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
            BeginContext(404, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(407, 44, false);
#line 27 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(451, 116, true);
            WriteLiteral("\r\n<h1>User</h1>\r\n\r\n\r\n<table class=\"table\">\r\n  <thead class=\"thead-light\">\r\n    <tr>\r\n      \r\n      <th scope=\"col\"> ");
            EndContext();
            BeginContext(568, 27, false);
#line 35 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                  Write(ViewBag.Translate_words[28]);

#line default
#line hidden
            EndContext();
            BeginContext(595, 30, true);
            WriteLiteral("</th>\r\n      <th scope=\"col\"> ");
            EndContext();
            BeginContext(626, 27, false);
#line 36 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                  Write(ViewBag.Translate_words[30]);

#line default
#line hidden
            EndContext();
            BeginContext(653, 30, true);
            WriteLiteral("</th>\r\n      <th scope=\"col\"> ");
            EndContext();
            BeginContext(684, 27, false);
#line 37 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                  Write(ViewBag.Translate_words[79]);

#line default
#line hidden
            EndContext();
            BeginContext(711, 30, true);
            WriteLiteral("</th>\r\n      <th scope=\"col\"> ");
            EndContext();
            BeginContext(742, 27, false);
#line 38 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                  Write(ViewBag.Translate_words[75]);

#line default
#line hidden
            EndContext();
            BeginContext(769, 30, true);
            WriteLiteral("</th>\r\n      <th scope=\"col\"> ");
            EndContext();
            BeginContext(800, 27, false);
#line 39 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                  Write(ViewBag.Translate_words[80]);

#line default
#line hidden
            EndContext();
            BeginContext(827, 77, true);
            WriteLiteral("</th>\r\n     \r\n      <th scope=\"col\"></th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n");
            EndContext();
#line 45 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
 foreach( var a in @ViewBag.Users.list) 
{
  string id_this = "a"+@a[0];
  

#line default
#line hidden
            BeginContext(982, 23, true);
            WriteLiteral("<div class=\"modal fade\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1005, "\"", 1018, 1);
#line 48 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
WriteAttributeValue("", 1010, id_this, 1010, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1019, 321, true);
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
      <div class=""modal-content"">
        <div class=""modal-header"">
          <h5 class=""modal-title"" id=""exampleModalLabel"">Вы точно уверенны  что хотине назначить   новоую роль для  ");
            EndContext();
            BeginContext(1341, 4, false);
#line 52 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                                                                                                               Write(a[1]);

#line default
#line hidden
            EndContext();
            BeginContext(1345, 85, true);
            WriteLiteral(" ?</h5>\r\n\r\n        </div>\r\n        \r\n        <div class=\"modal-footer\">\r\n\r\n          ");
            EndContext();
            BeginContext(1430, 419, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622110857", async() => {
                BeginContext(1514, 56, true);
                WriteLiteral("\r\n                  <input type=\"hidden\"  name=\"id_user\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1570, "\"", 1583, 1);
#line 59 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
WriteAttributeValue("", 1578, a[0], 1578, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1584, 58, true);
                WriteLiteral("/>\r\n                  <input type=\"hidden\"  name=\"id_role\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1642, "\"", 1666, 1);
#line 60 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
WriteAttributeValue("", 1650, ViewBag.Id_role, 1650, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1667, 59, true);
                WriteLiteral("/>\r\n                  <input type=\"hidden\" name=\"numb_page\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1726, "\"", 1744, 1);
#line 61 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
WriteAttributeValue("", 1734, this_page, 1734, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1745, 97, true);
                WriteLiteral("/>\r\n                  <button type=\"submit\"  class=\"btn btn-primary\">Confirm</button>\r\n          ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1849, 165, true);
            WriteLiteral("    \r\n         \r\n          <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Cancel</button>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>\r\n");
            EndContext();
            BeginContext(2024, 32, true);
            WriteLiteral("    <tr>\r\n      <th scope=\"row\">");
            EndContext();
            BeginContext(2057, 4, false);
#line 74 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                 Write(a[1]);

#line default
#line hidden
            EndContext();
            BeginContext(2061, 17, true);
            WriteLiteral("</th>\r\n      <td>");
            EndContext();
            BeginContext(2079, 4, false);
#line 75 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     Write(a[2]);

#line default
#line hidden
            EndContext();
            BeginContext(2083, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(2101, 4, false);
#line 76 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     Write(a[3]);

#line default
#line hidden
            EndContext();
            BeginContext(2105, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(2123, 4, false);
#line 77 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     Write(a[4]);

#line default
#line hidden
            EndContext();
            BeginContext(2127, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(2145, 4, false);
#line 78 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     Write(a[5]);

#line default
#line hidden
            EndContext();
            BeginContext(2149, 122, true);
            WriteLiteral("</td>\r\n\r\n      \r\n      <td>\r\n\r\n           <button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#");
            EndContext();
            BeginContext(2272, 7, false);
#line 83 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                                                                                      Write(id_this);

#line default
#line hidden
            EndContext();
            BeginContext(2279, 51, true);
            WriteLiteral("\" >Назначить</button>\r\n  \r\n      </td>\r\n    </tr>\r\n");
            EndContext();
#line 87 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
   
}

#line default
#line hidden
            BeginContext(2338, 18, true);
            WriteLiteral("\r\n</table>\r\n\r\n\r\n\r\n");
            EndContext();
#line 94 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
 if(@ViewBag.Users.count_pages > 1 )
{

#line default
#line hidden
            BeginContext(2397, 51, true);
            WriteLiteral("<nav aria-label=\"...\">\r\n  <ul class=\"pagination\">\r\n");
            EndContext();
#line 98 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     if(this_page > 0)
    {

#line default
#line hidden
            BeginContext(2479, 34, true);
            WriteLiteral("    <li class=\"page-item\">\r\n      ");
            EndContext();
            BeginContext(2513, 237, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622117871", async() => {
                BeginContext(2642, 104, true);
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
#line 101 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                                                                                         WriteLiteral(previous);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2750, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 106 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
    }

#line default
#line hidden
            BeginContext(2770, 18, true);
            WriteLiteral("\r\n    \r\n    \r\n\r\n\r\n");
            EndContext();
#line 112 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     if(this_page < 12)
    {
      

#line default
#line hidden
#line 114 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
       for(int i = 0;i < 19; i++ )
      {
        int nn_page = i;
         

#line default
#line hidden
#line 117 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
          if(nn_page == this_page)
        {

#line default
#line hidden
            BeginContext(2938, 53, true);
            WriteLiteral("          <li class=\"page-item active\">\r\n            ");
            EndContext();
            BeginContext(2991, 166, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622121691", async() => {
                BeginContext(3100, 13, false);
#line 120 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                                                                                                                   Write(this_page + 1);

#line default
#line hidden
                EndContext();
                BeginContext(3114, 39, true);
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
#line 120 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
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
            BeginContext(3157, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 122 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"

        }
        else{
          if((i < @ViewBag.Users.count_pages)&&(i >= 0))
          {

#line default
#line hidden
            BeginContext(3275, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(3287, 124, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622125103", async() => {
                BeginContext(3395, 11, false);
#line 127 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
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
#line 127 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
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
            BeginContext(3411, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 128 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
          }
        }

#line default
#line hidden
#line 129 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
         
      }

#line default
#line hidden
#line 130 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
       
      
    }
    else
    {
      

#line default
#line hidden
#line 135 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
       for( int i =  Convert.ToInt32(this_page) - 9 ;
        i < Convert.ToInt32(this_page) + 10; i++)
      {
        
        int nn_page = i;
        
        

#line default
#line hidden
#line 141 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
         if(nn_page == this_page)
        {

#line default
#line hidden
            BeginContext(3685, 53, true);
            WriteLiteral("          <li class=\"page-item active\">\r\n            ");
            EndContext();
            BeginContext(3738, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622129052", async() => {
                BeginContext(3846, 13, false);
#line 144 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                                                                                                                  Write(this_page + 1);

#line default
#line hidden
                EndContext();
                BeginContext(3860, 39, true);
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3903, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 146 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"

        }
        else{
          if((i < @ViewBag.Users.count_pages)&&(i >= 0))
          {

#line default
#line hidden
            BeginContext(4021, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(4033, 124, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622131953", async() => {
                BeginContext(4141, 11, false);
#line 151 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
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
#line 151 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
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
            BeginContext(4157, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 152 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
          }
        }

#line default
#line hidden
#line 153 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
         
      }

#line default
#line hidden
#line 154 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
       


    }

#line default
#line hidden
            BeginContext(4203, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 159 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
     if(next < @ViewBag.Users.count_pages)
    {

#line default
#line hidden
            BeginContext(4256, 34, true);
            WriteLiteral("    <li class=\"page-item\">\r\n      ");
            EndContext();
            BeginContext(4290, 224, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec22fbbcdb162e923e791241b29ec6e5cf9f622135677", async() => {
                BeginContext(4410, 100, true);
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
#line 162 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
                                                                                         WriteLiteral(next);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-numb_page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["numb_page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4514, 13, true);
            WriteLiteral("\r\n    </li>\r\n");
            EndContext();
#line 167 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
    }

#line default
#line hidden
            BeginContext(4534, 19, true);
            WriteLiteral("\r\n  </ul>\r\n</nav>\r\n");
            EndContext();
#line 171 "E:\diploma_project_here\SoftSpace_web\Views\Admin\GiveRole_View.cshtml"
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
