#pragma checksum "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a2f3f3121990a901118d4b383629905810550cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Natura_ReleasesNatura), @"mvc.1.0.view", @"/Views/Natura/ReleasesNatura.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Natura/ReleasesNatura.cshtml", typeof(AspNetCore.Views_Natura_ReleasesNatura))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a2f3f3121990a901118d4b383629905810550cf", @"/Views/Natura/ReleasesNatura.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba5c1b23f338b860c1a91e839c988a3c801039bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Natura_ReleasesNatura : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sysmap.Portal.Sanity.Models.NaturaRelease>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NaturaHome", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Natura", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AtualizaReleaseNatura", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
  
    ViewData["Title"] = "Natura Releases";

#line default
#line hidden
            BeginContext(114, 198, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <div class=\"page-title-box\">\r\n            <div class=\"page-title-right\">\r\n                <ol class=\"breadcrumb m-0\">\r\n                    <li>");
            EndContext();
            BeginContext(312, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c629b374bb5444e8390c9509be83103", async() => {
                BeginContext(363, 6, true);
                WriteLiteral("Natura");
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
            BeginContext(373, 270, true);
            WriteLiteral(@" <i class=""fas fa-angle-right""></i> </li>
                    <li class=""active""> Releases</li>
                </ol>
            </div>
            <h4 class=""page-title"">Release(s) Ativa(s) Natura</h4>
        </div>
    </div>
</div>



<div class=""row"">
");
            EndContext();
#line 23 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
     if (ViewBag.CaptaAtiva)
    {
        

#line default
#line hidden
#line 25 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(729, 117, true);
            WriteLiteral("            <div class=\"col-md-6\">\r\n                <div class=\"card\">\r\n                    <h5 class=\"card-header\"> ");
            EndContext();
            BeginContext(847, 12, false);
#line 29 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                        Write(item.sistema);

#line default
#line hidden
            EndContext();
            BeginContext(859, 9, true);
            WriteLiteral(" código: ");
            EndContext();
            BeginContext(869, 16, false);
#line 29 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                              Write(item.cod_release);

#line default
#line hidden
            EndContext();
            BeginContext(885, 187, true);
            WriteLiteral(".</h5>\r\n                    <div class=\"card-body\">\r\n                        <h4 class=\"card-title\">Informações:</h4>\r\n                        <p><i class=\"fas fa-sitemap\"></i> Ambiente: ");
            EndContext();
            BeginContext(1073, 12, false);
#line 32 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                               Write(item.sistema);

#line default
#line hidden
            EndContext();
            BeginContext(1085, 83, true);
            WriteLiteral("</p>\r\n                        <p><i class=\"fas fa-calendar-day\"></i> Data inicial: ");
            EndContext();
            BeginContext(1169, 40, false);
#line 33 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                        Write(item.data_inicial.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(1209, 81, true);
            WriteLiteral("</p>\r\n                        <p><i class=\"fas fa-calendar-day\"></i> Data final: ");
            EndContext();
            BeginContext(1291, 38, false);
#line 34 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                      Write(item.data_final.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(1329, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 35 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         switch (item.status)
                        {
                            case 0:

#line default
#line hidden
            BeginContext(1446, 89, true);
            WriteLiteral("                                <p><i class=\"fas fa-pen\"></i> Status: Não executado</p>\r\n");
            EndContext();
#line 39 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                break;
                            case 1:

#line default
#line hidden
            BeginContext(1612, 87, true);
            WriteLiteral("                                <p><i class=\"fas fa-pen\"></i> Status: Em execução</p>\r\n");
            EndContext();
#line 42 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                break;
                            case 2:

#line default
#line hidden
            BeginContext(1776, 85, true);
            WriteLiteral("                                <p><i class=\"fas fa-pen\"></i> Status: Executada</p>\r\n");
            EndContext();
#line 45 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                break;

                        }

#line default
#line hidden
            BeginContext(1930, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 48 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         if (!User.IsInRole("Natura-User"))
                        {

#line default
#line hidden
            BeginContext(2018, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2052, "\"", 2072, 1);
#line 50 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2060, item.status, 2060, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2073, "\"", 2102, 2);
            WriteAttributeValue("", 2078, "status_", 2078, 7, true);
#line 50 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2085, item.cod_release, 2085, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2103, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2149, "\"", 2198, 1);
#line 51 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2157, item.data_inicial.ToString("yyyy-MM-dd"), 2157, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2199, "\"", 2232, 2);
            WriteAttributeValue("", 2204, "datainicio_", 2204, 11, true);
#line 51 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2215, item.cod_release, 2215, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2233, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2279, "\"", 2326, 1);
#line 52 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2287, item.data_final.ToString("yyyy-MM-dd"), 2287, 39, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2327, "\"", 2359, 2);
            WriteAttributeValue("", 2332, "datafinal_", 2332, 10, true);
#line 52 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2342, item.cod_release, 2342, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2360, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2406, "\"", 2430, 1);
#line 53 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2414, item.id_release, 2414, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2431, "\"", 2464, 2);
            WriteAttributeValue("", 2436, "id_release_", 2436, 11, true);
#line 53 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2447, item.cod_release, 2447, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2465, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2511, "\"", 2532, 1);
#line 54 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2519, item.sistema, 2519, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2533, "\"", 2563, 2);
            WriteAttributeValue("", 2538, "sistema_", 2538, 8, true);
#line 54 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2546, item.cod_release, 2546, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2564, 49, true);
            WriteLiteral(" hidden />\r\n                            <textarea");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2613, "\"", 2645, 2);
            WriteAttributeValue("", 2618, "anotacoes_", 2618, 10, true);
#line 55 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2628, item.cod_release, 2628, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2646, 9, true);
            WriteLiteral("  hidden>");
            EndContext();
            BeginContext(2656, 14, false);
#line 55 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                          Write(item.anotacoes);

#line default
#line hidden
            EndContext();
            BeginContext(2670, 13, true);
            WriteLiteral("</textarea>\r\n");
            EndContext();
            BeginContext(2685, 157, true);
            WriteLiteral("                            <button type=\"button\" class=\"btn btn-outline-primary btn-rounded\" data-toggle=\"modal\" data-target=\"#exampleModal\" data-whatever=\"");
            EndContext();
            BeginContext(2843, 16, false);
#line 57 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                                                                                                        Write(item.cod_release);

#line default
#line hidden
            EndContext();
            BeginContext(2859, 55, true);
            WriteLiteral("\"><i class=\"fas fa-edit\"></i> Alterar Status</button>\r\n");
            EndContext();
#line 58 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                        }

#line default
#line hidden
            BeginContext(2941, 28, true);
            WriteLiteral("                        | <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2969, "\"", 3049, 1);
#line 59 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2976, Url.Action("TestesNatura","Natura",new {codRelease = item.cod_release }), 2976, 73, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3050, 225, true);
            WriteLiteral(" class=\"btn btn-outline-primary btn-rounded\"><i class=\"fas fa-list-ol\"></i> Lista de Testes </a>\r\n                    </div> <!-- end card-body-->\r\n                </div> <!-- end card-->\r\n            </div> <!-- end col-->\r\n");
            EndContext();
#line 63 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
        }

#line default
#line hidden
#line 63 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
         
    }

#line default
#line hidden
            BeginContext(3293, 590, true);
            WriteLiteral(@"</div>


<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(3883, 2594, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1cd5da9171aa4cf68ccfef2021d1a84d", async() => {
                BeginContext(3948, 146, true);
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <label for=\"recipient-name\" class=\"col-form-label\">Data Inicial:</label>\r\n");
                EndContext();
#line 81 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         if (!User.IsInRole("Natura-User"))
                        {

#line default
#line hidden
                BeginContext(4182, 114, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_inicial_modal\" name=\"data_inicial\">\r\n");
                EndContext();
#line 84 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(4380, 123, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_inicial_modal\" name=\"data_inicial\" readonly>\r\n");
                EndContext();
#line 88 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"

                        }

#line default
#line hidden
                BeginContext(4532, 171, true);
                WriteLiteral("                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"recipient-name\" class=\"col-form-label\">Data Final: </label>\r\n");
                EndContext();
#line 93 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         if (!User.IsInRole("Natura-User"))
                        {

#line default
#line hidden
                BeginContext(4791, 110, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_final_modal\" name=\"data_final\">\r\n");
                EndContext();
#line 96 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(4985, 119, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_final_modal\" name=\"data_final\" readonly>\r\n");
                EndContext();
#line 100 "C:\GITHUB\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"

                        }

#line default
#line hidden
                BeginContext(5133, 577, true);
                WriteLiteral(@"                    </div>
                    <div class=""form-group"">
                        <label for=""recipient-name"" class=""col-form-label"">Anotações: </label>
                        <textarea class=""form-control"" id=""anotacoes_modal"" name=""anotacoes"" rows=""2""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label for=""recipient-name"" class=""col-form-label"">Status da Release:</label>
                        <select id=""status_modal"" name=""status"" class=""form-control"">
                            ");
                EndContext();
                BeginContext(5710, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "330b34f95b2d4da8965765ad0ac920f4", async() => {
                    BeginContext(5728, 17, true);
                    WriteLiteral("0- Não Executado.");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5754, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(5784, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe237ca6ef4408bab685fdeb63d13e4", async() => {
                    BeginContext(5802, 15, true);
                    WriteLiteral("1- Em execução.");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5826, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(5856, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1335a702547241f4b0fca6978a44bc4d", async() => {
                    BeginContext(5874, 13, true);
                    WriteLiteral("2- Executado.");
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
                BeginContext(5896, 574, true);
                WriteLiteral(@"
                        </select>
                    </div>
                    <input id=""id_release_modal"" name=""id_release"" hidden />
                    <input id=""sistema_modal"" name=""sistema"" hidden />
                    <input id=""codigo_modal"" name=""cod_release"" hidden />

                    <button type=""submit"" class=""btn btn-outline-primary btn-rounded""><i class=""fas fa-save""></i> Salvar</button> | <button type=""button"" class=""btn btn-outline-secondary btn-rounded"" data-dismiss=""modal""><i class=""fas fa-times""></i> Close</button>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6477, 62, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(6557, 1571, true);
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
        $('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget); // Button that triggered the modal
                        
            //Dados da release selecionada
            var codigo = button.data('whatever');
            var id_release = document.getElementById('id_release_' + codigo).value;
            var sistema = document.getElementById(""sistema_"" + codigo).value;
            var data_inicio = document.getElementById(""datainicio_"" + codigo).value;
            var data_final = document.getElementById(""datafinal_"" + codigo).value;
            var status = document.getElementById(""status_"" + codigo).value;
            var anotacoes = documen");
                WriteLiteral(@"t.getElementById(""anotacoes_"" + codigo).value;
            
            var modal = $(this);
            modal.find('.modal-title').text('Sistema: ' + sistema);

            $('#data_inicial_modal').val(data_inicio);
            $('#data_final_modal').val(data_final);
            $('#status_modal').val(status);
            $('#codigo_modal').val(codigo);
            $('#sistema_modal').val(sistema);
            $('#anotacoes_modal').val(anotacoes);
            $('#id_release_modal').val(id_release);

        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(8131, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sysmap.Portal.Sanity.Models.NaturaRelease>> Html { get; private set; }
    }
}
#pragma warning restore 1591
