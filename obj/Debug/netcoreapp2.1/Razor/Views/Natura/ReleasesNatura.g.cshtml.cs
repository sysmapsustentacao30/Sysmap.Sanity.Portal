#pragma checksum "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3fa274147a75f849010f8b3928a26650d6bc43a"
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
#line 1 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\_ViewImports.cshtml"
using Sysmap.Portal.Sanity;

#line default
#line hidden
#line 2 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\_ViewImports.cshtml"
using Sysmap.Portal.Sanity.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3fa274147a75f849010f8b3928a26650d6bc43a", @"/Views/Natura/ReleasesNatura.cshtml")]
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
#line 2 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
  
    ViewData["Title"] = "Natura Releases";

#line default
#line hidden
            BeginContext(114, 198, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <div class=\"page-title-box\">\r\n            <div class=\"page-title-right\">\r\n                <ol class=\"breadcrumb m-0\">\r\n                    <li>");
            EndContext();
            BeginContext(312, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef838f2551ac445c9afaa68c41496fc6", async() => {
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
#line 23 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
     if (ViewBag.CaptaAtiva)
    {
        

#line default
#line hidden
#line 25 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(729, 117, true);
            WriteLiteral("            <div class=\"col-md-6\">\r\n                <div class=\"card\">\r\n                    <h5 class=\"card-header\"> ");
            EndContext();
            BeginContext(847, 12, false);
#line 29 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                        Write(item.sistema);

#line default
#line hidden
            EndContext();
            BeginContext(859, 9, true);
            WriteLiteral(" código: ");
            EndContext();
            BeginContext(869, 16, false);
#line 29 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                              Write(item.cod_release);

#line default
#line hidden
            EndContext();
            BeginContext(885, 186, true);
            WriteLiteral(".</h5>\r\n                    <div class=\"card-body\">\r\n                        <h4 class=\"card-title\">Informações:</h4>\r\n                        <p><i class=\"fas fa-sitemap\"></i> Sistema: ");
            EndContext();
            BeginContext(1072, 12, false);
#line 32 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                              Write(item.sistema);

#line default
#line hidden
            EndContext();
            BeginContext(1084, 83, true);
            WriteLiteral("</p>\r\n                        <p><i class=\"fas fa-calendar-day\"></i> Data inicial: ");
            EndContext();
            BeginContext(1168, 37, false);
#line 33 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                        Write(item.data_inicial.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1205, 81, true);
            WriteLiteral("</p>\r\n                        <p><i class=\"fas fa-calendar-day\"></i> Data final: ");
            EndContext();
            BeginContext(1287, 35, false);
#line 34 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                      Write(item.data_final.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1322, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 35 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         switch (item.status)
                        {
                            case 0:

#line default
#line hidden
            BeginContext(1439, 89, true);
            WriteLiteral("                                <p><i class=\"fas fa-pen\"></i> Status: Não executado</p>\r\n");
            EndContext();
#line 39 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                break;
                            case 1:

#line default
#line hidden
            BeginContext(1605, 87, true);
            WriteLiteral("                                <p><i class=\"fas fa-pen\"></i> Status: Em execução</p>\r\n");
            EndContext();
#line 42 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                break;
                            case 2:

#line default
#line hidden
            BeginContext(1769, 85, true);
            WriteLiteral("                                <p><i class=\"fas fa-pen\"></i> Status: Executada</p>\r\n");
            EndContext();
#line 45 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                break;

                        }

#line default
#line hidden
            BeginContext(1923, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 48 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         if (!User.IsInRole("Natura-User"))
                        {

#line default
#line hidden
            BeginContext(2011, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2045, "\"", 2065, 1);
#line 50 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2053, item.status, 2053, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2066, "\"", 2095, 2);
            WriteAttributeValue("", 2071, "status_", 2071, 7, true);
#line 50 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2078, item.cod_release, 2078, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2096, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2142, "\"", 2188, 1);
#line 51 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2150, item.data_inicial.ToShortDateString(), 2150, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2189, "\"", 2222, 2);
            WriteAttributeValue("", 2194, "datainicio_", 2194, 11, true);
#line 51 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2205, item.cod_release, 2205, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2223, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2269, "\"", 2313, 1);
#line 52 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2277, item.data_final.ToShortDateString(), 2277, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2314, "\"", 2346, 2);
            WriteAttributeValue("", 2319, "datafinal_", 2319, 10, true);
#line 52 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2329, item.cod_release, 2329, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2347, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2393, "\"", 2417, 1);
#line 53 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2401, item.id_release, 2401, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2418, "\"", 2451, 2);
            WriteAttributeValue("", 2423, "id_release_", 2423, 11, true);
#line 53 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2434, item.cod_release, 2434, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2452, 46, true);
            WriteLiteral(" hidden />\r\n                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2498, "\"", 2519, 1);
#line 54 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2506, item.sistema, 2506, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2520, "\"", 2550, 2);
            WriteAttributeValue("", 2525, "sistema_", 2525, 8, true);
#line 54 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2533, item.cod_release, 2533, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2551, 12, true);
            WriteLiteral(" hidden />\r\n");
            EndContext();
            BeginContext(2565, 157, true);
            WriteLiteral("                            <button type=\"button\" class=\"btn btn-outline-primary btn-rounded\" data-toggle=\"modal\" data-target=\"#exampleModal\" data-whatever=\"");
            EndContext();
            BeginContext(2723, 16, false);
#line 56 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                                                                                                                                                        Write(item.cod_release);

#line default
#line hidden
            EndContext();
            BeginContext(2739, 55, true);
            WriteLiteral("\"><i class=\"fas fa-edit\"></i> Alterar Status</button>\r\n");
            EndContext();
#line 57 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                        }

#line default
#line hidden
            BeginContext(2821, 28, true);
            WriteLiteral("                        | <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2849, "\"", 2929, 1);
#line 58 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
WriteAttributeValue("", 2856, Url.Action("TestesNatura","Natura",new {codRelease = item.cod_release }), 2856, 73, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2930, 225, true);
            WriteLiteral(" class=\"btn btn-outline-primary btn-rounded\"><i class=\"fas fa-list-ol\"></i> Lista de Testes </a>\r\n                    </div> <!-- end card-body-->\r\n                </div> <!-- end card-->\r\n            </div> <!-- end col-->\r\n");
            EndContext();
#line 62 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
        }

#line default
#line hidden
#line 62 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
         
    }

#line default
#line hidden
            BeginContext(3173, 590, true);
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
            BeginContext(3763, 2309, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f5d195fb4f24975bdfb559e8e1d0894", async() => {
                BeginContext(3828, 146, true);
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <label for=\"recipient-name\" class=\"col-form-label\">Data Inicial:</label>\r\n");
                EndContext();
#line 80 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         if (!User.IsInRole("Natura-User"))
                        {

#line default
#line hidden
                BeginContext(4062, 114, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_inicial_modal\" name=\"data_inicial\">\r\n");
                EndContext();
#line 83 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(4260, 123, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_inicial_modal\" name=\"data_inicial\" readonly>\r\n");
                EndContext();
#line 87 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"

                        }

#line default
#line hidden
                BeginContext(4412, 171, true);
                WriteLiteral("                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"recipient-name\" class=\"col-form-label\">Data Final: </label>\r\n");
                EndContext();
#line 92 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                         if (!User.IsInRole("Natura-User"))
                        {

#line default
#line hidden
                BeginContext(4671, 110, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_final_modal\" name=\"data_final\">\r\n");
                EndContext();
#line 95 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(4865, 119, true);
                WriteLiteral("                            <input type=\"date\" class=\"form-control\" id=\"data_final_modal\" name=\"data_final\" readonly>\r\n");
                EndContext();
#line 99 "C:\Sandbox\Sysmap.Sanity.Portal\Sysmap.Portal.Sanity\Views\Natura\ReleasesNatura.cshtml"

                        }

#line default
#line hidden
                BeginContext(5013, 292, true);
                WriteLiteral(@"                    </div>
                    <div class=""form-group"">
                        <label for=""recipient-name"" class=""col-form-label"">Status da Release:</label>
                        <select id=""status_modal"" name=""status"" class=""form-control"">
                            ");
                EndContext();
                BeginContext(5305, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d77b7060ff5412dab15c57afebf323a", async() => {
                    BeginContext(5323, 17, true);
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
                BeginContext(5349, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(5379, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdbecca44c9e4e8fad6acc9afcd818e6", async() => {
                    BeginContext(5397, 15, true);
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
                BeginContext(5421, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(5451, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13fcce162f294415bdc97dac46b4429e", async() => {
                    BeginContext(5469, 13, true);
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
                BeginContext(5491, 574, true);
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
            BeginContext(6072, 62, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(6152, 1951, true);
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
            
            var modal");
                WriteLiteral(@" = $(this);
            modal.find('.modal-title').text('Sistema: ' + sistema);

            var arr_data_inicio = data_inicio.split('/');
            data_inicio = new Date(arr_data_inicio[2], arr_data_inicio[1] - 1, arr_data_inicio[0])

            var arr_data_final = data_final.split('/');
            data_final = new Date(arr_data_final[2], arr_data_final[1] - 1, arr_data_final[0])


            document.getElementById(""status_modal"").value = status;
            document.getElementById(""codigo_modal"").value = codigo;
            document.getElementById(""sistema_modal"").value = sistema;
            document.getElementById(""data_inicial_modal"").value = data_inicio.toISOString().slice(0, 10);
            document.getElementById(""data_final_modal"").value = data_final.toISOString().slice(0, 10);
            document.getElementById(""id_release_modal"").value = id_release;
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(8106, 4, true);
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
