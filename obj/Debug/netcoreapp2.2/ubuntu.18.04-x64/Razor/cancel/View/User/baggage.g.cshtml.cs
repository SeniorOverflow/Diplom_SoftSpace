#pragma checksum "E:\diploma_project_here\SoftSpace_web\cancel\View\User\baggage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77900deb9c457ddd926f3fe4101b4a6ba9e87a51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.cancel_View_User_baggage), @"mvc.1.0.view", @"/cancel/View/User/baggage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/cancel/View/User/baggage.cshtml", typeof(AspNetCore.cancel_View_User_baggage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77900deb9c457ddd926f3fe4101b4a6ba9e87a51", @"/cancel/View/User/baggage.cshtml")]
    public class cancel_View_User_baggage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 303, true);
            WriteLiteral(@"
<th scope=""col""></th>

<td>

           <form method=""post"" asp-controller=""User"" asp-action=""GiveYourFriend""  class=""form_line"">
                    
                    <input type=""hidden"" name=""_id_deal_product"" value=""""/>
                    <button type=""submit""  class=""btn btn-primary"">");
            EndContext();
            BeginContext(304, 27, false);
#line 9 "E:\diploma_project_here\SoftSpace_web\cancel\View\User\baggage.cshtml"
                                                              Write(ViewBag.Translate_words[68]);

#line default
#line hidden
            EndContext();
            BeginContext(331, 43, true);
            WriteLiteral("</button>\r\n            </form>\r\n      </td>");
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
