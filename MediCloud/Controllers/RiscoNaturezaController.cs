using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
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
    public class RiscoNaturezaController : BaseController
    {
        // GET: RiscoNatureza
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

                List<NaturezaModel> model = CadastroDeRiscoNatureza.BuscarNaturezaPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoRiscoNatureza(int? codigoNatureza)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Natureza";

                NaturezaModel model = CadastroDeRiscoNatureza.RecuperarNaturezaPorID(codigoNatureza.HasValue ? codigoNatureza.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoRiscoNatureza(FormCollection form)
        {
            NaturezaModel modelNatureza = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Natureza";

                modelNatureza = CadastroDeRiscoNatureza.SalvarNatureza(form);

                base.FlashMessage("Natureza cadastrada.", MessageType.Success);
                return View(modelNatureza);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoNatureza"]))
                    modelNatureza = CadastroDeRiscoNatureza.RecuperarNaturezaPorID(Convert.ToInt32(form["codigoNatureza"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelNatureza);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult BuscaRiscoAJAX(string Prefix)
        {
            List<RiscoModel> contadoresEncontrados = CadastroDeRiscoNatureza.BuscarRiscosPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdRisco, Name = $"{x.NomeRisco} - {x.Natureza.NomeNatureza}" });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeletarNatureza(int codigoNatureza)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRiscoNatureza.DeletarNatureza(codigoNatureza);

                resultado.mensagem = "Natureza excluída.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ExcluirRisco(int codigoRisco)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeRiscoNatureza.DeletarRisco(codigoRisco);

                resultado.mensagem = "Risco excluído.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExcluirNatureza(int codigoNatureza)
        {
            NaturezaModel modelNatureza = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeRiscoNatureza.DeletarNatureza(codigoNatureza);

                base.FlashMessage("Cargo excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelNatureza = CadastroDeRiscoNatureza.RecuperarNaturezaPorID(Convert.ToInt32(codigoNatureza));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View("Index",modelNatureza);
            }
        }

        [HttpPost]
        public JsonResult DetalharRisco(int codigoRisco)
        {
            try
            {
                RiscoModel contadoresEncontrados = CadastroDeRiscoNatureza.BuscarRiscoPorID(codigoRisco);


                return Json(contadoresEncontrados, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SalvarRisco(FormCollection form)
        {
            int codigoNatureza = Convert.ToInt32(form["codigoNaturezaRisco"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Natureza";

                RiscoModel model = CadastroDeRiscoNatureza.SalvarRisco(form);

                base.FlashMessage("Risco cadastrado.", MessageType.Success);
                Response.Redirect($"/RiscoNatureza/DetalhamentoRiscoNatureza?codigoNatureza={codigoNatureza}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/RiscoNatureza/DetalhamentoRiscoNatureza?codigoNatureza={codigoNatureza}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/RiscoNatureza/DetalhamentoRiscoNatureza?codigoNatureza={codigoNatureza}");
            }

            return null;
        }
    }
}