using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sysmap.Portal.Sanity.DAO;
using Sysmap.Portal.Sanity.Models;


namespace Sysmap.Portal.Sanity.Controllers
{
    public class NaturaController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public NaturaController(IHostingEnvironment hostingEnvironment, ILogger<NaturaController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        #region Home Natura
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult NaturaHome()
        {
            return View();
        }
        #endregion

        #region Lista de releases ativas da Natura
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult ReleasesNatura([FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- Get Releases Ativas / User: {0}", User.Identity.Name);

            ViewBag.CaptaAtiva = naturaDAO.ExistReleaseAtiva_Natura();

            if (ViewBag.CaptaAtiva)
            {
                List<NaturaRelease> releasesAtivas = naturaDAO.GetReleasesAtiva_Natura();

                return View(releasesAtivas);
            }

            return View();
        }
        #endregion

        #region Atualiza o status de execução da Release Natura
        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult AtualizaReleaseNatura(NaturaRelease naturaRelease, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- Atualiza o status de execução da Release : {0} / User: {1}",naturaRelease.cod_release ,User.Identity.Name);
            naturaDAO.AtualizaRelease_Natura(naturaRelease);

            return RedirectToAction("ReleasesNatura", "Natura");
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult ReabriRelease(string codRelease, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- Reabrindo release cod {0} / User: {1}", codRelease, User.Identity.Name);
            naturaDAO.ReabriRelease(codRelease);

            return RedirectToAction("HistoricoReleaseNatura", "Natura");
        }
        #endregion

        #region Lista de historico com todos as Releases.
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult HistoricoReleaseNatura([FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- Historico de Releases / User: {0}", User.Identity.Name);
            List<NaturaRelease> captas = naturaDAO.ListRelease_Natura();

            return View(captas);
        }
        #endregion

        #region Exporta Release para excel
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public async Task<IActionResult> ExportarReleaseNatura(string codRelease, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- Exporta Release cod: {0} / User: {1}", codRelease, User.Identity.Name);

            List<NaturaTeste> testes = naturaDAO.ListaTestes_Natura(codRelease);

            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"Release_Natura.xlsx";
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
                ISheet excelSheet = workbook.CreateSheet("Testes");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Numero Teste");
                row.CreateCell(1).SetCellValue("Sistema");
                row.CreateCell(2).SetCellValue("Funcionalidade");
                row.CreateCell(3).SetCellValue("Cenario");
                row.CreateCell(4).SetCellValue("Pre condicao");
                row.CreateCell(5).SetCellValue("Passos");
                row.CreateCell(6).SetCellValue("Result Esperado");
                row.CreateCell(7).SetCellValue("Pos condicao");
                row.CreateCell(8).SetCellValue("Executor");
                row.CreateCell(9).SetCellValue("Massa");
                row.CreateCell(10).SetCellValue("Observacao");
                row.CreateCell(11).SetCellValue("Link doc");
                row.CreateCell(12).SetCellValue("Data prevista");
                row.CreateCell(13).SetCellValue("Prioridade");
                row.CreateCell(14).SetCellValue("Data executado");
                row.CreateCell(16).SetCellValue("Status teste");
                row.CreateCell(16).SetCellValue("Status chamado");

                int count = 1;
                string statusTeste = "";
                string statusChamado = "";

                foreach (var item in testes)
                {
                    row = excelSheet.CreateRow(count);

                    switch(item.execucao_status)
                    {
                        case 0:
                            statusTeste = "Não Executado";
                            break;
                        case 1:
                            statusTeste = "Em execução";
                            break;
                        case 2:
                            statusTeste = "Bloqueado";
                            break;
                        case 3:
                            statusTeste = "Teste Falhou";
                            break;
                        case 4:
                            statusTeste = "Teste com sucesso";
                                break;
                    }

                    switch (item.chamado_status)
                    {
                        case 0:
                            statusChamado = "N/A";
                            break;
                        case 1:
                            statusChamado = "Aberto";
                            break;
                        case 2:
                            statusChamado = "Em correção";
                            break;
                        case 3:
                            statusChamado = "Liberado para teste";
                            break;
                        case 4:
                            statusChamado = "Em teste";
                            break;
                        case 5:
                            statusChamado = "Fechado";
                            break;
                    }

                    row.CreateCell(0).SetCellValue(item.numero_teste);
                    row.CreateCell(1).SetCellValue(item.sistema);
                    row.CreateCell(2).SetCellValue(item.funcionalidade);
                    row.CreateCell(3).SetCellValue(item.cenario);
                    row.CreateCell(4).SetCellValue(item.pre_condicao);
                    row.CreateCell(5).SetCellValue(item.passos);
                    row.CreateCell(6).SetCellValue(item.result_esperado);
                    row.CreateCell(7).SetCellValue(item.pos_condicao);
                    row.CreateCell(8).SetCellValue(item.executor);
                    row.CreateCell(9).SetCellValue(item.massa);
                    row.CreateCell(10).SetCellValue(item.observacao);
                    row.CreateCell(11).SetCellValue(item.url_doc);
                    row.CreateCell(12).SetCellValue(item.data_execucao.Value.ToString("dd/MM/yyyy"));
                    row.CreateCell(13).SetCellValue(item.prioridade);
                    row.CreateCell(14).SetCellValue(item.data_executado.ToString("dd/MM/yyyy"));
                    row.CreateCell(15).SetCellValue(statusTeste);
                    row.CreateCell(16).SetCellValue(statusChamado);

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

        #region Cadastrar Release(Lista de teste) e importa planilha com os dados.
        [HttpGet]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult CadReleaseNatura([FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- [HttpGet] Cadastra nova release / User: {0}", User.Identity.Name);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult CadReleaseNatura(NaturaRelease naturaRelease, IFormFile file, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- [HttPost] Cadastra nova release / User: {0}", User.Identity.Name);

            if(naturaRelease.sistema == "null")
            {
                ModelState.AddModelError("sistema", "Campo 'Ambiente' é obrigatorio");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                int maxId = naturaDAO.GetMaxId_Release();
 
                string webRootPath = _hostingEnvironment.WebRootPath;
                StringBuilder sb = new StringBuilder();

                if(file is null)
                {
                    ModelState.AddModelError("", "Planilha não encontrada!");
                    return View();
                }

                naturaRelease.cod_release = "Release_" + maxId.ToString();

                List<NaturaTeste> listTestes = new List<NaturaTeste>();

                if (file.Length > 0)
                {
                    string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                    ISheet sheet;
                    string fullPath = Path.Combine(webRootPath, file.FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Position = 0;
                        if (sFileExtension == ".xls")
                        {
                            HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                            sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                        }
                        else
                        {
                            XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                            sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                        }

                        IRow headerRow = sheet.GetRow(0); //Get Header Row
                        int cellCount = headerRow.LastCellNum;

                        for (int i = (sheet.FirstRowNum + 1); i <= naturaRelease.qtdTestes; i++) //Read Excel File
                        {
                            IRow row = sheet.GetRow(i);

                            var dataExec = row.GetCell(12)?.ToString();
                            DateTime? data = null;
                            if(dataExec == "" || dataExec is null)
                            {
                                
                            }
                            else
                            {
                                data = Convert.ToDateTime(dataExec);
                            }

                            var prioridadeExcel = row.GetCell(13)?.ToString();
                            int prioridadeTeste = 0;
                            if(prioridadeExcel == "" || prioridadeExcel is null)
                            {

                            }
                            else
                            {
                                prioridadeTeste = Convert.ToInt16(row.GetCell(13)?.ToString());
                            }

                            NaturaTeste naturaTeste = new NaturaTeste
                            {
                                cod_release = naturaRelease.cod_release,
                                numero_teste = Convert.ToInt16(row.GetCell(0)?.ToString()),
                                sistema = row.GetCell(1)?.ToString(),
                                funcionalidade = row.GetCell(2)?.ToString(),
                                cenario = row.GetCell(3)?.ToString(),
                                pre_condicao = row.GetCell(4)?.ToString(),
                                passos = row.GetCell(5)?.ToString(),
                                result_esperado = row.GetCell(6)?.ToString(),
                                pos_condicao = row.GetCell(7)?.ToString(),
                                executor = row.GetCell(8)?.ToString(),
                                massa = row.GetCell(9)?.ToString(),
                                observacao = row.GetCell(10)?.ToString(),
                                url_doc = row.GetCell(11)?.ToString(),
                                data_execucao = data,
                                prioridade = prioridadeTeste,
                                cn_login = row.GetCell(14)?.ToString(),
                                cn_senha = row.GetCell(15)?.ToString(),
                                gr_login = row.GetCell(16)?.ToString(),
                                gr_senha = row.GetCell(17)?.ToString(),
                                lider_login = row.GetCell(18)?.ToString(),
                                lider_senha = row.GetCell(19)?.ToString(),
                                browser = row.GetCell(20)?.ToString(),
                                execucao_status = 0,
                                chamado_status = 0

                            };
                            listTestes.Add(naturaTeste);
                           

                        }
                    }

                    //Registra na tabela de releases da natura.
                    naturaDAO.AddRelease_Natura(naturaRelease);

                    //Add Testes
                    foreach (NaturaTeste teste in listTestes)
                    {
                        naturaDAO.AddTest_Natura(teste);
                    }


                    //Deleta arquivo criado
                    FileInfo fileInfo = new FileInfo(Path.Combine(webRootPath, file.FileName));
                    fileInfo.Delete();
                }

                return RedirectToAction("ReleasesNatura", "Natura");
            }
        }
        #endregion

        #region Lista de testes da Release X da Natura
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult TestesNatura(string codRelease,[FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- Lista de testes da Release cod: {0}/ User: {1}",codRelease, User.Identity.Name);
            NaturaRelease naturaRelease = naturaDAO.GetRelease(codRelease);
            List<NaturaTeste> naturaTestes = naturaDAO.ListaTestes_Natura(codRelease);
           
            ViewBag.Ambiente = naturaRelease.sistema;
            ViewBag.CodRelease = (from x in naturaTestes select x.cod_release).First();

            return View(naturaTestes);
        }
        #endregion

        #region Edita o teste x(Atualizando o status dele,etc)
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult EditarTesteNatura (int idTeste, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- [HttpGet] Editar Teste id: {0}/ User: {1}", idTeste, User.Identity.Name);

            NaturaTeste teste = naturaDAO.Teste_Natura(idTeste);

            return View(teste);
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult EditarTesteNatura(NaturaTeste teste,int ultimo_executado, int ultimo_chamado, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- [HttpPost] Editar Teste id: {0}/ User: {1}", teste.id_natura_teste, User.Identity.Name);

            if (teste.execucao_status == 3 && teste.chamado_status == 0)
            {
                ModelState.AddModelError("observacao", "Informe o numero do chamado aqui aberto aqui!");
                ModelState.AddModelError("chamado_status", "Este campo é obrigatório!");
                return View(teste);
            }
            
            if(ultimo_chamado != 0)
            {
                ModelState.AddModelError("observacao", "Informe o numero do chamado aqui!");
                ModelState.AddModelError("chamado_status", "Este campo é obrigatório!");
                return View(teste);
            }


            if (teste.execucao_status == 4 && ultimo_executado != 4)
            {
                teste.data_executado = DateTime.Now.Date;
            }
            naturaDAO.AtualizaTeste_Natura(teste);
            string codRelease = teste.cod_release;

            return RedirectToAction("TestesNatura", "Natura", new {codRelease});
        }
        #endregion

        #region Cadastra um teste em uma release já cadastrada
        [HttpGet]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult AddTesteNatura (string codRelease, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- [HttpGet] Adicionar Teste a release cod: {0}/ User: {1}", codRelease, User.Identity.Name);
            List<NaturaTeste> naturaTestes = naturaDAO.ListaTestes_Natura(codRelease);

            ViewBag.CodRelease = (from x in naturaTestes select x.cod_release).First();
            ViewBag.Cenario = (from x in naturaTestes select x.numero_teste).Max() + 1;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult AddTesteNatura(NaturaTeste naturaTeste, [FromServices]NaturaDAO naturaDAO)
        {

            if (!ModelState.IsValid)
            {
                List<NaturaTeste> naturaTestes = naturaDAO.ListaTestes_Natura(naturaTeste.cod_release);

                ViewBag.CodRelease = (from x in naturaTestes select x.cod_release).First();
                ViewBag.Cenario = (from x in naturaTestes select x.numero_teste).Max() + 1;

                return View();
            }
            naturaTeste.execucao_status = 0;
            naturaTeste.chamado_status = 0;

            _logger.LogInformation("Natura- [HttpPost] Adicionar Teste a release cod: {0}/ User: {1}", naturaTeste.cod_release, User.Identity.Name);
            naturaDAO.AddTest_Natura(naturaTeste);

            return RedirectToAction("TestesNatura", "Natura", new { codRelease = naturaTeste.cod_release });
        }

        [HttpGet]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult AddTestesNatura(string codRelease, [FromServices]NaturaDAO naturaDAO)
        {
            //List<NaturaTeste> naturaTestes = naturaDAO.ListaTestes_Natura(codRelease);

            ViewBag.CodRelease = codRelease;
            //ViewBag.Cenario = (from x in naturaTestes select x.numero_teste).Max() + 1;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult InsertTestesNatura(string codRelease, int qtdTeste, IFormFile file, [FromServices]NaturaDAO naturaDAO)
        {

            if (qtdTeste < 1)
            {
                ModelState.AddModelError("", "Informe a quantidade de testes!");
                return View();
            }
            else
            {
                if (file is null)
                {
                    ModelState.AddModelError("", "Planilha não encontrada!");
                    return View();
                }

                List<NaturaTeste> naturaTestes = naturaDAO.ListaTestes_Natura(codRelease);
                ViewBag.CodRelease = codRelease;

                int nTeste = (from x in naturaTestes select x.numero_teste).Max() + 1;

                string webRootPath = _hostingEnvironment.WebRootPath;
                StringBuilder sb = new StringBuilder();

                if (file.Length > 0)
                {
                    List<NaturaTeste> lista = new List<NaturaTeste>();

                    string sFileExtension = Path.GetExtension(file.FileName).ToLower();

                    ISheet sheet;

                    string fullPath = Path.Combine(webRootPath, file.FileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Position = 0;
                        if (sFileExtension == ".xls")
                        {
                            HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                            sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                        }
                        else
                        {
                            XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                            sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                        }

                        IRow headerRow = sheet.GetRow(0); //Get Header Row
                        int cellCount = headerRow.LastCellNum;

                        for (int i = (sheet.FirstRowNum + 1); i <= qtdTeste; i++) //Read Excel File
                        {
                            IRow row = sheet.GetRow(i);

                            var dataExec = row.GetCell(12)?.ToString();
                            DateTime? data = null;
                            if (dataExec == "" || dataExec is null)
                            {

                            }
                            else
                            {
                                data = Convert.ToDateTime(dataExec);
                            }

                            NaturaTeste naturaTeste = new NaturaTeste
                            {
                                cod_release = codRelease,
                                numero_teste = nTeste,
                                sistema = row.GetCell(1)?.ToString(),
                                funcionalidade = row.GetCell(2)?.ToString(),
                                cenario = row.GetCell(3)?.ToString(),
                                pre_condicao = row.GetCell(4)?.ToString(),
                                passos = row.GetCell(5)?.ToString(),
                                result_esperado = row.GetCell(6)?.ToString(),
                                pos_condicao = row.GetCell(7)?.ToString(),
                                executor = row.GetCell(8)?.ToString(),
                                massa = row.GetCell(9)?.ToString(),
                                observacao = row.GetCell(10)?.ToString(),
                                url_doc = row.GetCell(11)?.ToString(),
                                data_execucao = data,
                                prioridade = Convert.ToUInt16(row.GetCell(13)?.ToString()),
                                cn_login = row.GetCell(14)?.ToString(),
                                cn_senha = row.GetCell(15)?.ToString(),
                                gr_login = row.GetCell(16)?.ToString(),
                                gr_senha = row.GetCell(17)?.ToString(),
                                lider_login = row.GetCell(18)?.ToString(),
                                lider_senha = row.GetCell(19)?.ToString(),
                                browser = row.GetCell(20)?.ToString(),
                                execucao_status = 0,
                                chamado_status = 0

                            };

                            lista.Add(naturaTeste);

                            nTeste += 1;

                        }
                    }
                    //Add Testes
                    foreach (NaturaTeste teste in lista)
                    {
                        naturaDAO.AddTest_Natura(teste);
                    }

                    //Deleta arquivo criado
                    FileInfo fileInfo = new FileInfo(Path.Combine(webRootPath, file.FileName));
                    fileInfo.Delete();
                }

            }
            return RedirectToAction("TestesNatura", "Natura",new { codRelease });
        }
        #endregion

        #region Deletar 
        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public async Task<IActionResult> DelTesteNatura(string codRelease,int nTeste, [FromServices]NaturaDAO naturaDAO)
        {
            _logger.LogInformation("Natura- [HttpGet] Deletar Teste da release cod: {0}, nTeste: {1}/ User: {2}", codRelease, nTeste, User.Identity.Name);
            await naturaDAO.DeletaTeste_Natura(codRelease, nTeste);

            return RedirectToAction("TestesNatura", "Natura", new { codRelease });
        }
        #endregion

    }
}