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
    public class ProfissionalController : BaseController
    {
        // GET: Profissional
        public ActionResult Index()
        {
            this.EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscarProfissionalAJAX(string Prefix)
        {
            List<ProfissionalModel> contadoresEncontrados = CadastroDeProfissional.RecuperarContadorPorTermo(Prefix);
            List<AutoCompleteStringIDModel> ObjList = new List<AutoCompleteStringIDModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteStringIDModel() { Id = x.IdProfissional, Name = x.NomeProfissional });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteStringIDModel>()
                {
                new AutoCompleteStringIDModel {Id="-1",Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
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
                ViewBag.Title = "Profissionais";

                List<ProfissionalModel> model = CadastroDeProfissional.RecuperarContadorPorTermo(form);

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
        public JsonResult DeletarProfissional(string codigoDoProfissional)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeProfissional.DeletarProfissional(codigoDoProfissional);

                resultado.mensagem = "Profissional excluído.";
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

        public ActionResult ExcluirProfissional(string codigoProfissional)
        {
            ProfissionalModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Profissional";

                CadastroDeProfissional.DeletarProfissional(codigoProfissional);

                base.FlashMessage("Profissional excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeProfissional.GetProfissionalPorID(codigoProfissional);

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoProfissional(string codigoProfissional)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Profissional";

                ProfissionalModel model = CadastroDeProfissional.GetProfissionalPorID(codigoProfissional);

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
        public ActionResult DetalhamentoProfissional(FormCollection form)
        {
            ProfissionalModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Profissional";

                modelFuncionario = CadastroDeProfissional.SalvarProfissional(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeProfissional.GetProfissionalPorID(form["codigoProfissional"]);

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