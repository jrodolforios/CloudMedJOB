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
    public class FormaPagamentoController : BaseController
    {
        // GET: FormaPagamento
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
                ViewBag.Title = "Forma de pagamento";

                List<FormaPagamentoModel> model = CadastroFormaPagamento.RecuperarFormaPagamentoPorTermo(form);

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
        public JsonResult DeletarFormaPagamento(int codigoDoFormaPagamento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroFormaPagamento.DeletarFormaPagamento(this, codigoDoFormaPagamento);

                resultado.mensagem = "Forma de pagamento excluída.";
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

        public ActionResult ExcluirFormaPagamento(int codigoFormaPagamento)
        {
            FormaPagamentoModel modelFormaPagamento = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Forma de pagamento";

                CadastroFormaPagamento.DeletarFormaPagamento(this, codigoFormaPagamento);

                base.FlashMessage("Forma de pagamento excluída.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelFormaPagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(Convert.ToInt32(codigoFormaPagamento));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelFormaPagamento);
            }
        }

        public ActionResult DetalhamentoFormaPagamento(int? codigoFormaPagamento)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Forma de pagamento";

                FormaPagamentoModel model = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(codigoFormaPagamento.HasValue ? codigoFormaPagamento.Value : 0);

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
        public ActionResult DetalhamentoFormaPagamento(FormCollection form)
        {
            FormaPagamentoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Forma de pagamento";

                modelFuncionario = CadastroFormaPagamento.SalvarFormaPagamento(form);

                base.FlashMessage("Forma de pagamento cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoFormaPagamento"]))
                    modelFuncionario = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(Convert.ToInt32(form["codigoFormaPagamento"]));

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
        public JsonResult BuscaFormaPagamentoAJAX(string Prefix)
        {
            List<FormaPagamentoModel> contadoresEncontrados = CadastroFormaPagamento.RecuperarFormaPagamentoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdFormaPagamento, Name = x.NomeFormaPagamento });
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