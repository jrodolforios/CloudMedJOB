using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
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
            EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Usuários";

                List<FuncionarioModel> model = CadastroDeFuncionario.BuscarFuncionarios(form);

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
        public JsonResult InativarFuncionario(int codigoDoFuncionario, bool Inativar)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFuncionario.InativarFuncionario(this, codigoDoFuncionario, Inativar);

                resultado.mensagem = Inativar ? "Funcionário inativo." : "Funcionário ativo.";
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

        [HttpPost]
        public JsonResult DeletarFuncionario(int codigoDoFuncionario)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFuncionario.DeletarFuncionario(this, codigoDoFuncionario);

                resultado.mensagem = "Usuário excluído.";
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

        public ActionResult ExcluirFuncionario(int codigoFuncionario)
        {
            FuncionarioModel modelFuncionario = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                CadastroDeFuncionario.DeletarFuncionario(this, codigoFuncionario);

                base.FlashMessage("Funcionário excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelFuncionario = CadastroDeFuncionario.RecuperarFuncionarioPorID(Convert.ToInt32(codigoFuncionario));

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

                FuncionarioModel model = CadastroDeFuncionario.RecuperarFuncionarioPorID(codigoFuncionario.HasValue ? codigoFuncionario.Value : 0);

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
        public ActionResult DetalhamentoFuncionario(FormCollection form)
        {
            FuncionarioModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Funcionário";

                modelFuncionario = CadastroDeFuncionario.SalvarFuncionario(form);

                base.FlashMessage("Funcionário cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoFuncionario"]))
                    modelFuncionario = CadastroDeFuncionario.RecuperarFuncionarioPorID(Convert.ToInt32(form["codigoFuncionario"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelFuncionario);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult BuscaFuncionarioDeClienteAJAX(int? IdCliente, string Prefix)
        {
            if (!IdCliente.HasValue)
                return null;

            List<FuncionarioModel> contadoresEncontrados = CadastroDeFuncionario.RecuperarContadorPorTermoECliente(Prefix, IdCliente.Value);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdFuncionario, Name = x.NomeCompleto });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult BuscaFuncionarioAJAX(string Prefix)
        {
            List<FuncionarioModel> contadoresEncontrados = CadastroDeFuncionario.RecuperarFuncionarioPorTermoAJAX(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdFuncionario, Name = x.NomeCompleto });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

    }
}