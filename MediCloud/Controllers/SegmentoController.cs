using MediCloud.App_Code;
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
    public class SegmentoController : BaseController
    {
        // GET: Segmento
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscaSegmentoAJAX(string Prefix)
        {
            List<SegmentoModel> contadoresEncontrados = CadastroDeSegmento.RecuperarSegmentoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdSegmento, Name = x.NomeSegmento });
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
                ViewBag.Title = "Segmentos";

                List<SegmentoModel> model = CadastroDeSegmento.RecuperarSegmentoPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarSegmento(int codigoDoSegmento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeSegmento.DeletarSegmento(codigoDoSegmento);

                resultado.mensagem = "Segmento excluído.";
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

        public ActionResult ExcluirSegmento(int codigoSegmento)
        {
            SegmentoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Segmento";

                CadastroDeSegmento.DeletarSegmento(codigoSegmento);

                base.FlashMessage("Segmento excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeSegmento.buscarSegmentoPorID(Convert.ToInt32(codigoSegmento));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoSegmento(int? codigoSegmento)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Segmento";

                SegmentoModel model = CadastroDeSegmento.buscarSegmentoPorID(codigoSegmento.HasValue ? codigoSegmento.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoSegmento(FormCollection form)
        {
            SegmentoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Segmento";

                modelFuncionario = CadastroDeSegmento.SalvarSegmento(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeSegmento.buscarSegmentoPorID(Convert.ToInt32(form["codigoSegmento"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

    }
}