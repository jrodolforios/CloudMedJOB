using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Financeiro.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class RelatoriosFinanceirosController : BaseController
    {
        // GET: RelatorioMovimentos
        public ActionResult RelatorioDeMovimento()
        {
            base.EstahLogado();

            return View();
        }

        [HttpPost]
        public ActionResult RelatorioDeMovimento(FormCollection form)
        {
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                arquivo = CadastroDeRelatoriosFinanceiros.GerarRelatorioDeMovimentos(form);

                byte[] fileBytes = arquivo;
                string fileName = "Relatório de movimentos - " + DateTime.Now.ToShortDateString().Replace('/','-') + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }
    }
}