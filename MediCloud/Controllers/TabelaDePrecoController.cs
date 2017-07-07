using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Parametro;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class TabelaDePrecoController : BaseController
    {
        // GET: TabelaDePreco
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
                ViewBag.Title = "Tabela de preços";

                List<TabelaPrecoModel> model = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorTermo(form);

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
        public JsonResult DeletarTabelaDePreco(int codigoDoTabelaDePreco)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeTabelaDePreco.DeletarTabelaDePreco(this, codigoDoTabelaDePreco);

                resultado.mensagem = "Tabela excluída.";
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
        public JsonResult ExcluirValorTabela(int codigoValorTabela)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeTabelaDePreco.DeletarValorTabela(codigoValorTabela);

                resultado.mensagem = "Valor de tabela excluído.";
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

        public ActionResult ExcluirTabelaDePreco(int codigoTabelaDePreco)
        {
            TabelaPrecoModel modelTabelaDePreco = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela excluída.";

                CadastroDeTabelaDePreco.DeletarTabelaDePreco(this, codigoTabelaDePreco);

                base.FlashMessage("Setor excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelTabelaDePreco = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(Convert.ToInt32(codigoTabelaDePreco));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelTabelaDePreco);
            }
        }

        public ActionResult DetalhamentoTabelaDePreco(int? codigoTabelaDePreco)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela de Preço";

                TabelaPrecoModel model = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(codigoTabelaDePreco.HasValue ? codigoTabelaDePreco.Value : 0);

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
        public ActionResult DetalhamentoTabelaDePreco(FormCollection form)
        {
            TabelaPrecoModel modelTabelaDePreco = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela de preço";

                modelTabelaDePreco = CadastroDeTabelaDePreco.SalvarTabela(form);

                base.FlashMessage("tabela cadastrada.", MessageType.Success);
                return View(modelTabelaDePreco);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoTabelaDePreco"]))
                    modelTabelaDePreco = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(Convert.ToInt32(form["codigoTabelaDePreco"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelTabelaDePreco);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult BuscaTabelaAJAX(string Prefix)
        {
            List<TabelaPrecoModel> contadoresEncontrados = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdTabela, Name = x.NomeTabela });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DetalharValorTabela(int codigoDoValorTabela)
        {
            try
            {
                ValorTabelaDePrecoModel valorTabelaDePreco = CadastroDeTabelaDePreco.buscarValorDeTabela(codigoDoValorTabela);


                return Json(valorTabelaDePreco, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                return Json(new AutoCompleteDefaultModel { Id = -1, Name = Constantes.MENSAGEM_GENERICA_DE_ERRO });
            }
        }

        [HttpPost]
        public ActionResult SalvarValorTabela(FormCollection form)
        {
            ValorTabelaDePrecoModel modelTabelaDePreco = null;
            int codigoTabela = Convert.ToInt32(form["codigoTabela"]);
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela de preços";
                int codigoProcedimento = 0;

                if (!Int32.TryParse(form["codigoProcedimento"], out codigoProcedimento) || codigoProcedimento <= 0)
                    form["usuarioProcedimento"] = base.CurrentUser.login;

                modelTabelaDePreco = CadastroDeTabelaDePreco.SalvarValorTabela(form);

                base.FlashMessage("Procedimento cadastrado.", MessageType.Success);
                Response.Redirect($"/TabelaDePreco/DetalhamentoTabelaDePreco?codigoTabelaDePreco={codigoTabela}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/TabelaDePreco/DetalhamentoTabelaDePreco?codigoTabelaDePreco={codigoTabela}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/TabelaDePreco/DetalhamentoTabelaDePreco?codigoTabelaDePreco={codigoTabela}");
            }

            return null;
        }
    }
}