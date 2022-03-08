#pragma checksum "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b153cf2b08308c76b12e71ca5669dd6314e5b21f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
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
#line 1 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\_ViewImports.cshtml"
using MovieTickets.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b153cf2b08308c76b12e71ca5669dd6314e5b21f", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecf7c47bfdc3aac9156c693582efef788effc3d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Category>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
  
    Layout="~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""hero common-hero"">
	<div class=""container"">
		<div class=""row"">
			<div class=""col-md-12"">
				<div class=""hero-ct"">
					<h1>Category</h1>
					<ul class=""breadcumb"">
						<li class=""active""><a href=""#"">Home</a></li>
						<li> <span class=""ion-ios-arrow-right""></span> movie listing</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</div>
<div class=""page-single"">
	<div class=""container"">
		<div class=""row"">
			<div class=""col-md-12 col-sm-12 col-xs-12"">
				<div class=""topbar-filter fw "">
					
					
					<a onclick=""getList()"" class=""list "" ><i class=""ion-ios-list-outline ""></i></a>
					<a  onclick=""getData()"" class=""grid"" ><i class=""ion-grid ""></i></a>
				</div>
					<div id=""div1"">
                       <div class=""col-md-8 col-sm-12 col-xs-12"">
");
#nullable restore
#line 32 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
     foreach(var item in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("    \t<div class=\"movie-item-style-2\">\r\n");
#nullable restore
#line 34 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
                 if(item.Image!=null){
				var base64 = Convert.ToBase64String(@item.Image);
      var imgsrc = string.Format("data:images/*;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 1120, "\"", 1133, 1);
#nullable restore
#line 37 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
WriteAttributeValue("", 1126, imgsrc, 1126, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1134, "\"", 1140, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 38 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<div class=\"mv-item-infor\">\r\n\t\t\t\t\t\t<h6>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b153cf2b08308c76b12e71ca5669dd6314e5b21f6314", async() => {
#nullable restore
#line 40 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
                                                                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h6>\r\n\t\t\t\t\t\t<p class=\"describe\">");
#nullable restore
#line 41 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
                                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n");
#nullable restore
#line 44 "D:\MVCProject\Movie_Ticket_Reservation\MovieTickets\Views\Category\Index.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
                    </div>	
			</div>
		</div>
		</div>
	</div>

<script>
   function getData(){
        
        
        $.ajax(
            {
                url: ""/Category/Grid"",//?stdid=""+id,
                 
                success: function(result){
					
                   // console.log(result);
                // alert(result);
                //document.getElementById(""div1"").innerHTML=result;
                    $(""#div1"").html(result);//dom
                }
            }
         );
    }
	
	 function getList(){
        $.ajax(
            {
                url: ""/Category/List"",//?stdid=""+id,
                
                success: function(result){
					
                   // console.log(result);
                // alert(result);
                //document.getElementById(""div1"").innerHTML=result;
                    $(""#div1"").html(result);//dom
                }
            }
         );
    }
	</script>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n<!--JQuery PAckage -->\r\n \r\n    <script src=\"/lib/jquery-validation/dist/jquery.validate.min.js\"></script>\r\n    <script src=\"/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js\"></script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
