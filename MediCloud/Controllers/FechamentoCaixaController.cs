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
    public class FechamentoCaixaController : BaseController
    {
        // GET: FechamentoCaixa
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
                ViewBag.Title = "Caixa";

                List<FechamentoCaixaModel> model = CadastroDeFechamentoCaixa.RecuperarFechamentoCaixaPorTermo(form);

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
        public JsonResult DeletarFechamentoCaixa(int codigoDoFechamentoCaixa)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFechamentoCaixa.DeletarFechamentoCaixa(codigoDoFechamentoCaixa);

                resultado.mensagem = "Caixa excluído.";
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

        public ActionResult ExcluirFechamentoCaixa(int codigoFechamentoCaixa)
        {
            FechamentoCaixaModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Caixa";

                CadastroDeFechamentoCaixa.DeletarFechamentoCaixa(codigoFechamentoCaixa); 

                base.FlashMessage("Caixa excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeFechamentoCaixa.buscarFechamentoCaixaPorID(Convert.ToInt32(codigoFechamentoCaixa));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoFechamentoCaixa(int? codigoFechamentoCaixa)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Caixa";

                FechamentoCaixaModel model = CadastroDeFechamentoCaixa.buscarFechamentoCaixaPorID(codigoFechamentoCaixa.HasValue ? codigoFechamentoCaixa.Value : 0);

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
        public ActionResult DetalhamentoFechamentoCaixa(FormCollection form)
        {
            FechamentoCaixaModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Caixa";

                if (string.IsNullOrEmpty(form["codigoFechamentoCaixa"]) || Convert.ToInt32(form["codigoFechamentoCaixa"]) <= 0)
                    form["usuario"] = base.CurrentUser.login;

                modelFuncionario = CadastroDeFechamentoCaixa.SalvarFechamentoCaixa(form);

                base.FlashMessage("Caixa cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoFechamentoCaixa"]))
                    modelFuncionario = CadastroDeFechamentoCaixa.buscarFechamentoCaixaPorID(Convert.ToInt32(form["codigoFechamentoCaixa"]));

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

        public ActionResult FecharCaixa(int codigoFechamentoCaixa)
        {
             ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFechamentoCaixa.FecharCaixa(codigoFechamentoCaixa);

                resultado.mensagem = "Ação executada.";
                resultado.acaoBemSucedida = true;

                Response.Redirect($"/FechamentoCaixa/DetalhamentoFechamentoCaixa?codigoFechamentoCaixa={codigoFechamentoCaixa}");
                return null;
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                Response.Redirect($"/FechamentoCaixa/DetalhamentoFechamentoCaixa?codigoFechamentoCaixa={codigoFechamentoCaixa}");
                return null;
            }
        }
    }
}