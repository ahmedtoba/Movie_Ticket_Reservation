#pragma checksum "C:\GraduationProject\MovieTickets\Views\Cinema\CinemaDetailsAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9a5436812de343cb9a5ed7c5aa7c707527c5b27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cinema_CinemaDetailsAdmin), @"mvc.1.0.view", @"/Views/Cinema/CinemaDetailsAdmin.cshtml")]
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
#nullable restore
#line 1 "C:\GraduationProject\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GraduationProject\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GraduationProject\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9a5436812de343cb9a5ed7c5aa7c707527c5b27", @"/Views/Cinema/CinemaDetailsAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"079eb81a01d1a792c4bbac455db6644dedc4b68f", @"/Views/_ViewImports.cshtml")]
    public class Views_Cinema_CinemaDetailsAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Cinema>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\GraduationProject\MovieTickets\Views\Cinema\CinemaDetailsAdmin.cshtml"
  
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card mb-3\" style=\"max-width: 540px;\">\r\n  <div class=\"row no-gutters\">\r\n    <div class=\"col-md-4\">\r\n      <img");
            BeginWriteAttribute("src", " src=\"", 175, "\"", 193, 1);
#nullable restore
#line 9 "C:\GraduationProject\MovieTickets\Views\Cinema\CinemaDetailsAdmin.cshtml"
WriteAttributeValue("", 181, Model.Image, 181, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    </div>\r\n    <div class=\"col-md-8\">\r\n      <div class=\"card-body\">\r\n        <h5 class=\"card-title\">");
#nullable restore
#line 13 "C:\GraduationProject\MovieTickets\Views\Cinema\CinemaDetailsAdmin.cshtml"
                          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">");
#nullable restore
#line 14 "C:\GraduationProject\MovieTickets\Views\Cinema\CinemaDetailsAdmin.cshtml"
                        Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cinema> Html { get; private set; }
    }
}
#pragma warning restore 1591
