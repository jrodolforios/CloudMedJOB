using MediCloud.Code;
using MediCloud.Models.Seguranca;
using System.Web.Mvc;

namespace MediCloud.App_Code
{
    public enum MessageType
    {
        Success, Info, Error, Warning
    }

    public abstract class BaseController : Controller
    {
        #region Public Properties

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

        #endregion Public Properties



        #region Public Methods

        public void EstahLogado()
        {
            if (Session[Constantes.NOME_SESSAO_USUARIO] == null)
                Response.Redirect("/Account");
        }

        #endregion Public Methods



        #region Protected Methods

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

        #endregion Protected Methods
    }
}