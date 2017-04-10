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
    public class ProfissionalController : BaseController
    {
        // GET: Profissional
        public ActionResult Index()
        {
            this.EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscarProfissionalAJAX(string Prefix)
        {
            List<ProfissionalModel> contadoresEncontrados = CadastroDeProfissional.RecuperarContadorPorTermo(Prefix);
            List<AutoCompleteStringIDModel> ObjList = new List<AutoCompleteStringIDModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteStringIDModel() { Id = x.IdProfissional, Name = x.NomeProfissional });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ObjList = new List<AutoCompleteStringIDModel>()
                {
                new AutoCompleteStringIDModel {Id="-1",Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}