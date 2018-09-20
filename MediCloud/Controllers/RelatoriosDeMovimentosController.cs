using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Financeiro.Reports;
using MediCloud.Code.Reports.Clientes;
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

                arquivo = CadastroDeRelatoriosDeMovimentos.GerarRelatorioDeConvocacoes(form);

                byte[] fileBytes = arquivo;
                string fileName = "Relatório de Convocações - " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/RelatoriosDeMovimentos/RelatorioDeConvocacoes");
                return null;
            }
        }
        #endregion

        #region Relatório Anual 
        public ActionResult RelatorioAnual()
        {
            base.EstahLogado();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RelatorioAnual(FormCollection form)
        {
            byte[] arquivo = null;
            try
            {
                 base.EstahLogado();

                arquivo = CadastroDeRelatoriosDeMovimentos.GerarRelatorioAnual(form);

                byte[] fileBytes = arquivo;
                string fileName = "Relatório Anual - " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/RelatoriosDeMovimentos/RelatorioAnual");
                return null;
            }
        }
        #endregion
    }
}