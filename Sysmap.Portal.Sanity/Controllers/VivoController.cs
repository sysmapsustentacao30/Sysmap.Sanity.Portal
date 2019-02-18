using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sysmap.Portal.Sanity.DAO;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.Controllers
{
    public class VivoController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public VivoController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #region Vivo home e Release
        // GET: Vivo
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult VivoHome([FromServices]VivoDAO vivoDAO)
        {
            ViewBag.ReleaseAtiva = vivoDAO.ReleaseAtivaVivo();

            if (ViewBag.ReleaseAtiva)
            {
                VivoRelease vivoRelease = vivoDAO.GetReleaseVivoAtiva();

                return View(vivoRelease);
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,Vivo-Admin")]
        public IActionResult AtualizaReleaseVivo(VivoRelease vivoRelease, [FromServices]VivoDAO vivoDAO)
        {
            vivoDAO.AtualizaReleaseVivo(vivoRelease);

            return RedirectToAction("VivoHome", "Vivo");
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult HistoricoReleaseVivo([FromServices]VivoDAO vivoDAO)
        {
            List<VivoRelease> vivoReleases = vivoDAO.GetListReleaseVivo();

            ViewBag.CodCenarios = from release in vivoReleases
                                      select release.CodRelease;

            ViewBag.SearchRelease = false;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult HistoricoReleaseVivo(int codRelease,[FromServices]VivoDAO vivoDAO)
        {
            List<VivoCenarios> vivoCenarios = vivoDAO.GetCenariosVivo_CodRelease(codRelease);

            //Lista de codios da release
            List<VivoRelease> vivoReleases = vivoDAO.GetListReleaseVivo();
            ViewBag.CodCenarios = from release in vivoReleases
                                  select release.CodRelease;

            ViewBag.SearchRelease = true;

            ViewBag.Codigo = codRelease;

            return View(vivoCenarios);
        }
        #endregion

        #region Cenarios Vivo
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult CenariosVivo([FromServices]VivoDAO vivoDAO)
        {
            List<VivoCenarios> vivoCenarios = vivoDAO.GetListCenariosVivo();

            return View(vivoCenarios);
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult EditarCenarioVivo(int nCenario,[FromServices]VivoDAO vivoDAO)
        {
            VivoCenarios cenario = vivoDAO.GetCenarioVivo(nCenario);
            ViewBag.CenarioEdit = nCenario;
            return View(cenario);
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult EditarCenarioVivo(VivoCenarios vivoCenario, [FromServices]VivoDAO vivoDAO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            vivoDAO.AtualizaCenarioVivo(vivoCenario);
            return RedirectToAction("CenariosVivo", "Vivo");
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin")]
        public IActionResult CriarCenarioVivo([FromServices]VivoDAO vivoDAO)
        {
            List<VivoCenarios> cenarios = vivoDAO.GetListCenariosVivo();
            int maxCenario = cenarios.Max(c => c.Cenario);

            ViewBag.Cenario = maxCenario + 1;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin")]
        public IActionResult CriarCenarioVivo(VivoCenarios vivoCenarios,[FromServices]VivoDAO vivoDAO)
        {
            List<VivoCenarios> cenarios = vivoDAO.GetListCenariosVivo();
            int maxCenario = cenarios.Max(c => c.Cenario);

            vivoCenarios.Excluido = 0;
            vivoCenarios.Cenario = maxCenario + 1;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("CriarCenarioVivo","Vivo");
            }

            vivoCenarios.Excluido = 0;

            vivoDAO.CriaCenarioVivo(vivoCenarios);

            return View();
        }

        #endregion

        #region ExportRelease to excel
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public async Task<IActionResult> ExportRelease(int release, [FromServices]VivoDAO vivoDAO)
        {


            List<VivoCenarios> vivoCenarios = vivoDAO.GetCenariosVivo_CodRelease(release);

            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"ReleaseVivo.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));

            if (file.Exists)
            {
                file.Delete();
                //file.Create();
            }

            var memory = new MemoryStream();

            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Release");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Cenario");
                row.CreateCell(1).SetCellValue("Prioridade");
                row.CreateCell(2).SetCellValue("Demanda");
                row.CreateCell(3).SetCellValue("Tipo");
                row.CreateCell(4).SetCellValue("Analista");
                row.CreateCell(5).SetCellValue("Desc do Resultado");
                row.CreateCell(6).SetCellValue("Status");
                row.CreateCell(7).SetCellValue("Sistema");
                row.CreateCell(8).SetCellValue("Plataforma");
                row.CreateCell(9).SetCellValue("Funcionalidade");
                row.CreateCell(10).SetCellValue("Size");
                row.CreateCell(11).SetCellValue("Tipo de Teste");
                row.CreateCell(12).SetCellValue("Descrição");
                row.CreateCell(13).SetCellValue("Resultado Esperado");
                row.CreateCell(14).SetCellValue("Tipo de Massa");
                row.CreateCell(15).SetCellValue("Massa");
                row.CreateCell(16).SetCellValue("Documento");
                row.CreateCell(17).SetCellValue("ICCID");
                row.CreateCell(18).SetCellValue("Linha Gerada");
                row.CreateCell(19).SetCellValue("Solicitação Gerada");
                row.CreateCell(20).SetCellValue("Observação");

                int count = 1;

                string executado = "";
                foreach( var item in vivoCenarios)
                {
                    row = excelSheet.CreateRow(count);

                    row.CreateCell(0).SetCellValue(item.Cenario);
                    row.CreateCell(1).SetCellValue(item.Prioridade);
                    row.CreateCell(2).SetCellValue(item.Demanda);
                    row.CreateCell(3).SetCellValue(item.Tipo);
                    row.CreateCell(4).SetCellValue(item.Analista);
                    row.CreateCell(5).SetCellValue(item.Status);
                    switch (item.Executado)
                    {
                        case 0:
                            executado = "Não executado";
                            break;
                        case 1:
                            executado = "Em Execução";
                            break;
                        case 2:
                            executado = "Em Execução";
                            break;
                        case 3:
                            executado = "Executado com Erro";
                            break;
                        case 4:
                            executado = "Executado com sucesso";
                            break;
                    }
                    row.CreateCell(6).SetCellValue(executado);
                    row.CreateCell(7).SetCellValue(item.Sistema);
                    row.CreateCell(8).SetCellValue(item.Plataforma);
                    row.CreateCell(9).SetCellValue(item.Funcionalidade);
                    row.CreateCell(10).SetCellValue(item.Size);
                    row.CreateCell(11).SetCellValue(item.TipoTeste);
                    row.CreateCell(12).SetCellValue(item.Descricao);
                    row.CreateCell(13).SetCellValue(item.ResultEsperado);
                    row.CreateCell(14).SetCellValue(item.TipoMassa);
                    row.CreateCell(15).SetCellValue(item.Massa);
                    row.CreateCell(16).SetCellValue(item.Documento);
                    row.CreateCell(17).SetCellValue(item.ICCID);
                    row.CreateCell(18).SetCellValue(item.LinhaGerada);
                    row.CreateCell(19).SetCellValue(item.SolicGerada);
                    row.CreateCell(20).SetCellValue(item.Observacao);

                    count += 1;
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            file.Delete();

            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
        #endregion
    }
}