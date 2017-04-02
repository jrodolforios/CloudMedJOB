using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Financeiro;
using MediCloud.Code.Parametro;
using MediCloud.Models.Cliente;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Parametro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ASOController : BaseController
    {
        // GET: ASO
        public ActionResult Index()
        {
            base.EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";

                List<ASOModel> model = CadastroDeASO.buscarCargo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoASO(int? codigoASO)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";

                ASOModel model = CadastroDeASO.RecuperarASOPorID(codigoASO.HasValue ? codigoASO.Value : 0);

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

    }
}