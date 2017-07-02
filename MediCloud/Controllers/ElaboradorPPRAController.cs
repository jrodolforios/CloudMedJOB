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
    public class ElaboradorPPRAController : BaseController
    {
        // GET: ElaboradorPPRA
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscaElaboradorAJAX(string Prefix)
        {
            List<ElaboradorPPRAModel> contadoresEncontrados = CadastroDeElaboradorPPRA.RecuperarElaboradorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdElaboradorPPRA, Name = x.NomeElaboradorDoPPRA});
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
                ViewBag.Title = "Elaborador PPRA";

                List<ElaboradorPPRAModel> model = CadastroDeElaboradorPPRA.RecuperarElaboradorPorTermo(form);

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
        public JsonResult DeletarElaboradorPPRA(int codigoDoElaboradorPPRA)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeElaboradorPPRA.DeletarElaboradorPPRA(codigoDoElaboradorPPRA);

                resultado.mensagem = "Elaborador PPRA excluído.";
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

        public ActionResult ExcluirElaboradorPPRA(int codigoElaboradorPPRA)
        {
            ElaboradorPPRAModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "ElaboradorPPRA";

                CadastroDeElaboradorPPRA.DeletarElaboradorPPRA(codigoElaboradorPPRA);

                base.FlashMessage("ElaboradorPPRA excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeElaboradorPPRA.BuscarElaboradorPorID(Convert.ToInt32(codigoElaboradorPPRA));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoElaboradorPPRA(int? codigoElaboradorPPRA)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Elaborador PPRA";

                ElaboradorPPRAModel model = CadastroDeElaboradorPPRA.BuscarElaboradorPorID(codigoElaboradorPPRA.HasValue ? codigoElaboradorPPRA.Value : 0);

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
        public ActionResult DetalhamentoElaboradorPPRA(FormCollection form)
        {
            ElaboradorPPRAModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Elaborador PPRA";

                modelFuncionario = CadastroDeElaboradorPPRA.SalvarElaboradorPPRA(form); 

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeElaboradorPPRA.BuscarElaboradorPorID(Convert.ToInt32(form["codigoElaboradorPPRA"]));

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