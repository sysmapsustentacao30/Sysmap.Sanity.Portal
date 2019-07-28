using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Sysmap.Portal.Sanity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.Extensions
{
    public class ReadExcel
    {
        private IHostingEnvironment _hostingEnvironment;

        public ReadExcel(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #region Lendo dados da planilha Vivo
        public List<TestesVivo> VivoPlanTestes(IFormFile excel, int qtdTestes, string codRelease, int IdRelease)
        {
            List<TestesVivo> testesVivo = new List<TestesVivo>();

            string sFileExtension = Path.GetExtension(excel.FileName).ToLower();
            ISheet sheetCenarios;
            ISheet sheetMassas;

            string webRootPath = _hostingEnvironment.WebRootPath;
            string fullPath = Path.Combine(webRootPath, excel.FileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                excel.CopyTo(stream);
                stream.Position = 0;

                if (sFileExtension == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    sheetCenarios = hssfwb.GetSheetAt(2); //get Cenarios do Sanity  
                    sheetMassas = hssfwb.GetSheetAt(1);
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    sheetCenarios = hssfwb.GetSheetAt(2); //get get Cenarios do Sanity   
                    sheetMassas = hssfwb.GetSheetAt(1);
                }

                IRow headerRow = sheetCenarios.GetRow(0); //Get Header Row
                int cellCount = headerRow.LastCellNum;

                for (int i = (sheetCenarios.FirstRowNum + 1); i <= qtdTestes; i++)
                {
                    IRow row = sheetCenarios.GetRow(i);

                    string dataMassa = row.GetCell(15)?.ToString();
                    string massa = null;
                    if (dataMassa is null)
                    {

                    }
                    else if (dataMassa.Contains("CPFs"))
                    {
                        var cr = new CellReference(dataMassa);
                        var rowMassas = sheetMassas.GetRow(cr.Row);
                        massa = rowMassas.GetCell(cr.Col)?.ToString();
                    }
                    else
                    {
                        massa = dataMassa;
                    }

                    TestesVivo teste = new TestesVivo
                    {
                        CodRelease = codRelease,
                        IdRelease = IdRelease,
                        Excluido = 0,
                        Cenario = Convert.ToInt32(row.GetCell(0)?.ToString()),
                        Prioridade = Convert.ToInt32(row.GetCell(1)?.ToString()),
                        Demanda = row.GetCell(2).ToString() ?? "Regressão",
                        Analista = row.GetCell(3)?.ToString(),
                        Login = row.GetCell(4)?.ToString(),
                        Senha = row.GetCell(5)?.ToString(),
                        Status = 0,
                        Sistema = row.GetCell(7)?.ToString(),
                        Plataforma = row.GetCell(8)?.ToString(),
                        Funcionalidade = row.GetCell(9)?.ToString(),
                        Size = row.GetCell(10)?.ToString(),
                        TipoTeste = row.GetCell(11)?.ToString(),
                        Descricao = row.GetCell(12)?.ToString(),
                        ResultEsperado = row.GetCell(13)?.ToString(),
                        TipoMassa = row.GetCell(14)?.ToString(),
                        Massa = massa,
                        Documento = row.GetCell(16)?.ToString(),
                        ICCID = row.GetCell(17)?.ToString(),
                        SolicGerada = row.GetCell(18)?.ToString(),
                        LinhaGerada = row.GetCell(19)?.ToString(),
                        Observacao = row.GetCell(20)?.ToString()
                    };
                    testesVivo.Add(teste);
                }

            }

            File.Delete(fullPath);
            return testesVivo;
        }
        #endregion

        #region Inserindo dados na planilha Vivo
        internal MemoryStream DownloadTestesVivo(List<TestesVivo> testesVivo, string codRelease, string url)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{codRelease}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));

            if (file.Exists)
            {
                file.Delete();
            }

            MemoryStream memoryStream = new MemoryStream();

            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Lista de Testes");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Cenario");
                row.CreateCell(1).SetCellValue("Prioridade");
                row.CreateCell(2).SetCellValue("Demanda");
                row.CreateCell(3).SetCellValue("Analista");
                row.CreateCell(4).SetCellValue("Status");
                row.CreateCell(5).SetCellValue("Sistema");
                row.CreateCell(6).SetCellValue("Plataforma");
                row.CreateCell(7).SetCellValue("Funcionalidade");
                row.CreateCell(8).SetCellValue("Size");
                row.CreateCell(9).SetCellValue("Tipo de Teste");
                row.CreateCell(10).SetCellValue("Descricao");
                row.CreateCell(11).SetCellValue("Resultado Esperado");
                row.CreateCell(12).SetCellValue("Tipo de Massa");
                row.CreateCell(13).SetCellValue("Massa");
                row.CreateCell(14).SetCellValue("Documento");
                row.CreateCell(15).SetCellValue("ICCID");
                row.CreateCell(16).SetCellValue("Linha Gerada");
                row.CreateCell(17).SetCellValue("Solicitação Gerada");
                row.CreateCell(18).SetCellValue("Observação");


                int countRow = 1;
                string status = "";

                foreach (TestesVivo teste in testesVivo)
                {
                    row = excelSheet.CreateRow(countRow);

                    switch (teste.Status)
                    {
                        case 0:
                            status = "Não executado";
                            break;
                        case 1:
                            status = "Em Execução";
                            break;
                        case 2:
                            status = "Em Execução";
                            break;
                        case 3:
                            status = "Executado com Erro";
                            break;
                        case 4:
                            status = "Executado com sucesso";
                            break;
                    }


                    row.CreateCell(0).SetCellValue(teste.Cenario);
                    row.CreateCell(1).SetCellValue(teste.Prioridade);
                    row.CreateCell(2).SetCellValue(teste.Demanda);
                    row.CreateCell(3).SetCellValue(teste.Analista);
                    row.CreateCell(4).SetCellValue(teste.Status);
                    row.CreateCell(5).SetCellValue(teste.Sistema);
                    row.CreateCell(6).SetCellValue(teste.Plataforma);
                    row.CreateCell(7).SetCellValue(teste.Funcionalidade);
                    row.CreateCell(8).SetCellValue(teste.Size);
                    row.CreateCell(9).SetCellValue(teste.TipoTeste);
                    row.CreateCell(10).SetCellValue(teste.Descricao);
                    row.CreateCell(11).SetCellValue(teste.ResultEsperado);
                    row.CreateCell(12).SetCellValue(teste.TipoMassa);
                    row.CreateCell(13).SetCellValue(teste.Massa);
                    row.CreateCell(14).SetCellValue(teste.Documento);
                    row.CreateCell(15).SetCellValue(teste.ICCID);
                    row.CreateCell(16).SetCellValue(teste.LinhaGerada);
                    row.CreateCell(17).SetCellValue(teste.SolicGerada);
                    row.CreateCell(18).SetCellValue(teste.Observacao);

                    countRow += 1;
                }

                workbook.Write(fs);

            }

            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                stream.CopyTo(memoryStream);
            }
            memoryStream.Position = 0;

            File.Delete(Path.Combine(sWebRootFolder, sFileName));

            return memoryStream;
        }
        #endregion
    }
}
