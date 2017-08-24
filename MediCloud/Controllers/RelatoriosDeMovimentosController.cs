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
    public class RelatoriosDeMovimentosController : BaseController
    { 

        #region Relatório de Convocações
        public ActionResult RelatorioDeConvocacoes()
        {
            base.EstahLogado();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RelatorioDeConvocacoes(FormCollection form)
        {
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                arquivo = CadastroDeRelatoriosFinanceiros.GerarRelatorioAnaliticoDeFaturamento(form);

                byte[] fileBytes = arquivo;
                string fileName = "Relatório Analitico de Faturamento - " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".pdf";
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
        #endregion
    }
}