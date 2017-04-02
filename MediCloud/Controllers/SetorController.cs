using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Recomendacao;
using MediCloud.Models.Recomendacao;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class SetorController : BaseController
    {
        // GET: Setor
        public ActionResult Index()
        {
            base.EstahLogado();

            return View();
        }

        [HttpPost]
        public JsonResult BuscaSetorAJAX(string Prefix)
        {

            List<SetorModel> contadoresEncontrados = CadastroDeSetor.RecuperarSetorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdSetor, Name = x.NomeSetor });
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