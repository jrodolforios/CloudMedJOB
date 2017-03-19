using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.App_Code
{
    public enum MessageType
    {
        Success, Info, Error, Warning
    }

    public abstract class BaseController : Controller
    {
        public void EstahLogado()
        {
            if (Session[Constantes.NOME_SESSAO_USUARIO] == null)
                Response.Redirect("/Account");
        }

        public SessaoUsuarioModel CurrentUser
        {
            get
            {
                return (SessaoUsuarioModel)Session[Constantes.NOME_SESSAO_USUARIO];
            }
            set
            {
                Session[Constantes.NOME_SESSAO_USUARIO] = value;
            }
        }

        protected void FlashMessage(string message, MessageType type)
        {
            TempData["FlashMessage"] = message;
            switch (type)
            {
                case MessageType.Success:
                    TempData["FlashMessageType"] = "success";
                    break;
                case MessageType.Info:
                    TempData["FlashMessageType"] = "info";
                    break;
                case MessageType.Error:
                    TempData["FlashMessageType"] = "danger";
                    break;
                case MessageType.Warning:
                    TempData["FlashMessageType"] = "warning";
                    break;
            }
        }
    }
}