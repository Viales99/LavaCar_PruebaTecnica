#pragma checksum "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "400c6d67bcc3b1b5a5be0e09521e5ceb79427c23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehiculo_ListaDeVehiculos), @"mvc.1.0.view", @"/Views/Vehiculo/ListaDeVehiculos.cshtml")]
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
#line 1 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\_ViewImports.cshtml"
using LavaCar.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\_ViewImports.cshtml"
using LavaCar.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"400c6d67bcc3b1b5a5be0e09521e5ceb79427c23", @"/Views/Vehiculo/ListaDeVehiculos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a59d7dbfb7031b2316e9c86e750123d12252e8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehiculo_ListaDeVehiculos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LavaCar.Entidades.Vehiculo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app/vehiculoCRUD.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
  LavaCar.Entidades.Vehiculo modelo = new LavaCar.Entidades.Vehiculo();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
  
    ViewData["Title"] = "Lista de Vehículos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card shadow mb-4"">
    <div class=""card-header py-3 text-center"">
        <h2 class=""m-0 font-weight-bold text-secondary""><samp>Lista de Vehículos</samp></h2>
    </div>
    <div class=""card-body"">
        <div class=""mb-3 mx-1"">
            <a href=""#formVehiculo"" id=""btnAgregarVehiculo"" class=""btn btn-success btn-circle btn-lg"" data-toggle=""modal"">
                <span class=""fas fa-plus-circle""></span>
            </a>
        </div>
        <div class=""table-responsive"">
            <table id=""DataTableVehiculos"" class=""table table-striped table-bordered table-borderless"">
                <thead>
                    <tr>
                        <th>");
#nullable restore
#line 22 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
                       Write(Html.DisplayNameFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 23 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
                       Write(Html.DisplayNameFor(model => model.Dueno));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 24 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
                       Write(Html.DisplayNameFor(model => model.Marca));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 25 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
                       Write(Html.DisplayName("Acciones"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    </tr>\r\n                </thead>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 33 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Vehiculo\ListaDeVehiculos.cshtml"
Write(await Html.PartialAsync("_FormularioVehiculo", modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "400c6d67bcc3b1b5a5be0e09521e5ceb79427c236426", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LavaCar.Entidades.Vehiculo>> Html { get; private set; }
    }
}
#pragma warning restore 1591