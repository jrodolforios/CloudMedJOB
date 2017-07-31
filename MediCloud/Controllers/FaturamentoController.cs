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
    public class FaturamentoController : BaseController
    {
        // GET: Faturamento
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
                ViewBag.Title = "Faturamentos";

                List<FaturamentoModel> model = CadastroDeFaturamento.RecuperarFaturamentoPorTermo(form);

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
        public JsonResult DeletarFaturamento(int codigoDoFaturamento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFaturamento.DeletarFaturamento(codigoDoFaturamento);

                resultado.mensagem = "Faturamento excluído.";
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

        public ActionResult ExcluirFaturamento(int codigoFaturamento)
        {
            FaturamentoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Faturamento";

                CadastroDeFaturamento.DeletarFaturamento(codigoFaturamento);

                base.FlashMessage("Faturamento excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeFaturamento.RecuperarFaturamentoPorID(Convert.ToInt32(codigoFaturamento));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoFaturamento(int? codigoFaturamento)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Faturamento";

                FaturamentoModel model = CadastroDeFaturamento.RecuperarFaturamentoPorID(codigoFaturamento.HasValue ? codigoFaturamento.Value : 0);

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
        public ActionResult DetalhamentoFaturamento(FormCollection form)
        {
            FaturamentoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Faturamento";

                modelFuncionario = CadastroDeFaturamento.SalvarFaturamento(form);

                base.FlashMessage("Faturamento cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoFaturamento"]))
                    modelFuncionario = CadastroDeFaturamento.RecuperarFaturamentoPorID(Convert.ToInt32(form["codigoFaturamento"]));

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
        public ActionResult SalvarNotaFiscal(FormCollection form)
        {
            int codigoFaturamento = Convert.ToInt32(form["codigoFaturamentoNotaFiscal"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Faturamento";

                NotaFiscalModel model = CadastroDeNotaFiscal.SalvarNotaFiscal(form);

                base.FlashMessage("Nota fiscal cadastrada.", MessageType.Success);
                Response.Redirect($"/Faturamento/DetalhamentoFaturamento?codigoFaturamento={codigoFaturamento}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/Faturamento/DetalhamentoFaturamento?codigoFaturamento={codigoFaturamento}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/Faturamento/DetalhamentoFaturamento?codigoFaturamento={codigoFaturamento}");
            }

            return null;
        }

        public ActionResult FecharFaturamento(int codigoFaturamento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFaturamento.FecharFaturamento(codigoFaturamento);

                resultado.mensagem = "Ação executada.";
                resultado.acaoBemSucedida = true;

                Response.Redirect($"/Faturamento/DetalhamentoFaturamento?codigoFaturamento={codigoFaturamento}");
                return null;
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                Response.Redirect($"/Faturamento/DetalhamentoFaturamento?codigoFaturamento={codigoFaturamento}");
                return null;
            }
        }

        [HttpPost]
        public JsonResult BuscaFaturamentoAJAX(string Prefix)
        {
            List<FaturamentoModel> contadoresEncontrados = CadastroDeFaturamento.RecuperarFaturamentoPorTermo(Prefix);
            List<AutoCompleteProcendimentoMovimentoModel> ObjList = new List<AutoCompleteProcendimentoMovimentoModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteProcendimentoMovimentoModel() { Id = x.IdFaturamento, Name = x.toString() });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteProcendimentoMovimentoModel>()
                {
                new AutoCompleteProcendimentoMovimentoModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO, Value = -1 },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

    }
}