using MediCloud.App_Code;
using System;
using System.Web.Mvc;

namespace MediCloud.View.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Bem-vindo";

            return View();
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
                return View();
            }

            return null;
        }
    }
}
