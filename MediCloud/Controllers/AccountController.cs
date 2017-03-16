using MediCloud.App_Code;
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

            return null;
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
    }
}
