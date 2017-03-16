using MediCloud.App_Code;
using MediCloud.Models.Seguranca;
using System;
using System.Web.Mvc;

namespace MediCloud.View.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Bem-vindo";

                return View();
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }

        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                ViewBag.Title = "Bem-vindo";

                ControleDeSessao.Logar(form, this);

                this.Response.Redirect("/Home");
            }
            catch (AccessViolationException ex)
            {
                base.FlashMessage(ex.Message, MessageType.Error);
                return View();
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }

            return null;
        }

        public ActionResult Logout()
        {
            try
            {
                ViewBag.Title = "Bem-vindo";

                ControleDeSessao.Deslogar(this);

                this.Response.Redirect("/Account/Index");
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }

            return null;
        }

        [HttpPost]
        public JsonResult TrocarSenha(string SenhaAtual, string NovaSenha, string RepitaNovaSenha)
        {
            ResultadoTrocaSenhaModel resultado = new ResultadoTrocaSenhaModel();
            try
            {
                ViewBag.Title = "Bem-vindo";

                ControleDeSessao.TrocarASenha(this, SenhaAtual, NovaSenha, RepitaNovaSenha);

                resultado.mensagem = "Troca de senha realizada.";
                resultado.trocaBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(ArgumentException ex)
            {
                resultado.mensagem = ex.Message;
                resultado.trocaBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.trocaBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
