#pragma checksum "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4780e114639c997b5ad3bd9a367f31106108c13d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reserva_Delete), @"mvc.1.0.view", @"/Views/Reserva/Delete.cshtml")]
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
#line 1 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\_ViewImports.cshtml"
using PROYECTO_TP_PNT1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\_ViewImports.cshtml"
using PROYECTO_TP_PNT1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4780e114639c997b5ad3bd9a367f31106108c13d", @"/Views/Reserva/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b1836b25d7c5111e4c4118d98a987841799b923", @"/Views/_ViewImports.cshtml")]
    public class Views_Reserva_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PROYECTO_TP_PNT1.Models.Reserva>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn bg-dark boton-volver"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("botones-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\" id=\"detalles\">\r\n    <h1 class=\"titulo-cliente\">ELIMINAR RESERVA</h1>\r\n    <hr />\r\n    <div>\r\n        <dl class=\"row\" id=\"detalle-row\">\r\n            <dt class=\"col-sm-5\">\r\n              -  ");
#nullable restore
#line 13 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
            Write(Html.DisplayNameFor(model => model.entrada));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :\r\n            </dt>\r\n            <dd class=\"col-sm-5\">\r\n                ");
#nullable restore
#line 16 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
           Write(Html.DisplayFor(model => model.entrada));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n            </dd>\r\n            <dt class=\"col-sm-5\">\r\n               - ");
#nullable restore
#line 19 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
            Write(Html.DisplayNameFor(model => model.salida));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :\r\n            </dt>\r\n            <dd class=\"col-sm-5\">\r\n                ");
#nullable restore
#line 22 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
           Write(Html.DisplayFor(model => model.salida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            \r\n\r\n            <dt class=\"col-sm-5\">\r\n              -  ");
#nullable restore
#line 27 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
            Write(Html.DisplayNameFor(model => model.desayuno));

#line default
#line hidden
#nullable disable
            WriteLiteral("  :\r\n            </dt>\r\n            <dd class=\"col-sm-5\">\r\n                ");
#nullable restore
#line 30 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
           Write(Html.DisplayFor(model => model.desayuno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-5\">\r\n              -  ");
#nullable restore
#line 33 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
            Write(Html.DisplayNameFor(model => model.cantPersonas));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :\r\n            </dt>\r\n            <dd class=\"col-sm-5\">\r\n                ");
#nullable restore
#line 36 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
           Write(Html.DisplayFor(model => model.cantPersonas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-5\">\r\n              -  ");
#nullable restore
#line 39 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
            Write(Html.DisplayNameFor(model => model.CantHabitaciones));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :\r\n            </dt>\r\n            <dd class=\"col-sm-5\">\r\n                ");
#nullable restore
#line 42 "C:\Users\Itris\Desktop\DEFENSA TP\VERSION28\VERSION28\PROYECTO_TP_PNT1\Views\Reserva\Delete.cshtml"
           Write(Html.DisplayFor(model => model.CantHabitaciones));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4780e114639c997b5ad3bd9a367f31106108c13d8806", async() => {
                WriteLiteral("\r\n               \r\n                <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-danger bg-danger\" /> \r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4780e114639c997b5ad3bd9a367f31106108c13d9199", async() => {
                    WriteLiteral("Volver");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </dl>\r\n\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PROYECTO_TP_PNT1.Models.Reserva> Html { get; private set; }
    }
}
#pragma warning restore 1591
