using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Funcionario;
using MediCloud.Models.Funcionario;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class FuncionarioController : BaseController
    {
        // GET: Funcionario
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

                List<FuncionarioModel> model = CadastroDeFuncionarios.buscarUsuarios(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult InativarFuncionario(int codigoDoFuncionario, bool Inativar)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFuncionarios.InativarFuncionario(this, codigoDoFuncionario, Inativar);

                resultado.mensagem = Inativar ? "Funcionário inativo." : "Funcionário ativo.";
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
        public JsonResult DeletarFuncionario(int codigoDoFuncionario)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFuncionarios.DeletarFuncionario(this, codigoDoFuncionario);

                resultado.mensagem = "Usuário excluído.";
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

        public ActionResult ExcluirFuncionario(int codigoFuncionario)
        {
            FuncionarioModel modelFuncionario = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeFuncionarios.DeletarFuncionario(this, codigoFuncionario);

                base.FlashMessage("Funcionário excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                modelFuncionario = CadastroDeFuncionarios.RecuperarFuncionarioPorID(Convert.ToInt32(codigoFuncionario));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelFuncionario);
            }
        }

        public ActionResult DetalhamentoFuncionario(int? codigoFuncionario)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                FuncionarioModel model = CadastroDeFuncionarios.RecuperarFuncionarioPorID(codigoFuncionario.HasValue ? codigoFuncionario.Value : 0);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoFuncionario(FormCollection form)
        {
            FuncionarioModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                modelFuncionario = CadastroDeFuncionarios.SalvarFuncionario(form);

                base.FlashMessage("Funcionário cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoFuncionario"]))
                    modelFuncionario = CadastroDeFuncionarios.RecuperarFuncionarioPorID(Convert.ToInt32(form["codigoFuncionario"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }


    }
}