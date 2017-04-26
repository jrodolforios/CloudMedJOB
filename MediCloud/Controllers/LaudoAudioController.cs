using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Laudo;
using MediCloud.Models.Laudo;
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
    }
}