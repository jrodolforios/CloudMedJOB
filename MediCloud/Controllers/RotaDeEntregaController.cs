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
                modelRotaDeEntrega = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorID(Convert.ToInt32(codigoRotaDeEntrega));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelRotaDeEntrega);
            }
        }
    }
}