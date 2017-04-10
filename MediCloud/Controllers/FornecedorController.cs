using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Fornecedor;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class FornecedorController : BaseController
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            this.EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscaFornecedorAJAX(string Prefix)
        {
            List<FornecedorModel> contadoresEncontrados = CadastroDeFornecedor.RecuperarContadorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdFornecedor, Name = x.NomeFantasia });
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