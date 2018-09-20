using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Financeiro;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ContadorController : BaseController
    {
        #region Public Methods

        [HttpPost]
        public JsonResult BuscaContadorAJAX(string Prefix)
        {
            List<ContadorModel> contadoresEncontrados = CadastroDeContador.RecuperarContadorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdContador, Name = x.NomeContador });
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
        public JsonResult DeletarContador(int codigoDoContador)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeContador.DeletarContador(this, codigoDoContador);

                resultado.mensagem = "Contador excluído.";
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

        public ActionResult DetalhamentoContador(int? codigoContador)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Contador";

                ContadorModel model = CadastroDeContador.RecuperarContadorPorID(codigoContador.HasValue ? codigoContador.Value : 0);

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
        public ActionResult DetalhamentoContador(FormCollection form)
        {
            ContadorModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Contador";

                modelFuncionario = CadastroDeContador.SalvarContador(form);

                base.FlashMessage("Contador cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoContador"]))
                    modelFuncionario = CadastroDeContador.RecuperarContadorPorID(Convert.ToInt32(form["codigoContador"]));

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

        public ActionResult ExcluirContador(int codigoContador)
        {
            ContadorModel modelContador = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Contador";

                CadastroDeContador.DeletarContador(this, codigoContador);

                base.FlashMessage("Contador excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelContador = CadastroDeContador.RecuperarContadorPorID(Convert.ToInt32(codigoContador));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelContador);
            }
        }

        // GET: Contador
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
                ViewBag.Title = "Contadores";

                List<ContadorModel> model = CadastroDeContador.RecuperarContadorPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        #endregion Public Methods
    }
}