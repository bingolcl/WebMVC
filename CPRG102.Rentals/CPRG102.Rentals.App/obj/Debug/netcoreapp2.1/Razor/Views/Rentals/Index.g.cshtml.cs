#pragma checksum "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b50362c3a6f47fbe9024fed31ffc269d3bc8873"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rentals_Index), @"mvc.1.0.view", @"/Views/Rentals/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Rentals/Index.cshtml", typeof(AspNetCore.Views_Rentals_Index))]
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
#line 1 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\_ViewImports.cshtml"
using CPRG102.Rentals.App;

#line default
#line hidden
#line 2 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\_ViewImports.cshtml"
using CPRG102.Rentals.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b50362c3a6f47fbe9024fed31ffc269d3bc8873", @"/Views/Rentals/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a65a8392abe683e7b2ec9dcfabab2d3200f9d543", @"/Views/_ViewImports.cshtml")]
    public class Views_Rentals_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CPRG102.Rentals.Domain.RentalProperty>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(102, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(131, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b31d1b46694448594fb5e9819760c1b", async() => {
                BeginContext(154, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(168, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(261, 38, false);
#line 16 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.id));

#line default
#line hidden
            EndContext();
            BeginContext(299, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(355, 43, false);
#line 19 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(398, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(454, 40, false);
#line 22 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(494, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(550, 44, false);
#line 25 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Province));

#line default
#line hidden
            EndContext();
            BeginContext(594, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(650, 46, false);
#line 28 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(696, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(752, 40, false);
#line 31 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(792, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 37 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(910, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(959, 37, false);
#line 40 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.id));

#line default
#line hidden
            EndContext();
            BeginContext(996, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1052, 42, false);
#line 43 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(1094, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1150, 39, false);
#line 46 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(1189, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1245, 43, false);
#line 49 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Province));

#line default
#line hidden
            EndContext();
            BeginContext(1288, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1344, 45, false);
#line 52 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1389, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1445, 39, false);
#line 55 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(1484, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1540, 65, false);
#line 58 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1605, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1626, 55, false);
#line 59 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new {id=item.id}));

#line default
#line hidden
            EndContext();
            BeginContext(1681, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1702, 69, false);
#line 60 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1771, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 63 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Rentals\CPRG102.Rentals.App\Views\Rentals\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1810, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CPRG102.Rentals.Domain.RentalProperty>> Html { get; private set; }
    }
}
#pragma warning restore 1591
