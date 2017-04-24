using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Laudo;
using MediCloud.Models.Laudo;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class RaioXController : BaseController
    {
        // GET: RaioX
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
                ViewBag.Title = "Raio-X";

                List<LaudoRXModel> model = CadastroDeLaudoRX.buscarClientes(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoRaioX(int? codigoRaioX)
        {
            try
            {
                base.EstahLogado();

                LaudoRXModel laudo = CadastroDeLaudoRX.buscarLaudoRXPorID(codigoRaioX.HasValue ? codigoRaioX.Value : 0);

                return View(laudo);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoRaioX(FormCollection form)
        {
            LaudoRXModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Laudo";

                modelFuncionario = CadastroDeLaudoRX.SalvarLaudoRX(form);

                base.FlashMessage("Laudo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoLaudoRX"]))
                    modelFuncionario = CadastroDeLaudoRX.buscarLaudoRXPorID(Convert.ToInt32(form["codigoLaudoRX"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }


        public ActionResult ExcluirRaioX(int codigoLaudo)
        {
            LaudoRXModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Laudo";

                CadastroDeLaudoRX.DeletarLaudoRX(this, codigoLaudo);

                base.FlashMessage("Laudo excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeLaudoRX.buscarLaudoRXPorID(Convert.ToInt32(codigoLaudo));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        [HttpPost]
        public ActionResult DeletarRaioX(int codigoRaioX)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeLaudoRX.DeletarLaudoRX(this, codigoRaioX);

                resultado.mensagem = "Laudo excluído.";
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
        public JsonResult LiberarRaioX(int codigoRaioX)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeLaudoRX.LiberarLaudoRX(this, codigoRaioX);

                resultado.mensagem = "Laudo liberado";
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