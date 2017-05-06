using MediCloud.App_Code;
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
    public class GrupoDeProcedimentoController : BaseController
    {
        // GET: GrupoDeProcedimento
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
                ViewBag.Title = "Grupos";

                List<GrupoModel> model = CadastroDeGrupo.RecuperarGrupoPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoGrupoDeProcedimento(int? codigoGrupoDeProcedimento)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                GrupoModel model = CadastroDeGrupo.getGrupoPorID(codigoGrupoDeProcedimento.HasValue ? codigoGrupoDeProcedimento.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoGrupoDeProcedimento(FormCollection form)
        {
            GrupoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                modelFuncionario = CadastroDeGrupo.SalvarGrupo(form);

                base.FlashMessage("Grupo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeGrupo.getGrupoPorID(Convert.ToInt32(form["codigoGrupoProcedimento"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarGrupoProcedimento(int codigoDoGrupoProcedimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeGrupo.DeletarGrupo(this, codigoDoGrupoProcedimento);

                resultado.mensagem = "Setor excluído.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExcluirGrupoProcedimento(int codigoDoGrupoProcedimento)
        {
            GrupoModel modelGrupo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                CadastroDeGrupo.DeletarGrupo(this, codigoDoGrupoProcedimento);

                base.FlashMessage("Setor excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelGrupo = CadastroDeGrupo.getGrupoPorID(Convert.ToInt32(codigoDoGrupoProcedimento));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelGrupo);
            }
        }

        [HttpPost]
        public JsonResult BuscaGrupoAJAX(string Prefix)
        {
            List<GrupoModel> contadoresEncontrados = CadastroDeGrupo.RecuperarGrupoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdGrupo, Name = x.Nome });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}