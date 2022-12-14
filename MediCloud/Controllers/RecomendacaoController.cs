using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Recomendacao;
using MediCloud.Models.Recomendacao;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class RecomendacaoController : BaseController
    {
        // GET: Recomendacao
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
                ViewBag.Title = "Usuários";

                List<RecomendacaoModel> model = CadastroDeRecomendacao.BuscarRecomendacaoMaterializandoClasses(form);

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
        public JsonResult DeletarRecomendacao(int codigoDoRecomendacao)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRecomendacao.DeletarRecomendacao(this, codigoDoRecomendacao);

                resultado.mensagem = "Recomendacao excluída.";
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
        public JsonResult DeletarRisco(int codigoRecomendacao, int codigoRisco)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRecomendacao.DeletarRiscoDeRecomendacao(codigoRecomendacao, codigoRisco);

                resultado.mensagem = "Risco excluído.";
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
        public JsonResult DeletarProcedimento(int codigoRecomendacao, int codigoReferencia, int codigoprocedimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRecomendacao.DeletarProcedimentoDeRecomendacao(codigoRecomendacao, codigoReferencia, codigoprocedimento);

                resultado.mensagem = "Procedimento excluído.";
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

        public ActionResult ExcluirRecomendacao(int codigoRecomendacao)
        {
            RecomendacaoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeRecomendacao.DeletarRecomendacao(this, codigoRecomendacao);

                base.FlashMessage("Recomendacao excluída.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeRecomendacao.RecuperarRecomendacaoPorIDMaterializandoClasses(Convert.ToInt32(codigoRecomendacao));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult ExcluirReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            RecomendacaoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeRecomendacao.DeletarReferencia(codigoRecomendacao, codigoReferencia);

                base.FlashMessage("Referência excluída.", MessageType.Success);

                Response.Redirect("/Recomendacao/DetalhamentoRecomendacao?codigoRecomendacao=" + codigoRecomendacao);
                return null;
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeRecomendacao.RecuperarRecomendacaoPorIDMaterializandoClasses(Convert.ToInt32(codigoRecomendacao));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoRecomendacao(int? codigoRecomendacao)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cargo";

                RecomendacaoModel model = CadastroDeRecomendacao.RecuperarRecomendacaoPorIDMaterializandoClasses(codigoRecomendacao.HasValue ? codigoRecomendacao.Value : 0);

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
        public ActionResult DetalhamentoRecomendacao(FormCollection form)
        {
            RecomendacaoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Recomendação";

                modelFuncionario = CadastroDeRecomendacao.SalvarRecomendacao(form);

                base.FlashMessage("Recomendação cadastrada.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoRecomendacao"]))
                    modelFuncionario = CadastroDeRecomendacao.RecuperarRecomendacaoPorIDMaterializandoClasses(Convert.ToInt32(form["codigoRecomendacao"]));

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
        public JsonResult AdicionarRisco(int codigoRecomendacao, int codigoRisco)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRecomendacao.AdicionarRisco(codigoRecomendacao, codigoRisco);

                resultado.mensagem = "Risco adicionado.";
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
        public JsonResult AdicionarReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRecomendacao.AdicionarReferencia(codigoRecomendacao, codigoReferencia);

                resultado.mensagem = "Referência adicionada.";
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
        public JsonResult AdicionarProcedimento(int codigoRecomendacao, int codigoProcedimento, int codigoReferente)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRecomendacao.AdicionarProcedimento(codigoRecomendacao, codigoProcedimento, codigoReferente);

                resultado.mensagem = "Procedimento adicionado.";
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
        public JsonResult RecuperarPeriodicidade(int IdProcedimento, int IdRecomendacao, int IdReferencia)
        {
            try
            {
                int? Periodicidade = CadastroDeRecomendacao.recuperarPeriodicidadeDeProcedimento(IdProcedimento, IdRecomendacao, IdReferencia);


                return Json(Periodicidade, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SalvarPeriodicidade(int IdProcedimento, int IdRecomendacao, int IdReferencia, int Periodicidade)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Recomendação";

                CadastroDeRecomendacao.AlterarPeriodicidade(IdProcedimento, IdRecomendacao, IdReferencia, Periodicidade);

                resultado.mensagem = "Periodicidade alterada.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (InvalidOperationException ex)
            {
                resultado.mensagem = "Não foi possível alterar a periodicidade. " + ex.Message;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = "Não foi possível alterar a periodicidade. " + ex.Message;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}