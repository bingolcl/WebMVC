#pragma checksum "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6e77564d6da73bbb5649de51df63cfe69c55d51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FilterProperties_Default), @"mvc.1.0.view", @"/Views/Shared/Components/FilterProperties/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FilterProperties/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_FilterProperties_Default))]
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
#line 1 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\_ViewImports.cshtml"
using CPRG102.Properties.App;

#line default
#line hidden
#line 2 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\_ViewImports.cshtml"
using CPRG102.Properties.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6e77564d6da73bbb5649de51df63cfe69c55d51", @"/Views/Shared/Components/FilterProperties/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69f06b3481c74fe3b1e0db33d7f6d966a4ebdb94", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FilterProperties_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CPRG102.Properties.App.Models.FilteredRentalViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 86, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(162, 43, false);
#line 7 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(205, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(261, 40, false);
#line 10 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(301, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(357, 44, false);
#line 13 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Province));

#line default
#line hidden
            EndContext();
            BeginContext(401, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(457, 46, false);
#line 16 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(503, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(559, 40, false);
#line 19 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(599, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(655, 41, false);
#line 22 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Style));

#line default
#line hidden
            EndContext();
            BeginContext(696, 75, true);
            WriteLiteral("\r\n            </th>            \r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 27 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(803, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(852, 42, false);
#line 30 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(894, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(950, 39, false);
#line 33 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(989, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1045, 43, false);
#line 36 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Province));

#line default
#line hidden
            EndContext();
            BeginContext(1088, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1144, 45, false);
#line 39 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1189, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1245, 39, false);
#line 42 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(1284, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1340, 40, false);
#line 45 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Style));

#line default
#line hidden
            EndContext();
            BeginContext(1380, 48, true);
            WriteLiteral("\r\n            </td>            \r\n        </tr>\r\n");
            EndContext();
#line 48 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Shared\Components\FilterProperties\Default.cshtml"
}

#line default
#line hidden
            BeginContext(1431, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CPRG102.Properties.App.Models.FilteredRentalViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
