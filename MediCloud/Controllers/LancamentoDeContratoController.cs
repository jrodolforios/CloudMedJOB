using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Financeiro;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class LancamentoDeContratoController : BaseController
    {
        // GET: LancamentoDeContrato
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Lançamento de contrato";

                List<LancamentoDeContratoModel> model = CadastroDeLancamentoDeContrato.RecuperarLancamentoPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoLancamentoDeContrato(int? codigoLancamentoDeContrato)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Contrato Fixo";

                LancamentoDeContratoModel model = CadastroDeLancamentoDeContrato.RecuperarLancamentoPorID(codigoLancamentoDeContrato.HasValue ? codigoLancamentoDeContrato.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoLancamentoDeContrato(FormCollection form)
        {
            LancamentoDeContratoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Contrato Fixo";

                modelFuncionario = CadastroDeLancamentoDeContrato.SalvarLancamentoDeContrato(form, CurrentUser.login);

                base.FlashMessage("Lançamento cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoLancamentoDeContrato"]))
                    modelFuncionario = CadastroDeLancamentoDeContrato.RecuperarLancamentoPorID(Convert.ToInt32(form["codigoLancamentoDeContrato"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult LancarMovimentos(int codigoDoLancamentoDeContrato)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeLancamentoDeContrato.lancarMovimentos(codigoDoLancamentoDeContrato);

                resultado.mensagem = "Movimentos lançados";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult RevisarDetalhes(int codigoDoLancamentoDeContrato)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeLancamentoDeContrato.RevisarDetalhes(codigoDoLancamentoDeContrato);

                resultado.mensagem = "Detalhes revisados e atualizados";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}