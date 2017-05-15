using MediCloud.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class LancamentoDeContratoController : BaseController
    {
        // GET: LancamentoDeContrato
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }


    }
}