#pragma checksum "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dec9c9a45b6c0e8179f3006d2188f53dd4cf5700"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Reg), @"mvc.1.0.view", @"/Views/Home/Reg.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Reg.cshtml", typeof(AspNetCore.Views_Home_Reg))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dec9c9a45b6c0e8179f3006d2188f53dd4cf5700", @"/Views/Home/Reg.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d30cee2550be9db46aaba39048f361d201242e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Reg : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Reg", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
  
    ViewData["Title"] = "Registration";

#line default
#line hidden
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(51, 44, false);
#line 5 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(95, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
  if(Model == 1)
    {

#line default
#line hidden
            BeginContext(124, 36, true);
            WriteLiteral("        <p>Пароли не совпадают</p>\r\n");
            EndContext();
#line 10 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
    }

#line default
#line hidden
#line 11 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
 if(Model == 2)
    {

#line default
#line hidden
            BeginContext(191, 49, true);
            WriteLiteral("        <p>Данный логин уже зарегистрирован</p>\r\n");
            EndContext();
#line 14 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
    }

#line default
#line hidden
#line 15 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
 if(Model == 3)
    {

#line default
#line hidden
            BeginContext(271, 50, true);
            WriteLiteral("        <p>Данный E-mail уже зарегистрирован</p>\r\n");
            EndContext();
#line 18 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
    }

#line default
#line hidden
#line 19 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
 if(Model == 4)
    {

#line default
#line hidden
            BeginContext(352, 42, true);
            WriteLiteral("        <p>Введите правельно  E-mail</p>\r\n");
            EndContext();
#line 22 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
    }

#line default
#line hidden
            BeginContext(401, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(403, 1381, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dec9c9a45b6c0e8179f3006d2188f53dd4cf57006273", async() => {
                BeginContext(462, 106, true);
                WriteLiteral("\r\n\r\n\r\n\r\n    <div class=\"registration\">\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"mail\">");
                EndContext();
                BeginContext(569, 21, false);
#line 31 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
                         Write(ViewBag.Data_name[30]);

#line default
#line hidden
                EndContext();
                BeginContext(590, 102, true);
                WriteLiteral("</label>\r\n            <input type=\"text\" class=\"form-control\" name=\"_mail\" aria-describedby=\"mailHelp\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 692, "\"", 728, 1);
#line 32 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
WriteAttributeValue("", 706, ViewBag.Data_name[30], 706, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(729, 203, true);
                WriteLiteral(">\r\n            <small id=\"mailHelp\" class=\"form-text text-muted\">We\'ll never share your mail with anyone else.</small>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"login\">");
                EndContext();
                BeginContext(933, 21, false);
#line 37 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
                          Write(ViewBag.Data_name[28]);

#line default
#line hidden
                EndContext();
                BeginContext(954, 104, true);
                WriteLiteral("</label>\r\n            <input type=\"text\" class=\"form-control\" name=\"_login\" aria-describedby=\"loginHelp\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1058, "\"", 1094, 1);
#line 38 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
WriteAttributeValue("", 1072, ViewBag.Data_name[28], 1072, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1095, 208, true);
                WriteLiteral(">\r\n            <small id=\"loginHelp\" class=\"form-text text-muted\">We\'ll never share your login with anyone else.</small>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"password\">");
                EndContext();
                BeginContext(1304, 21, false);
#line 43 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
                             Write(ViewBag.Data_name[29]);

#line default
#line hidden
                EndContext();
                BeginContext(1325, 82, true);
                WriteLiteral("</label>\r\n            <input type=\"password\" class=\"form-control\" name=\"_password\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1407, "\"", 1443, 1);
#line 44 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
WriteAttributeValue("", 1421, ViewBag.Data_name[29], 1421, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1444, 89, true);
                WriteLiteral(">\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"password\">");
                EndContext();
                BeginContext(1534, 21, false);
#line 48 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
                             Write(ViewBag.Data_name[29]);

#line default
#line hidden
                EndContext();
                BeginContext(1555, 83, true);
                WriteLiteral("</label>\r\n            <input type=\"password\" class=\"form-control\" name=\"_password2\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1638, "\"", 1674, 1);
#line 49 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
WriteAttributeValue("", 1652, ViewBag.Data_name[29], 1652, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1675, 69, true);
                WriteLiteral(">\r\n        </div>\r\n  </div>\r\n    \r\n    \r\n\r\n    <button type=\"submit\">");
                EndContext();
                BeginContext(1745, 21, false);
#line 55 "E:\diploma_project_here\SoftSpace_web\Views\Home\Reg.cshtml"
                     Write(ViewBag.Data_name[31]);

#line default
#line hidden
                EndContext();
                BeginContext(1766, 11, true);
                WriteLiteral("</button>\r\n");
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