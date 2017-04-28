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
    public class LaudoVisaoController : BaseController
    {
        // GET: LaudoVisao
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        public ActionResult DetalhamentoLaudoVisao(int? codigoLaudoVisao)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cargo";

                LaudoVisaoModel model = CadastroDeLaudoVisao.recuperarLaudoVisaoPorID(codigoLaudoVisao.HasValue ? codigoLaudoVisao.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult ExcluirLaudoVisao(int codigoLaudoVisao)
        {
            LaudoVisaoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeLaudoVisao.DeletarLaudoVisao(this, codigoLaudoVisao);

                base.FlashMessage("Laudo excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeLaudoVisao.recuperarLaudoVisaoPorID(Convert.ToInt32(codigoLaudoVisao));

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
                ViewBag.Title = "Acuidade Visual";

                List<LaudoVisaoModel> model = CadastroDeLaudoVisao.buscarLaudoVisao(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarLaudoVisao(int codigoLaudoVisao)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeLaudoVisao.DeletarLaudoVisao(this, codigoLaudoVisao);

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
        public ActionResult DetalhamentoLaudoVisao(FormCollection form)
        {
            LaudoVisaoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Acuidade visual";

                modelFuncionario = CadastroDeLaudoVisao.SalvarLaudoVisao(form);

                base.FlashMessage("Laudo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoLaudoVisao"]))
                    modelFuncionario = CadastroDeLaudoVisao.recuperarLaudoVisaoPorID(Convert.ToInt32(form["codigoLaudoVisao"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public FileResult ImprimirLaudo(int codigoLaudo)
        {
            LaudoVisaoModel laudoVisaoModel = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                laudoVisaoModel = CadastroDeLaudoVisao.recuperarLaudoVisaoPorID(codigoLaudo);

                arquivo = CadastroDeLaudoVisao.ImprimirLaudo(codigoLaudo);

                byte[] fileBytes = arquivo;
                string fileName = laudoVisaoModel.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/RaioX/DetalhamentoLaudoVisao?codigoLaudoVisao=" + codigoLaudo.ToString());
                return null;
            }
        }
    }
}