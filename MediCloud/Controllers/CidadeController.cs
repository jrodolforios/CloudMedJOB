using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
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
    public class CidadeController : BaseController
    {
        // GET: Cidade
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
                ViewBag.Title = "Cidades";

                List<CidadeModel> model = CadastroDeCidade.buscarCidade(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoCidade(int? codigoCidade)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cidade";

                CidadeModel model = CadastroDeCidade.RecuperarCidadePorID(codigoCidade.HasValue ? codigoCidade.Value : 0);

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
        public ActionResult DetalhamentoCidade(FormCollection form)
        {
            CidadeModel modelCIdade = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cidade";

                modelCIdade = CadastroDeCidade.SalvarCidade(form);

                base.FlashMessage("Cidade cadastrada.", MessageType.Success);
                return View(modelCIdade);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCidade"]))
                    modelCIdade = CadastroDeCidade.RecuperarCidadePorID(Convert.ToInt32(form["codigoCidade"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelCIdade);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarCidade(int codigoDoCidade)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeCidade.DeletarCidade(this, codigoDoCidade);

                resultado.mensagem = "Cidade excluída.";
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

        public ActionResult ExcluirCidade(int codigoCidade)
        {
            CidadeModel modelCidade = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                CadastroDeCidade.DeletarCidade(this, codigoCidade);

                base.FlashMessage("Setor excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCidade = CadastroDeCidade.RecuperarCidadePorID(Convert.ToInt32(codigoCidade));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCidade);
            }
        }

        [HttpPost]
        public JsonResult BuscaCidadeAJAX(string Prefix)
        {
            List<CidadeModel> contadoresEncontrados = CadastroDeCidade.buscarCidade(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdCidade, Name = x.NomeCidade });
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

    }
}