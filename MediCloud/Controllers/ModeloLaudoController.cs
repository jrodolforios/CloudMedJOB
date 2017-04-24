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