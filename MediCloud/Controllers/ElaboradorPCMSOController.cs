using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Parametro;
using MediCloud.Models.Parametro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ElaboradorPCMSOController : BaseController
    {
        // GET: ElaboradorPCMSO
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscaElaboradorAJAX(string Prefix)
        {
            List<ElaboradorPCMSOModel> contadoresEncontrados = CadastroDeElaboradorPCMSO.RecuperarElaboradorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdElaboradorPCMSO, Name = x.NomeElaboradorPCMSO });
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
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Elaborador PCMSO";

                List<ElaboradorPCMSOModel> model = CadastroDeElaboradorPCMSO.RecuperarElaboradorPorTermo(form);

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
        public JsonResult DeletarElaboradorPCMSO(int codigoDoElaboradorPCMSO)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeElaboradorPCMSO.DeletarElaboradorPCMSO(codigoDoElaboradorPCMSO);

                resultado.mensagem = "Elaborador PCMSO excluído.";
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

        public ActionResult ExcluirElaboradorPCMSO(int codigoElaboradorPCMSO)
        {
            ElaboradorPCMSOModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "ElaboradorPCMSO";

                CadastroDeElaboradorPCMSO.DeletarElaboradorPCMSO(codigoElaboradorPCMSO);

                base.FlashMessage("ElaboradorPCMSO excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeElaboradorPCMSO.BuscarElaboradorPorID(Convert.ToInt32(codigoElaboradorPCMSO));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoElaboradorPCMSO(int? codigoElaboradorPCMSO)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Elaborador PCMSO";

                ElaboradorPCMSOModel model = CadastroDeElaboradorPCMSO.BuscarElaboradorPorID(codigoElaboradorPCMSO.HasValue ? codigoElaboradorPCMSO.Value : 0);

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
        public ActionResult DetalhamentoElaboradorPCMSO(FormCollection form)
        {
            ElaboradorPCMSOModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Elaborador PCMSO";

                modelFuncionario = CadastroDeElaboradorPCMSO.SalvarElaboradorPCMSO(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeElaboradorPCMSO.BuscarElaboradorPorID(Convert.ToInt32(form["codigoElaboradorPCMSO"]));

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

    }
}