#pragma checksum "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10a44ad7226af34828ff85674a9e6319a4887f8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FilterAssets_Default), @"mvc.1.0.view", @"/Views/Shared/Components/FilterAssets/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/FilterAssets/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_FilterAssets_Default))]
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
#line 1 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\_ViewImports.cshtml"
using AssetTracking.App;

#line default
#line hidden
#line 2 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\_ViewImports.cshtml"
using AssetTracking.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10a44ad7226af34828ff85674a9e6319a4887f8a", @"/Views/Shared/Components/FilterAssets/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"022340f82a0735c6049e2e952716d4053e486086", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FilterAssets_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AssetTracking.App.Models.AssetListViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 108, true);
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(174, 47, false);
#line 7 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(221, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(289, 40, false);
#line 10 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(329, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(397, 45, false);
#line 13 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.TagNumber));

#line default
#line hidden
            EndContext();
            BeginContext(442, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(510, 48, false);
#line 16 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.SerialNumber));

#line default
#line hidden
            EndContext();
            BeginContext(558, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(626, 44, false);
#line 19 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.AssignTo));

#line default
#line hidden
            EndContext();
            BeginContext(670, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(738, 46, false);
#line 22 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.Department));

#line default
#line hidden
            EndContext();
            BeginContext(784, 67, true);
            WriteLiteral("\r\n                </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 27 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(883, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(932, 46, false);
#line 30 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(978, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1034, 39, false);
#line 33 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1073, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1129, 44, false);
#line 36 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.TagNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1173, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1229, 47, false);
#line 39 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.SerialNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1276, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1332, 43, false);
#line 42 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.AssignTo));

#line default
#line hidden
            EndContext();
            BeginContext(1375, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1431, 45, false);
#line 45 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Department));

#line default
#line hidden
            EndContext();
            BeginContext(1476, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 48 "C:\Users\czhang\Documents\GitHub\WebMVC\AssetTracking\AssetTracking.App\Views\Shared\Components\FilterAssets\Default.cshtml"
}

#line default
#line hidden
            BeginContext(1515, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AssetTracking.App.Models.AssetListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591