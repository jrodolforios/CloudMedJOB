using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
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
    public class LaudoAudioController : BaseController
    {
        // GET: LaudoAudio
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        public ActionResult DetalhamentoLaudoAudio(int? codigoLaudoAudio)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Audiometria";

                LaudoAudioModel model = CadastroDeLaudoAudio.RecuperarLaudoAudioPorID(codigoLaudoAudio.HasValue ? codigoLaudoAudio.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult ExcluirLaudoAudio(int codigoLaudoAudio)
        {
            LaudoAudioModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeLaudoAudio.DeletarLaudoAudio(this, codigoLaudoAudio);

                base.FlashMessage("Audiometria excluída.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCargo = CadastroDeLaudoAudio.RecuperarLaudoAudioPorID(Convert.ToInt32(codigoLaudoAudio));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Audiometria";

                List<LaudoAudioModel> model = CadastroDeLaudoAudio.buscarLaudoAudio(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarLaudoAudio(int codigoLaudoAudio)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeLaudoAudio.DeletarLaudoAudio(this, codigoLaudoAudio);

                resultado.mensagem = "Audiometria excluída.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public FileResult ImprimirAudiometria(int codigoAudiometria)
        {
            LaudoAudioModel laudoAudio = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                laudoAudio = CadastroDeLaudoAudio.RecuperarLaudoAudioPorID(codigoAudiometria);

                arquivo = CadastroDeLaudoAudio.ImprimirAudiometria(codigoAudiometria);

                byte[] fileBytes = arquivo;
                string fileName = laudoAudio.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoLaudoAudio(FormCollection form)
        {
            LaudoAudioModel modelLaudoAudio = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Audiometria";

                modelLaudoAudio = CadastroDeLaudoAudio.SalvarAudiometria(form);

                base.FlashMessage("Audiometria cadastrada.", MessageType.Success);
                return View(modelLaudoAudio);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoLaudoAudio"]))
                    modelLaudoAudio = CadastroDeLaudoAudio.RecuperarLaudoAudioPorID(Convert.ToInt32(form["codigoLaudoAudio"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelLaudoAudio);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }
    }
}