using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Recomendacao;
using MediCloud.Models.Recomendacao;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class SetorController : BaseController
    {
        // GET: Setor
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
                ViewBag.Title = "Setores";

                List<SetorModel> model = CadastroDeSetor.buscarSetor(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult BuscaSetorAJAX(string Prefix)
        {

            List<SetorModel> contadoresEncontrados = CadastroDeSetor.RecuperarSetorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdSetor, Name = x.NomeSetor });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DetalhamentoSetor(int? codigoSetor)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                SetorModel model = CadastroDeSetor.RecuperarSetorPorID(codigoSetor.HasValue ? codigoSetor.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoSetor(FormCollection form)
        {
            SetorModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                modelFuncionario = CadastroDeSetor.SalvarSetor(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeSetor.RecuperarSetorPorID(Convert.ToInt32(form["codigoSetor"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarSetor(int codigoDoSetor)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeSetor.DeletarSetor(this, codigoDoSetor);

                resultado.mensagem = "Setor excluído.";
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

        public ActionResult ExcluirCargo(int codigoCargo)
        {
            SetorModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                CadastroDeSetor.DeletarSetor(this, codigoCargo);

                base.FlashMessage("Setor excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeSetor.buscarSetorPorID(Convert.ToInt32(codigoCargo));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

    }
}