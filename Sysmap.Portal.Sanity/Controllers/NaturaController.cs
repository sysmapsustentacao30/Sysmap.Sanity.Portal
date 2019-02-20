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
        public NaturaController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
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
            naturaDAO.AtualizaRelease_Natura(naturaRelease);

            return RedirectToAction("ReleasesNatura", "Natura");
        }
        #endregion

        #region Lista com historico com todos as Releases.
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult HistoricoReleaseNatura([FromServices]NaturaDAO naturaDAO)
        {
            List<NaturaRelease> captas = naturaDAO.ListRelease_Natura();

            return View(captas);
        }
        #endregion

        #region Exporta Release para excel
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public async Task<IActionResult> ExportarReleaseNatura(string codRelease, [FromServices]NaturaDAO naturaDAO)
        {
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
                row.CreateCell(12).SetCellValue("Data execucao");

                int count = 1;

                foreach (var item in testes)
                {
                    row = excelSheet.CreateRow(count);

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
                    row.CreateCell(11).SetCellValue(item.data_execucao.Value.ToShortDateString());

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

        #region Cria uma nova Release(Lista de teste) e importa planilha com os dados.
        [HttpGet]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult CadReleaseNatura([FromServices]NaturaDAO naturaDAO)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,Natura-Admin")]
        public IActionResult CadReleaseNatura(NaturaRelease naturaRelease, IFormFile file, [FromServices]NaturaDAO naturaDAO)
        {

    
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
                                execucao_status = 0,
                                chamado_status = 0

                            };
                            listTestes.Add(naturaTeste);
                           

                        }
                    }
                    //Add Testes
                    foreach (NaturaTeste teste in listTestes)
                    {
                        naturaDAO.AddTest_Natura(teste);
                    }

                    //Registra cod dos testes do capta,dia e status
                    naturaDAO.AddRelease_Natura(naturaRelease);

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
          
            NaturaTeste teste = naturaDAO.Teste_Natura(idTeste);

            return View(teste);
        }

        [HttpPost]
        [Authorize(Roles = "All-Admin,All-User,Natura-Admin,Natura-User")]
        public IActionResult EditarTesteNatura(NaturaTeste teste,int ultimo_executado, int ultimo_chamado, [FromServices]NaturaDAO naturaDAO)
        {

            if(teste.execucao_status == 3 && teste.chamado_status == 0)
            {
                ModelState.AddModelError("observacao", "Informe o numero do chamado aqui!");
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
            await naturaDAO.DeletaTeste_Natura(codRelease, nTeste);

            return RedirectToAction("TestesNatura", "Natura", new { codRelease });
        }
        #endregion

    }
}