using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Parametro.GrupoProcedimento;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ProcedimentoController : BaseController
    {
        // GET: Procedimento
        public ActionResult Index()
        {
            this.EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setores";

                List<ProcedimentoModel> model = CadastroDeProcedimentos.buscarProcedimento(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoProcedimento(int? codigoProcedimento)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                ProcedimentoModel model = CadastroDeProcedimentos.RecuperarProcedimentoPorID(codigoProcedimento.HasValue ? codigoProcedimento.Value : 0);

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
        public ActionResult DetalhamentoProcedimento(FormCollection form)
        {
            ProcedimentoModel modelProcedimento = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Procedimento";

                modelProcedimento = CadastroDeProcedimentos.SalvarProcedimento(form);

                base.FlashMessage("Procedimento cadastrado.", MessageType.Success);
                return View(modelProcedimento);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoProcedimento"]))
                    modelProcedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID(Convert.ToInt32(form["codigoProcedimento"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelProcedimento);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarProcedimento(int codigoDoProcedimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeProcedimentos.DeletarProcedimento(this, codigoDoProcedimento);

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

        public ActionResult ExcluirProcedimento(int codigoProcedimento)
        {
            ProcedimentoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Procedimentos";

                CadastroDeProcedimentos.DeletarProcedimento(this, codigoProcedimento);

                base.FlashMessage("Procedimento excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeProcedimentos.RecuperarProcedimentoPorID(Convert.ToInt32(codigoProcedimento));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        [HttpPost]
        public JsonResult BuscarProcedimentoByFornecedorAJAX(string Prefix, int Fornecedor, int Tabela)
        {
            List<ProcedimentoModel> contadoresEncontrados = CadastroDeProcedimentos.RecuperarContadorPorTermoEFornecedor(Prefix.Trim(), Fornecedor, Tabela);
            List<AutoCompleteProcendimentoMovimentoModel> ObjList = new List<AutoCompleteProcendimentoMovimentoModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteProcendimentoMovimentoModel() { Id = x.IdProcedimento, Name = x.Nome, Value = CadastroDeProcedimentos.BuscarValorProcedimentoPorIDFornecedor(x.IdProcedimento, Fornecedor, Tabela) });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name, N.Value }).ToArray();
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

        [HttpPost]
        public JsonResult BuscarProcedimentoAJAX(string Prefix)
        {
            List<ProcedimentoModel> contadoresEncontrados = CadastroDeProcedimentos.RecuperarProcedimentoPorTermo(Prefix);
            List<AutoCompleteProcendimentoMovimentoModel> ObjList = new List<AutoCompleteProcendimentoMovimentoModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteProcendimentoMovimentoModel() { Id = x.IdProcedimento, Name = x.Nome });
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