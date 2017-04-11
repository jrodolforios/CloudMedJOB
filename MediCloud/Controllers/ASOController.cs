using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Financeiro;
using MediCloud.Code.Parametro;
using MediCloud.Models.Cliente;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Parametro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ASOController : BaseController
    {
        // GET: ASO
        public ActionResult Index()
        {
            base.EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";

                List<ASOModel> model = CadastroDeASO.buscarCargo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoASO(int? codigoASO)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";

                ASOModel model = CadastroDeASO.RecuperarASOPorID(codigoASO.HasValue ? codigoASO.Value : 0);

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult ExcluirProcedimento(int codigoProcedimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeProcedimentosMovimento.DeletarProcedimentoMovimento(this, codigoProcedimento);

                resultado.mensagem = "Procedimento excluído.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoASO(FormCollection form)
        {
            ASOModel modelASO = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";
                int codigoASO = 0;

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                if (!Int32.TryParse(form["codigoASO"], out codigoASO) || codigoASO <= 0)
                    form["usuario"] = base.CurrentUser.login;

                modelASO = CadastroDeASO.SalvarASO(form);

                base.FlashMessage("ASO cadastrado.", MessageType.Success);
                return View(modelASO);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoASO"]))
                    modelASO = CadastroDeASO.RecuperarASOPorID(Convert.ToInt32(form["codigoASO"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelASO);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult SalvarProcedimentoMovimento(FormCollection form)
        {
            ProcedimentoMovimentoModel modelProcedimentoMovimento = null;
            int codigoASO = Convert.ToInt32(form["codigoASOProcedimento"]);
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";
                int codigoProcedimento = 0;

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                if (!Int32.TryParse(form["codigoProcedimento"], out codigoProcedimento) || codigoProcedimento <= 0)
                    form["usuarioProcedimento"] = base.CurrentUser.login;

                modelProcedimentoMovimento = CadastroDeProcedimentosMovimento.SalvarProcedimentoMovimento(form);

                base.FlashMessage("Procedimento cadastrado.", MessageType.Success);
                Response.Redirect($"/ASO/DetalhamentoASO?codigoASO={codigoASO}");
            }
            catch (InvalidOperationException ex)
            {
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/ASO/DetalhamentoASO?codigoASO={codigoASO}");
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/ASO/DetalhamentoASO?codigoASO={codigoASO}");
            }

            return null;
        }

        [HttpPost]
        public JsonResult DetalharProcedimentoMovimento(int codigoDoProcedimentoMovimento)
        {
            try
            {
                ProcedimentoMovimentoModel contadoresEncontrados = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID(codigoDoProcedimentoMovimento);


                return Json(contadoresEncontrados, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

    }
}