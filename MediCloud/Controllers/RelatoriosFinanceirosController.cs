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
        #region Relatório de Movimentos
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
        #endregion

        #region Relatório Analítico de Faturamento
        public ActionResult RelatorioAnalitoDeFaturamento()
        {
            base.EstahLogado();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RelatorioAnalitoDeFaturamento(FormCollection form)
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