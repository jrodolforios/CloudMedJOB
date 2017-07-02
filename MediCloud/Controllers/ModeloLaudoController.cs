using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Laudo;
using MediCloud.Models.Laudo;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ModeloLaudoController : BaseController
    {
        // GET: ModeloLaudo
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

                List<ModeloLaudoModel> model = CadastroDeModeloLaudo.buscarModeloLaudo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoModeloLaudo(int? codigoModeloLaudo)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Modelo de laudo";

                ModeloLaudoModel model = CadastroDeModeloLaudo.RecuperarModeloPorID(codigoModeloLaudo.HasValue ? codigoModeloLaudo.Value : 0);

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
        public ActionResult DetalhamentoModeloLaudo(FormCollection form)
        {
            ModeloLaudoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cargo";

                modelFuncionario = CadastroDeModeloLaudo.SalvarModeloLaudo(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeModeloLaudo.RecuperarModeloPorID(Convert.ToInt32(form["codigoCargo"]));

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
        public JsonResult DeletarModeloLaudo(int codigoModeloLaudo)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeModeloLaudo.DeletarModeloLaudo(this, codigoModeloLaudo);

                resultado.mensagem = "Modelo de laudo excluído.";
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
        public JsonResult BuscaModeloAJAX(string Prefix)
        {
            EstahLogado();
            List<ModeloLaudoModel> contadoresEncontrados = CadastroDeModeloLaudo.RecuperarModeloLaudoPorTermo(Prefix);
            List<AutoCompleteDefaultModeloLaudoModel> ObjList = new List<AutoCompleteDefaultModeloLaudoModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModeloLaudoModel() { Id = x.IdModeloLaudo, Name = x.NomeModelo, Conclusao = x.Conclusao, Laudo = x.CorpoModelo, Rodape = x.Rodape });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name, N.Conclusao, N.Laudo, N.Rodape }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteDefaultModeloLaudoModel>()
                {
                new AutoCompleteDefaultModeloLaudoModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExcluirModeloLaudo(int codigoModeloLaudo)
        {
            ModeloLaudoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Modelo de laudo";

                CadastroDeModeloLaudo.DeletarModeloLaudo(this, codigoModeloLaudo);

                base.FlashMessage("Modelo excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeModeloLaudo.RecuperarModeloPorID(Convert.ToInt32(codigoModeloLaudo));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }
    }
}