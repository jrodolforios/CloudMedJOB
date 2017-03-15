using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.App_Code
{
    public class ControleDeSessao
    {
        public static void EstahLogado(Controller controlador)
        {
            if (controlador.Session["UserSession"] == null)
                controlador.Response.Redirect("Account");
        }
    }
}