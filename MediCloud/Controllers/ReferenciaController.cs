using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Recomendacao;
using MediCloud.Models.Cliente;
using MediCloud.Models.Recomendacao;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ReferenciaController : BaseController
    {
        // GET: Referencia
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult DeletarReferencia(int codigoReferencia)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeReferente.DeletarReferencia(codigoReferencia);

                resultado.mensagem = "Referencia excluída.";
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
        public JsonResult BuscaReferenciaAJAX(string Prefix)
        {
            List<ReferenteModel> contadoresEncontrados = CadastroDeReferente.BuscarReferentePorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdReferencia, Name = x.NomeReferencia });
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

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Referência";

                List<ReferenteModel> model = CadastroDeReferente.buscarReferencia(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoReferencia(int? codigoReferencia)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Referencia";

                ReferenteModel model = CadastroDeReferente.RecuperarReferentePorID(codigoReferencia.HasValue ? codigoReferencia.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoReferencia(FormCollection form)
        {
            ReferenteModel modelReferencia = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Referencia";

                modelReferencia = CadastroDeReferente.SalvarReferencia(form);

                base.FlashMessage("Referencia cadastrada.", MessageType.Success);
                return View(modelReferencia);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoReferencia"]))
                    modelReferencia = CadastroDeReferente.RecuperarReferentePorID(Convert.ToInt32(form["codigoReferencia"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelReferencia);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult ExcluirReferencia(int codigoReferencia)
        {
            SetorModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Referencia";

                CadastroDeReferente.DeletarReferencia(codigoReferencia);

                base.FlashMessage("Referencia excluída.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeSetor.buscarSetorPorID(Convert.ToInt32(codigoReferencia));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }
    }
}