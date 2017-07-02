using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Financeiro;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class RotaDeEntregaController : BaseController
    {
        // GET: RotaDeEntrega
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
                ViewBag.Title = "Rotas de entrega";

                List<RotaDeEntregaModel> model = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoRotaDeEntrega(int? codigoRotaDeEntrega)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Rota de entrega";

                RotaDeEntregaModel model = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorID(codigoRotaDeEntrega.HasValue ? codigoRotaDeEntrega.Value : 0);

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
        public ActionResult DetalhamentoRotaDeEntrega(FormCollection form)
        {
            RotaDeEntregaModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Rota de entrega";

                modelFuncionario = CadastroDeRotaDeEntrega.SalvarRotaDeEntrega(form);

                base.FlashMessage("Rota de entrega cadastrada.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoRotaDeEntrega"]))
                    modelFuncionario = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorID(Convert.ToInt32(form["codigoRotaDeEntrega"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarRotaDeEntrega(int codigoDoRotaDeEntrega)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel(); 
            try
            {
                base.EstahLogado();

                CadastroDeRotaDeEntrega.DeletarRotaDeEntrega(this, codigoDoRotaDeEntrega);

                resultado.mensagem = "Rota de entrega excluída.";
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

        public ActionResult ExcluirRotaDeEntrega(int codigoRotaDeEntrega)
        {
            RotaDeEntregaModel modelRotaDeEntrega = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Rota de entrega";

                CadastroDeRotaDeEntrega.DeletarRotaDeEntrega(this, codigoRotaDeEntrega);

                base.FlashMessage("Rota de entrega excluída.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelRotaDeEntrega = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorID(Convert.ToInt32(codigoRotaDeEntrega));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelRotaDeEntrega);
            }
        }

        [HttpPost]
        public JsonResult BuscaRotaDeEntregaAJAX(string Prefix)
        {
            List<RotaDeEntregaModel> contadoresEncontrados = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdRotaDeEntrega, Name = x.NomeRotaDeEntrega });
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