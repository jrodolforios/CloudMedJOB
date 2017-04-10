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
    public class ProcedimentoController : BaseController
    {
        // GET: Procedimento
        public ActionResult Index()
        {
            this.EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscarProcedimentoByFornecedorAJAX(string Prefix, int Fornecedor)
        {
            List<ProcedimentoModel> contadoresEncontrados = CadastroDeProcedimentos.RecuperarContadorPorTermoEFornecedor(Prefix, Fornecedor);
            List<AutoCompleteProcendimentoMovimentoModel> ObjList = new List<AutoCompleteProcendimentoMovimentoModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteProcendimentoMovimentoModel() { Id = x.IdProcedimento, Name = x.Nome, Value = CadastroDeProcedimentos.BuscarValorProcedimentoPorIDFornecedor(x.IdProcedimento, Fornecedor) });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name, N.Value }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ObjList = new List<AutoCompleteProcendimentoMovimentoModel>()
                {
                new AutoCompleteProcendimentoMovimentoModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO, Value = -1 },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}