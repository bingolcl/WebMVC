#pragma checksum "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ee31c9d09b45cede8e892ea8cd42ac6ff63efe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rentals_Details), @"mvc.1.0.view", @"/Views/Rentals/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Rentals/Details.cshtml", typeof(AspNetCore.Views_Rentals_Details))]
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
#line 1 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\_ViewImports.cshtml"
using CPRG102.Rentals.App;

#line default
#line hidden
#line 2 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\_ViewImports.cshtml"
using CPRG102.Rentals.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ee31c9d09b45cede8e892ea8cd42ac6ff63efe4", @"/Views/Rentals/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a65a8392abe683e7b2ec9dcfabab2d3200f9d543", @"/Views/_ViewImports.cshtml")]
    public class Views_Rentals_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CPRG102.Rentals.Domain.RentalProperty>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(91, 128, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>RentalProperty</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(220, 38, false);
#line 14 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(258, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(302, 34, false);
#line 17 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(336, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(380, 43, false);
#line 20 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(423, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(467, 39, false);
#line 23 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(506, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(550, 40, false);
#line 26 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(590, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(634, 36, false);
#line 29 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(670, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(714, 44, false);
#line 32 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Province));

#line default
#line hidden
            EndContext();
            BeginContext(758, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(802, 40, false);
#line 35 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayFor(model => model.Province));

#line default
#line hidden
            EndContext();
            BeginContext(842, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(886, 46, false);
#line 38 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(932, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(976, 42, false);
#line 41 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1018, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1062, 40, false);
#line 44 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(1102, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1146, 36, false);
#line 47 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
       Write(Html.DisplayFor(model => model.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(1182, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1230, 68, false);
#line 52 "C:\Users\lisaz\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1298, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1306, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7066fc7026684c92a5e429f00ea2b698", async() => {
                BeginContext(1328, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1344, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CPRG102.Rentals.Domain.RentalProperty> Html { get; private set; }
    }
}
#pragma warning restore 1591
