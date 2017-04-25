using MediCloud.App_Code;
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
                ObjList = new List<AutoCompleteDefaultModeloLaudoModel>()
                {
                new AutoCompleteDefaultModeloLaudoModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}