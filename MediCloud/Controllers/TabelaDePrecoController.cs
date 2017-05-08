using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Parametro;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class TabelaDePrecoController : BaseController
    {
        // GET: TabelaDePreco
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela de preços";

                List<TabelaPrecoModel> model = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorTermo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarTabelaDePreco(int codigoDoTabelaDePreco)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeTabelaDePreco.DeletarTabelaDePreco(this, codigoDoTabelaDePreco);

                resultado.mensagem = "Tabela excluída.";
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

        public ActionResult ExcluirTabelaDePreco(int codigoTabelaDePreco)
        {
            TabelaPrecoModel modelTabelaDePreco = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela excluída.";

                CadastroDeTabelaDePreco.DeletarTabelaDePreco(this, codigoTabelaDePreco);

                base.FlashMessage("Setor excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelTabelaDePreco = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(Convert.ToInt32(codigoTabelaDePreco));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelTabelaDePreco);
            }
        }

        public ActionResult DetalhamentoTabelaDePreco(int? codigoTabelaDePreco)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela de Preço";

                TabelaPrecoModel model = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(codigoTabelaDePreco.HasValue ? codigoTabelaDePreco.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoTabelaDePreco(FormCollection form)
        {
            TabelaPrecoModel modelTabelaDePreco = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Tabela de preço";

                modelTabelaDePreco = CadastroDeTabelaDePreco.SalvarTabela(form);

                base.FlashMessage("tabela cadastrada.", MessageType.Success);
                return View(modelTabelaDePreco);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoTabelaDePreco"]))
                    modelTabelaDePreco = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(Convert.ToInt32(form["codigoTabelaDePreco"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelTabelaDePreco);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }
    }
}