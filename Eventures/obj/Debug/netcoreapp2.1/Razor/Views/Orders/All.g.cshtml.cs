#pragma checksum "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64aa0115d626f35433e5d96032f0ea0911daefff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_All), @"mvc.1.0.view", @"/Views/Orders/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/All.cshtml", typeof(AspNetCore.Views_Orders_All))]
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
#line 1 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\_ViewImports.cshtml"
using Eventures;

#line default
#line hidden
#line 2 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\_ViewImports.cshtml"
using Eventures.Models;

#line default
#line hidden
#line 3 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\_ViewImports.cshtml"
using Eventures.ViewModels.EventViewModels;

#line default
#line hidden
#line 2 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
using Eventures.ViewModels.OrderViewModels;

#line default
#line hidden
#line 5 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\_ViewImports.cshtml"
using Eventures.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64aa0115d626f35433e5d96032f0ea0911daefff", @"/Views/Orders/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5084f1253277c1e819aef4ef11a83859c3f9e9bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OrderViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(82, 619, true);
            WriteLiteral(@"
<div class=""mx-auto col-md-11"">
    <h1 class=""text-center"">All Orders</h1>
    <hr class=""hr-eventures-blue""/>
    <div class=""d-flex justify-content-between"">
        <table class=""table"">
            <thead>
                <tr class=""row"">
                    <th scope=""col"" class=""col-lg-1""><h5>#</h5></th>
                    <th scope=""col"" class=""col-lg-4""><h5>Event</h5></th>
                    <th scope=""col"" class=""col-lg-3""><h5>Customer</h5></th>
                    <th scope=""col"" class=""col-lg-4""><h5>Ordered On</h5></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 18 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
                 for (int i = 0; i < Model.Count(); i++)
                {
                    var order = Model.ToList()[i];


#line default
#line hidden
            BeginContext(832, 75, true);
            WriteLiteral("                <tr class=\"row\">\r\n                    <td class=\"col-lg-1\">");
            EndContext();
            BeginContext(909, 5, false);
#line 23 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
                                     Write(i + 1);

#line default
#line hidden
            EndContext();
            BeginContext(915, 48, true);
            WriteLiteral("</td>\r\n                    <td class=\"col-lg-4\">");
            EndContext();
            BeginContext(964, 15, false);
#line 24 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
                                    Write(order.EventName);

#line default
#line hidden
            EndContext();
            BeginContext(979, 48, true);
            WriteLiteral("</td>\r\n                    <td class=\"col-lg-3\">");
            EndContext();
            BeginContext(1028, 14, false);
#line 25 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
                                    Write(order.Customer);

#line default
#line hidden
            EndContext();
            BeginContext(1042, 48, true);
            WriteLiteral("</td>\r\n                    <td class=\"col-lg-4\">");
            EndContext();
            BeginContext(1091, 15, false);
#line 26 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
                                    Write(order.OrderedOn);

#line default
#line hidden
            EndContext();
            BeginContext(1106, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 28 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Orders\All.cshtml"
                }

#line default
#line hidden
            BeginContext(1155, 58, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
