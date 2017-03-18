using MediCloud.App_Code;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
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
                base.EstahLogado();
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

        public ActionResult Usuarios()
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Usuários";

                return View();
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Usuarios(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Usuários";

                List<UsuarioModel> model = CadastroDeUsuarios.buscarUsuarios(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult TrocarSenha(string SenhaAtual, string NovaSenha, string RepitaNovaSenha)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                ControleDeSessao.TrocarASenha(this, SenhaAtual, NovaSenha, RepitaNovaSenha);

                resultado.mensagem = "Troca de senha realizada.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(ArgumentException ex)
            {
                resultado.mensagem = ex.Message;
                resultado.acaoBemSucedida = false;

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
        public JsonResult DeletarUsuario(int codigoDoUsuario)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeUsuarios.DeletarUsuario(this, codigoDoUsuario);

                resultado.mensagem = "Usuário excluído.";
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
        public JsonResult BloquearUsuario(int codigoDoUsuario, bool Bloquear)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeUsuarios.BloquearUsuario(this, codigoDoUsuario, Bloquear);

                resultado.mensagem = Bloquear ? "Usuário bloqueado." : "Usuário Desbloqueado";
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
    }
}
