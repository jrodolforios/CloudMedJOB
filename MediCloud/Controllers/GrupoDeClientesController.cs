using MediCloud.App_Code;
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
    public class GrupoDeClientesController : BaseController
    {
        // GET: GrupoDeClientes
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
                ViewBag.Title = "Grupo de clientes";

                List<GrupoDeClientesModel> model = CadastroDeGrupoDeClientes.RecuperarSegmentoPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarGrupoDeClientes(int codigoDoGrupoDeClientes)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeGrupoDeClientes.DeletarGrupoDeClientes(codigoDoGrupoDeClientes);

                resultado.mensagem = "Grupo de clientes excluído.";
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

        public ActionResult ExcluirGrupoDeClientes(int codigoGrupoDeClientes)
        {
            GrupoDeClientesModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Grupo de clientes";

                CadastroDeGrupoDeClientes.DeletarGrupoDeClientes(codigoGrupoDeClientes);

                base.FlashMessage("Grupo de clientes excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(Convert.ToInt32(codigoGrupoDeClientes));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoGrupoDeClientes(int? codigoGrupoDeClientes)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Grupo de clientes";

                GrupoDeClientesModel model = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(codigoGrupoDeClientes.HasValue ? codigoGrupoDeClientes.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoGrupoDeClientes(FormCollection form)
        {
            GrupoDeClientesModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Grupo de clientes";

                modelFuncionario = CadastroDeGrupoDeClientes.SalvarGrupoDeClientes(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(Convert.ToInt32(form["codigoGrupoDeClientes"]));

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
        public JsonResult BloquearCrediarioDeGrupo(int codigoDoGrupo)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeGrupoDeClientes.BloquearCrediarioDeGrupo(codigoDoGrupo);

                resultado.mensagem = "Ação executada";
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

        [HttpPost]
        public JsonResult BuscaGrupoDeClientesAJAX(string Prefix)
        {
            List<GrupoDeClientesModel> contadoresEncontrados = CadastroDeGrupoDeClientes.RecuperarSegmentoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdGrupoCliente, Name = x.NomeGrupo });
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