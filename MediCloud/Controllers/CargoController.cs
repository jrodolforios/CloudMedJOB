using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Models.Cliente;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class CargoController : BaseController
    {
        // GET: Cargo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Usuários";

                List<CargoModel> model = CadastroDeCargo.buscarCargo(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarCargo(int codigoDoCargo)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeCargo.DeletarCargo(this, codigoDoCargo);

                resultado.mensagem = "Cargo excluído.";
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

        public ActionResult DetalhamentoCargo(int? codigoCargo)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cargo";

                CargoModel model = CadastroDeCargo.RecuperarCargoPorID(codigoCargo.HasValue ? codigoCargo.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoCargo(FormCollection form)
        {
            CargoModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Cargo";

                modelFuncionario = CadastroDeCargo.SalvarCargo(form);

                base.FlashMessage("Cargo cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCargo"]))
                    modelFuncionario = CadastroDeCargo.RecuperarCargoPorID(Convert.ToInt32(form["codigoCargo"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult ExcluirCargo(int codigoCargo)
        {
            CargoModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeCargo.DeletarCargo(this, codigoCargo);

                base.FlashMessage("Cargo excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeCargo.RecuperarCargoPorID(Convert.ToInt32(codigoCargo));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }

        [HttpPost]
        public JsonResult BuscaCargoAJAX(string Prefix)
        {
            List<CargoModel> contadoresEncontrados = CadastroDeCargo.RecuperarCargoPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdCargo, Name = x.NomeCargo });
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

    }
}