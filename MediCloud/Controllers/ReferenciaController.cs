using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Models.Cliente;
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
    }
}