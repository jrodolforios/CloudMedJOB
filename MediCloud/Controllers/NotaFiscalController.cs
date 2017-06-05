using MediCloud.App_Code;
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
    public class NotaFiscalController : BaseController
    {
        // GET: NotaFiscal
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
                ViewBag.Title = "Notas Fiscais";

                List<NotaFiscalModel> model = CadastroDeNotaFiscal.RecuperarNotaFiscalPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoNotaFiscal(int? codigoNotaFiscal)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Nota Fiscal";

                NotaFiscalModel model = CadastroDeNotaFiscal.RecuperarNotaFiscalPorID(codigoNotaFiscal.HasValue ? codigoNotaFiscal.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarNotaFiscal(int codigoDaNotaFiscal)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeNotaFiscal.ExcluirNotaFiscal(codigoDaNotaFiscal);

                resultado.mensagem = "Nota Fiscal excluída.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult DetalharNotaFiscal(int codigoDoNotaFiscal)
        {
            try
            {
                NotaFiscalModel contadoresEncontrados = CadastroDeNotaFiscal.RecuperarNotaFiscalPorID(codigoDoNotaFiscal);


                return Json(contadoresEncontrados, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}