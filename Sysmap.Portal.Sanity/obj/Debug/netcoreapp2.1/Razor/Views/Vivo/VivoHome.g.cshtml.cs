#pragma checksum "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c12fb08658c7afba5766c5c186f162fc58dfdb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vivo_VivoHome), @"mvc.1.0.view", @"/Views/Vivo/VivoHome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vivo/VivoHome.cshtml", typeof(AspNetCore.Views_Vivo_VivoHome))]
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
#line 1 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\_ViewImports.cshtml"
using Sysmap.Portal.Sanity;

#line default
#line hidden
#line 2 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\_ViewImports.cshtml"
using Sysmap.Portal.Sanity.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c12fb08658c7afba5766c5c186f162fc58dfdb6", @"/Views/Vivo/VivoHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba5c1b23f338b860c1a91e839c988a3c801039bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Vivo_VivoHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Sysmap.Portal.Sanity.Models.VivoRelease>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CenariosVivo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vivo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HistoricoReleaseVivo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AtualizaReleaseVivo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
  
    ViewData["Title"] = "Home - Vivo";

#line default
#line hidden
            BeginContext(95, 84, true);
            WriteLiteral("\r\n<h2 style=\"text-align:center;\">Plataforma Vivo</h2>\r\n<br />\r\n\r\n<div class=\"row\">\r\n");
            EndContext();
#line 10 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
     if (ViewBag.ReleaseAtiva)
    {

#line default
#line hidden
            BeginContext(218, 121, true);
            WriteLiteral("        <div class=\"col-md-4\">\r\n            <div class=\"card\">\r\n                <h5 class=\"card-header\"> Release Codigo: ");
            EndContext();
            BeginContext(340, 16, false);
#line 14 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                                                    Write(Model.CodRelease);

#line default
#line hidden
            EndContext();
            BeginContext(356, 186, true);
            WriteLiteral("</h5>\r\n                <div class=\"card-body\">\r\n                    <h4 class=\"card-title\">Informações:</h4>\r\n                    <p><i class=\"fas fa-calendar-day\"></i> Data da Release: ");
            EndContext();
            BeginContext(543, 37, false);
#line 17 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                                                                       Write(Model.DataRelease.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(580, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 18 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                     if (!User.IsInRole("Vivo-User"))
                    {

#line default
#line hidden
            BeginContext(664, 141, true);
            WriteLiteral("                        <a class=\"\" data-toggle=\"modal\" data-target=\"#exampleModal\" href=\"#\"><i class=\"fas fa-edit\"></i> Alterar Status</a>\r\n");
            EndContext();
#line 21 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                    }

#line default
#line hidden
            BeginContext(828, 22, true);
            WriteLiteral("                    | ");
            EndContext();
            BeginContext(850, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b8d9f639cd20491ca25312115bd9508a", async() => {
                BeginContext(901, 50, true);
                WriteLiteral("Cenarios <i class=\"fas fa-angle-double-right\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(955, 117, true);
            WriteLiteral("\r\n                </div> <!-- end card-body-->\r\n            </div> <!-- end card-->\r\n        </div> <!-- end col-->\r\n");
            EndContext();
#line 26 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
    }

#line default
#line hidden
            BeginContext(1079, 321, true);
            WriteLiteral(@"        <div class=""col-md-4"">
            <div class=""card"">
                <div class=""card-header"">
                    Hitorico de release
                </div>
                <div class=""card-body"">
                    <p>Pesquisar release criadas/feitas a partir do mês de Agosto </p>
                    ");
            EndContext();
            BeginContext(1400, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a607f5ec467449d944d909aef92cd3f", async() => {
                BeginContext(1446, 39, true);
                WriteLiteral("<i class=\"fas fa-search\"></i> Pesquisar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1489, 606, true);
            WriteLiteral(@"
                </div> <!-- end card-body-->
            </div> <!-- end card-->
        </div> <!-- end col-->

        <div class=""col-md-4"">
            <div class=""card text-xs-center"">
                <div class=""card-header"">
                    Criar Nova Release
                </div>
                <div class=""card-body"">
                    <h5 class=""card-title"">Atenção!!</h5>
                    <p>Só será possivel criar uma nova release caso todas as outras releases ja tenham sido feitas e alteradas o status para ""Executada"".</p>
                    <!-- Small modal -->
");
            EndContext();
#line 48 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                     if (ViewBag.ReleaseAtiva)
                    {

                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2240, 136, true);
            WriteLiteral("                        <a href=\"#\" class=\"\" data-toggle=\"modal\" data-target=\"#info-alert-modal\"><i class=\"fas fa-plus\"></i> Criar</a>\r\n");
            EndContext();
#line 55 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                    }

#line default
#line hidden
            BeginContext(2399, 119, true);
            WriteLiteral("                </div>\r\n            </div> <!-- end card-->\r\n        </div> <!-- end col-->\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
#line 67 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
 if (ViewBag.ReleaseAtiva && !User.IsInRole("Vivo-User"))
{

#line default
#line hidden
            BeginContext(2580, 331, true);
            WriteLiteral(@"<!--Modal para alterar a Release-->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Release Codigo ");
            EndContext();
            BeginContext(2912, 16, false);
#line 74 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
                                                                         Write(Model.CodRelease);

#line default
#line hidden
            EndContext();
            BeginContext(2928, 272, true);
            WriteLiteral(@"</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Fechar"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
                <div class=""modal-body"">
                    ");
            EndContext();
            BeginContext(3200, 872, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2da6a51c33d474c9e37157e2e6ad8d3", async() => {
                BeginContext(3239, 155, true);
                WriteLiteral("\r\n                        <div class=\"form-group\">\r\n                            <label class=\"col-form-label\">Status:</label>\r\n                            ");
                EndContext();
                BeginContext(3394, 229, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f438be6d1a6543a4914d5118c3ae30ff", async() => {
                    BeginContext(3440, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                    BeginContext(3474, 40, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f37bd57a6984e6da5ae497e53c92a92", async() => {
                        BeginContext(3492, 13, true);
                        WriteLiteral("Não Executado");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(3514, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                    BeginContext(3548, 36, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fe4ce4aff004f1aaafef30c23435c39", async() => {
                        BeginContext(3566, 9, true);
                        WriteLiteral("Executado");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(3584, 30, true);
                    WriteLiteral("\r\n                            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
#line 83 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Status);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3623, 112, true);
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
                EndContext();
                BeginContext(3735, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27124d6f83cd4916a41fc14e22b268a6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
#line 89 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CodRelease);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3791, 274, true);
                WriteLiteral(@"
                        </div>

                        <input type=""submit"" class=""btn btn-outline-primary"" value=""Salvar"" /> |
                        <button type=""button"" class=""btn btn-outline-secondary"" data-dismiss=""modal"">Fechar</button>

                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4072, 62, true);
            WriteLiteral("\r\n                </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
#line 100 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Vivo\VivoHome.cshtml"
}

#line default
#line hidden
            BeginContext(4137, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4156, 315, true);
                WriteLiteral(@" 
    <script type=""text/javascript"">
        $(function () {
            $("".card"").mousemove(function () {
                $(this).addClass(""shadow-lg"")
            });

            $("".card"").mouseout(function () {
                $(this).removeClass(""shadow-lg"")
            });
        });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Sysmap.Portal.Sanity.Models.VivoRelease> Html { get; private set; }
    }
}
#pragma warning restore 1591
