using MediCloud.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ControleDeSessao.EstahLogado(this);
            ViewBag.Title = "Início";

            return View();
        }
    }
}
