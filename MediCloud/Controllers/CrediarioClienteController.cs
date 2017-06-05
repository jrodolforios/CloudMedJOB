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
    public class CrediarioClienteController : BaseController
    {
        // GET: CrediarioCliente
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
                ViewBag.Title = "Crediários";

                List<CrediarioClienteModel> model = CadastroDeCrediarioCliente.RecuperarCrediarioClientePorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult BloquearCrediario(int codigoDoCrediario, bool Bloquear)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeCrediarioCliente.BloquearCrediario(this, codigoDoCrediario, Bloquear);

                resultado.mensagem = Bloquear ? "Crediário bloqueado." : "Crediário Desbloqueado";
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
        public JsonResult DeletarCrediarioCliente(int codigoDoCrediarioCliente)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeCrediarioCliente.DeletarCrediarioCliente(codigoDoCrediarioCliente);

                resultado.mensagem = "Crediário excluído.";
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

        public ActionResult ExcluirCrediarioCliente(int codigoCrediarioCliente)
        {
            CrediarioClienteModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Crediário de cliente";

                CadastroDeCrediarioCliente.DeletarCrediarioCliente(codigoCrediarioCliente); 

                base.FlashMessage("Crediário excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeCrediarioCliente.RecuperarCrediarioClientePorID(Convert.ToInt32(codigoCrediarioCliente));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        public ActionResult DetalhamentoCrediarioCliente(int? codigoCrediarioCliente)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Crediário de cliente";

                CrediarioClienteModel model = CadastroDeCrediarioCliente.RecuperarCrediarioClientePorID(codigoCrediarioCliente.HasValue ? codigoCrediarioCliente.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoCrediarioCliente(FormCollection form)
        {
            CrediarioClienteModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Crediário de cliente";

                modelFuncionario = CadastroDeCrediarioCliente.SalvarCrediarioCliente(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeCrediarioCliente.RecuperarCrediarioClientePorID(Convert.ToInt32(form["codigoCrediarioCliente"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        } 
    }
}