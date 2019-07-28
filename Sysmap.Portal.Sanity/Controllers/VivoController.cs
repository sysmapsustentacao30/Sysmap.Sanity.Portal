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
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Sysmap.Portal.Sanity.DAO;
using Sysmap.Portal.Sanity.Extensions;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.Controllers
{
    public class VivoController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public VivoController(IHostingEnvironment hostingEnvironment, ILogger<VivoController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        #region Vivo home
        // GET: Vivo
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult VivoHome()
        {
           
            return View();
        }
        #endregion

        #region Lista de Releases Ativas
        [HttpGet]
        public IActionResult ReleasesAtivasVivo([FromServices]VivoDAO vivoDAO)
        {
            List<VivoRelease> releases = vivoDAO.GetReleasesVivoAtivas();
            return View(releases);
        }
        #endregion

        #region Cadastrar uma nova release
        [HttpGet]
        public IActionResult CadastrarReleaseVivo()
        {
            ViewBag.Erro = false;

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarReleaseVivo(VivoRelease vivoRelease, IFormFile excel, int qtdTestes, [FromServices]VivoDAO vivoDAO)
        {
            ViewBag.Erro = false;
            if (excel is null)
            {
                ModelState.AddModelError("", "Arquivo da planilha não encontrado!");
            }

            if(qtdTestes == 0)
            {
                ModelState.AddModelError("", "Quantidade de testes é obrigatório!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            //Criando Release
            List<VivoRelease> releases = vivoDAO.GetListReleaseVivo();
            if(!releases.Any(r => r.CodRelease == vivoRelease.CodRelease))
            {
                bool insert = vivoDAO.InsertReleaseVivo(vivoRelease);
                if (!insert)
                {
                    ModelState.AddModelError("", "Erro ao cadastratar release! Informe o Administrador do site!");
                }
            }
            else
            {
                ModelState.AddModelError("CodRelease", "CRQ já cadastrada!");
                return View();
            }
            //

            //Lendo Planilha
            releases = vivoDAO.GetListReleaseVivo();
            VivoRelease releaseCadastrada = releases.Where(r => r.CodRelease == vivoRelease.CodRelease).First();

            ReadExcel readExcel = new ReadExcel(_hostingEnvironment);
            List<TestesVivo> listTeste = readExcel.VivoPlanTestes(excel, qtdTestes, releaseCadastrada.CodRelease, releaseCadastrada.IdRelease);
            vivoDAO.InsertTestesVivo(listTeste);
            //

            ViewBag.Erro = true;
            return View();
        }
        #endregion

        #region Historico de releases
        [HttpGet]
        [Authorize(Roles = "All-Admin,All-User,Vivo-Admin,Vivo-User")]
        public IActionResult HistoricoReleaseVivo([FromServices]VivoDAO vivoDAO)
        {
            List<VivoRelease> vivoReleases = vivoDAO.GetListReleaseVivo();

            return View(vivoReleases.OrderByDescending(r => r.DataRelease));
        }
        #endregion

        #region Deleta Release
        [HttpPost]
        public IActionResult DeletaReleaseVivo(string codRelease, [FromServices]VivoDAO vivoDAO)
        {
            vivoDAO.DeletaReleaseVivo(codRelease);

            return RedirectToAction("ReleasesAtivasVivo", "Vivo");
        }
        #endregion

        #region Atualiza status da release
        [HttpPost]
        public IActionResult AtualizaReleaseVivo(string codRelease, int status, [FromServices]VivoDAO vivoDAO)
        {
            vivoDAO.AtualizaReleaseVivo(codRelease, status);

            return RedirectToAction("ReleasesAtivasVivo", "Vivo");
        }
        #endregion

        #region Download para excel
        [HttpGet]
        public IActionResult ExportRelease(int idRelease, string codRelease,[FromServices]VivoDAO vivoDAO)
        {
            ReadExcel readExcel = new ReadExcel(_hostingEnvironment);

            List<TestesVivo> testesVivo = vivoDAO.ListaTestesVivo(idRelease);

            string url = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, $"{codRelease}.xlsx");
            MemoryStream memoryStream = readExcel.DownloadTestesVivo(testesVivo, codRelease, url);

            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{codRelease}.xlsx");
        }
        #endregion

        #region Lista de Testes
        [HttpGet]
        public IActionResult ListaTestes(int idRelease,[FromServices]VivoDAO vivoDAO)
        {
            List<TestesVivo> testes = vivoDAO.ListaTestesVivo(idRelease);
            ViewBag.CodRelease = testes.Select(t => t.CodRelease).FirstOrDefault();
            return View(testes);
        }
        #endregion

        #region Editar Teste
        [HttpGet]
        public IActionResult EditarTeste(int idTeste,[FromServices]VivoDAO vivoDAO)
        {
            TestesVivo teste = vivoDAO.GetTesteVivo(idTeste) ;
            ViewBag.CodRelease = teste.CodRelease;
            return View(teste);
        }

        [HttpPost]
        public IActionResult EditarTeste(TestesVivo teste, [FromServices]VivoDAO vivoDAO)
        {
            vivoDAO.UpdateTesteVivo(teste);
            return RedirectToAction("ListaTestes","Vivo",new { idRelease = teste.IdRelease });
        }
        #endregion

    }
}