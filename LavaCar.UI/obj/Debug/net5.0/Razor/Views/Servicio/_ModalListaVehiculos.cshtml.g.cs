#pragma checksum "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Servicio\_ModalListaVehiculos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94c5c399b555fb8ca4da6bec625bc4df9b3d7c77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Servicio__ModalListaVehiculos), @"mvc.1.0.view", @"/Views/Servicio/_ModalListaVehiculos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94c5c399b555fb8ca4da6bec625bc4df9b3d7c77", @"/Views/Servicio/_ModalListaVehiculos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a59d7dbfb7031b2316e9c86e750123d12252e8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Servicio__ModalListaVehiculos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LavaCar.Entidades.Vehiculo>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- Modal -->
<div id=""modalVehiculos"" class=""modal fade"" role=""document"" data-backdrop=""static"" data-keyboard=""false"">
    <div class=""modal-dialog modal-lg modal-dialog-centered modal-dialog-scrollable"">

        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""text-right mt-2 mr-3"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <div id=""ContenidoVehiculos"">

                    <div class=""card shadow mb-4"">
                        <div class=""card-header py-3 text-center"">
                            <h2 class=""m-0 font-weight-bold text-secondary""><samp>Veh??culos asignados a <span id=""VehiculoTitulo""></span></samp></h2>

                        </div>
                        <div class=""card-body"">
                            <div class=""table-responsive"">
                                <table id=""DataTableModalVehiculos"" class=""table t");
            WriteLiteral("able-striped table-bordered table-borderless\">\r\n                                    <thead>\r\n                                        <tr>\r\n                                            <th>");
#nullable restore
#line 25 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Servicio\_ModalListaVehiculos.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 26 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Servicio\_ModalListaVehiculos.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Dueno));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 27 "C:\Users\josec\source\repos\LavaCar\LavaCar.UI\Views\Servicio\_ModalListaVehiculos.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Marca));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""modal-footer justify-content-center"">
            </div>
        </div>

    </div>
</div>
");
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
