#pragma checksum "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dddf422d9a83a6f1a743a8e0009c0f131dcf981"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_MyEvents), @"mvc.1.0.view", @"/Views/Events/MyEvents.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Events/MyEvents.cshtml", typeof(AspNetCore.Views_Events_MyEvents))]
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
#line 4 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\_ViewImports.cshtml"
using Eventures.ViewModels.OrderViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dddf422d9a83a6f1a743a8e0009c0f131dcf981", @"/Views/Events/MyEvents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f91aa7b99a0a32c006563d0f8f8816e27e70b6a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_MyEvents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyEventViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
  
    ViewData["Title"] = "MyEvents";

#line default
#line hidden
            BeginContext(84, 687, true);
            WriteLiteral(@"

<div class=""mx-auto col-md-11"">
    <h1 class=""text-center"">All Events</h1>
    <hr class=""hr-eventures-blue"" />
    <div class=""d-flex justify-content-between"">
        <table class=""table"">
            <thead>
                <tr class=""row"">
                    <th scope=""col"" class=""col-lg-1""><h5>#</h5></th>
                    <th scope=""col"" class=""col-lg-3""><h5>Name</h5></th>
                    <th scope=""col"" class=""col-lg-3""><h5>Start</h5></th>
                    <th scope=""col"" class=""col-lg-3""><h5>End</h5></th>
                    <th scope=""col"" class=""col-lg-2""><h5>Tickets</h5></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 23 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                 for (int i = 0; i < Model.Count(); i++)
                {

                    var order = Model.ToList()[i];


#line default
#line hidden
            BeginContext(904, 83, true);
            WriteLiteral("                    <tr class=\"row\">\r\n                        <td class=\"col-lg-1\">");
            EndContext();
            BeginContext(989, 5, false);
#line 29 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                                         Write(i + 1);

#line default
#line hidden
            EndContext();
            BeginContext(995, 52, true);
            WriteLiteral("</td>\r\n                        <td class=\"col-lg-3\">");
            EndContext();
            BeginContext(1048, 10, false);
#line 30 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                                        Write(order.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1058, 52, true);
            WriteLiteral("</td>\r\n                        <td class=\"col-lg-3\">");
            EndContext();
            BeginContext(1111, 11, false);
#line 31 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                                        Write(order.Start);

#line default
#line hidden
            EndContext();
            BeginContext(1122, 52, true);
            WriteLiteral("</td>\r\n                        <td class=\"col-lg-3\">");
            EndContext();
            BeginContext(1175, 9, false);
#line 32 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                                        Write(order.End);

#line default
#line hidden
            EndContext();
            BeginContext(1184, 52, true);
            WriteLiteral("</td>\r\n                        <td class=\"col-lg-2\">");
            EndContext();
            BeginContext(1237, 13, false);
#line 33 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                                        Write(order.Tickets);

#line default
#line hidden
            EndContext();
            BeginContext(1250, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 35 "C:\Users\s2k\source\repos\PandaStorage\Eventures\Views\Events\MyEvents.cshtml"
                }

#line default
#line hidden
            BeginContext(1303, 62, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyEventViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591