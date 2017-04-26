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
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
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
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}