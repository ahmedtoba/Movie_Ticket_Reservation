#pragma checksum "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b68dd4dcf1ae6385f6e4d870a9d24713d9ca2284"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Actor_DetailsUser), @"mvc.1.0.view", @"/Views/Actor/DetailsUser.cshtml")]
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
#line 1 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b68dd4dcf1ae6385f6e4d870a9d24713d9ca2284", @"/Views/Actor/DetailsUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"079eb81a01d1a792c4bbac455db6644dedc4b68f", @"/Views/_ViewImports.cshtml")]
    public class Views_Actor_DetailsUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Actor>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
  
    Layout="~/Views/Shared/_UserLayout.cshtml";
	
		var base64 = "";
		string imgsrc ;
	

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""hero hero3"">
	<div class=""container"">
		<div class=""row"">
			<div class=""col-md-12"">
				<!-- <h1> movie listing - list</h1>
				<ul class=""breadcumb"">
					<li class=""active""><a href=""#"">Home</a></li>
					<li> <span class=""ion-ios-arrow-right""></span> movie listing</li>
				</ul> -->
			</div>
		</div>
	</div>
</div>
<!-- celebrity single section-->

<div class=""page-single movie-single cebleb-single"">
	<div class=""container"">
		<div class=""row ipad-width"">
			<div class=""col-md-4 col-sm-12 col-xs-12"">
				<div class=""mv-ceb"">
");
#nullable restore
#line 30 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
                      base64=	Convert.ToBase64String(@Model.Image);
                imgsrc= string.Format("data:images/*;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 824, "\"", 837, 1);
#nullable restore
#line 32 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
WriteAttributeValue("", 830, imgsrc, 830, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 838, "\"", 844, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<div class=\"col-md-8 col-sm-12 col-xs-12\">\r\n\t\t\t\t<div class=\"movie-single-ct\">\r\n\t\t\t\t\t<h1 class=\"bd-hd\">");
#nullable restore
#line 37 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
					<p class=""ceb-single"" >Actor </p>
					<div class=""social-link cebsingle-socail"" hidden>
						<a href=""#""><i class=""ion-social-facebook""></i></a>
						<a href=""#""><i class=""ion-social-twitter""></i></a>
						<a href=""#""><i class=""ion-social-googleplus""></i></a>
						<a href=""#""><i class=""ion-social-linkedin""></i></a>
					</div>
					<div class=""movie-tabs"">
						<div class=""tabs"">
							<div class=""tabs"">
							<ul class=""tab-links tabs-mv"">
								<li class=""active""><a href=""#overviewceb"">Overview</a></li>
								                      
							</ul>
						    <div class=""tab-content"">
						        <div id=""overviewceb"" class=""tab active"">
						            <div class=""row"">
						            	<div class=""col-md-8 col-sm-12 col-xs-12"">
						            		<p>");
#nullable restore
#line 56 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
                                          Write(Model.Bio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t            \t\r\n\t\t\t\t\t\t\t\t\t\t\t<!-- movie cast -->\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"mvcast-item\">\t\r\n");
#nullable restore
#line 60 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
                                                 foreach(var item in Model.MovieActors){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"cast-it\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"cast-left cebleb-film\">\r\n");
#nullable restore
#line 63 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
                                                          base64=	Convert.ToBase64String(@item.Movie.Image);
                                                imgsrc= string.Format("data:images/*;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 2237, "\"", 2250, 1);
#nullable restore
#line 65 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
WriteAttributeValue("", 2243, imgsrc, 2243, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  style=\"width:40px \">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<a href=\"#\">");
#nullable restore
#line 67 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
                                                                   Write(item.Movie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 74 "D:\itiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii\c#\MVC\github\Movie_Ticket_Reservation\MovieTickets\Views\Actor\DetailsUser.cshtml"
												}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t            \t</div>\r\n\t\t\t\t\t\t            \r\n\t\t\t\t\t\t            </div>\r\n\r\n\t\t\t\t\t\t    </div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\t</div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Actor> Html { get; private set; }
    }
}
#pragma warning restore 1591
