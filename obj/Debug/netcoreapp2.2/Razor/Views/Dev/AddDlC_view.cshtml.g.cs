#pragma checksum "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0881e236a73a79420578479e7e529f8b015bfe5c0b5fc3af98913c4be9b5f636"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dev_AddDlC_view), @"mvc.1.0.view", @"/Views/Dev/AddDlC_view.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dev/AddDlC_view.cshtml", typeof(AspNetCore.Views_Dev_AddDlC_view))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0881e236a73a79420578479e7e529f8b015bfe5c0b5fc3af98913c4be9b5f636", @"/Views/Dev/AddDlC_view.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a7567d2189ad0d954acaa4c6e3d3b2b6565305a5ce075782787651b828a1d811", @"/Views/_ViewImports.cshtml")]
    public class Views_Dev_AddDlC_view : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dev", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddDLC", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(1, 44, false);
#line 1 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(45, 317, true);
            WriteLiteral(@"
<h1>AddDev</h1>





<table class=""table"">
  <thead class=""thead-light"">
    <tr>
      <th scope=""col"">id</th>
      <th scope=""col"">name of product</th>
      <th scope=""col"">name of company</th>
      <th scope=""col"">category name</th>
      <th scope=""col""></th>
    </tr>
  </thead>
  <tbody>
");
            EndContext();
#line 19 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
 foreach( var a in @ViewBag.AddDlC.dlcs) 
{

#line default
#line hidden
            BeginContext(408, 32, true);
            WriteLiteral("    <tr>\r\n      <th scope=\"row\">");
            EndContext();
            BeginContext(441, 4, false);
#line 22 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
                 Write(a[0]);

#line default
#line hidden
            EndContext();
            BeginContext(445, 17, true);
            WriteLiteral("</th>\r\n      <td>");
            EndContext();
            BeginContext(463, 4, false);
#line 23 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
     Write(a[1]);

#line default
#line hidden
            EndContext();
            BeginContext(467, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(485, 4, false);
#line 24 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
     Write(a[2]);

#line default
#line hidden
            EndContext();
            BeginContext(489, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(507, 4, false);
#line 25 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
     Write(a[3]);

#line default
#line hidden
            EndContext();
            BeginContext(511, 29, true);
            WriteLiteral("</td>\r\n      <td>\r\n          ");
            EndContext();
            BeginContext(540, 284, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0881e236a73a79420578479e7e529f8b015bfe5c0b5fc3af98913c4be9b5f6366607", async() => {
                BeginContext(601, 54, true);
                WriteLiteral("\r\n            <input type =\"hidden\" name=\"_id_product\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 655, "\"", 690, 1);
#line 28 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
WriteAttributeValue(" ", 663, ViewBag.AddDlC.id_product, 664, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(691, 51, true);
                WriteLiteral(">\r\n            <input type =\"hidden\" name=\"_id_dlc\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 742, "\"", 755, 1);
#line 29 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
WriteAttributeValue("", 750, a[0], 750, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(756, 61, true);
                WriteLiteral(">\r\n            <button type=\"submit\">Add</button>\r\n          ");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(824, 26, true);
            WriteLiteral("\r\n      </td>\r\n    </tr>\r\n");
            EndContext();
#line 34 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\AddDlC_view.cshtml"
   
}

#line default
#line hidden
            BeginContext(858, 14, true);
            WriteLiteral("\r\n\r\n</table>\r\n");
            EndContext();
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
