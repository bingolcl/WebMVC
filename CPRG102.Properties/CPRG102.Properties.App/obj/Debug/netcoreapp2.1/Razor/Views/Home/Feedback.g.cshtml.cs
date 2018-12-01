#pragma checksum "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Home\Feedback.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae2d872dd5894b80c25ac8ed9c5c4a14cee487f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Feedback), @"mvc.1.0.view", @"/Views/Home/Feedback.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Feedback.cshtml", typeof(AspNetCore.Views_Home_Feedback))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae2d872dd5894b80c25ac8ed9c5c4a14cee487f8", @"/Views/Home/Feedback.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69f06b3481c74fe3b1e0db33d7f6d966a4ebdb94", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Feedback : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Home\Feedback.cshtml"
  
    var a = ViewData["a"];
    var b = ViewData["b"];
    var c = ViewData["c"];

#line default
#line hidden
            BeginContext(91, 17, true);
            WriteLiteral("\r\n<h2>Feedback - ");
            EndContext();
            BeginContext(109, 1, false);
#line 7 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Home\Feedback.cshtml"
          Write(a);

#line default
#line hidden
            EndContext();
            BeginContext(110, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(114, 1, false);
#line 7 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Home\Feedback.cshtml"
               Write(b);

#line default
#line hidden
            EndContext();
            BeginContext(115, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(119, 1, false);
#line 7 "C:\Users\689438\Documents\GitHub\WebMVC\CPRG102.Properties\CPRG102.Properties.App\Views\Home\Feedback.cshtml"
                    Write(c);

#line default
#line hidden
            EndContext();
            BeginContext(120, 496, true);
            WriteLiteral(@"</h2>

<table class=""table table-bordered"">
    <tr>
        <td>Full Name:</td>
        <td><input type=""text"" id=""uxName"" value="""" /></td>
    </tr>
    <tr>
        <td>Province:</td>
        <td><select id=""uxProvinces"" /></td>
    </tr>
    <tr>
        <td>Comments:</td>
        <td><textarea id=""uxComment"" rows=""4""></textarea></td>
    </tr>
</table>

<button class=""btn btn-success"" id=""uxSubmitComments"">Submit Comments</button>

<div id=""uxFilteredTypes""></div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(634, 1255, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        var provinces = new Array(""BC"", ""AB"", ""SK"", ""MB"", ""ON"");
        function poplulateProvinces() {
            var dropDown = document.getElementById(""uxProvinces"");
            $.each(provinces, function (index, prov) {
                var option = new Option(prov, prov);
                dropDown.append(option);
                //dropDown.options[dropDown.length] = new Option(prov,prov);
            });
        };
        function processComments() {
            alert(""submit"");
            

            var id = 0;
            $.ajax({
                method: 'GET',
                url: '/Rentals/GetFilteredProperties',
                data: { id: id }
            }).done(function (result, statusText, xhdr) {
                $(""#uxFilteredTypes"").html(result);
            }).fail(function (xhdr, statusText, errorText) {
                $(""#uxFilteredTypes"").html(JSON.stringify(xhdr));
            })
        };
        $(document).ready(fun");
                WriteLiteral("ction(){\r\n            //alert(\"dom ready\");\r\n            poplulateProvinces();\r\n            $(\'#uxSubmitComments\').click(function () {\r\n                processComments();\r\n\r\n            });\r\n        });\r\n\r\n        \r\n    </script>\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
