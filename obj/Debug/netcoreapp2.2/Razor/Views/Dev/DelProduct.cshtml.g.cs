#pragma checksum "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\DelProduct.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b910987af0a91d0ede6ca3c258ddf15dc79613857faee4055be0d566027a09e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dev_DelProduct), @"mvc.1.0.view", @"/Views/Dev/DelProduct.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dev/DelProduct.cshtml", typeof(AspNetCore.Views_Dev_DelProduct))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b910987af0a91d0ede6ca3c258ddf15dc79613857faee4055be0d566027a09e4", @"/Views/Dev/DelProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a7567d2189ad0d954acaa4c6e3d3b2b6565305a5ce075782787651b828a1d811", @"/Views/_ViewImports.cshtml")]
    public class Views_Dev_DelProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(1, 44, false);
#line 1 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\DelProduct.cshtml"
Write(await Component.InvokeAsync("Menu" , new {}));

#line default
#line hidden
            EndContext();
            BeginContext(45, 34, true);
            WriteLiteral("\r\n<h1>you delete your product ^_^ ");
            EndContext();
            BeginContext(80, 5, false);
#line 2 "C:\Users\DonEn\Documents\GitHub\Diplom_SoftSpace\Views\Dev\DelProduct.cshtml"
                           Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(85, 5, true);
            WriteLiteral("</h1>");
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
