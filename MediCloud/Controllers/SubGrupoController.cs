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
    public class SubGrupoController : BaseController
    {
        // GET: SubGrupo
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
                ViewBag.Title = "Setores";

                List<SubGrupoModel> model = CadastroDeSubGrupo.RecuperarSubGrupoPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoSubGrupo(int? codigoSubGrupo)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                SubGrupoModel model = CadastroDeSubGrupo.GetSubGrupoPorID(codigoSubGrupo.HasValue ? codigoSubGrupo.Value : 0);

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
        public ActionResult DetalhamentoSubGrupo(FormCollection form)
        {
            SubGrupoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Sub grupo";

                modelFuncionario = CadastroDeSubGrupo.SalvarSubGrupo(form);

                base.FlashMessage("SubGrupo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoSubGrupo"]))
                    modelFuncionario = CadastroDeSubGrupo.GetSubGrupoPorID(Convert.ToInt32(form["codigoSubGrupo"]));

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
        public JsonResult DeletarSubGrupo(int codigoDoSubGrupo)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeSubGrupo.DeletarSubGrupo(this, codigoDoSubGrupo);

                resultado.mensagem = "Subgrupo excluído.";
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

        public ActionResult ExcluirSubGrupo(int codigoSubGrupo)
        {
            SubGrupoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Subgrupo";

                CadastroDeSubGrupo.DeletarSubGrupo(this, codigoSubGrupo);

                base.FlashMessage("Subgrupo excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeSubGrupo.GetSubGrupoPorID(Convert.ToInt32(codigoSubGrupo));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        [HttpPost]
        public JsonResult BuscarSubGrupoAJAX(string Prefix)
        {
            List<SubGrupoModel> contadoresEncontrados = CadastroDeSubGrupo.RecuperarSubGrupoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdSubGrupo, Name = x.Nome });
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
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO},
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}