#pragma checksum "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "28463c77547981af5e7fdbc1f9ee73cf8cd6fb2857402ab4e8f95aedf2e87941"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"28463c77547981af5e7fdbc1f9ee73cf8cd6fb2857402ab4e8f95aedf2e87941", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a7567d2189ad0d954acaa4c6e3d3b2b6565305a5ce075782787651b828a1d811", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(1, 44, false);
#line 1 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\User\Index.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(45, 20, true);
            WriteLiteral("\r\n<h1>UserIndex</h1>");
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
