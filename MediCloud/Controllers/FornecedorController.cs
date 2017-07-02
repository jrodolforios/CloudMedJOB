using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Fornecedor;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class FornecedorController : BaseController
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            this.EstahLogado();
            return View();
        }

        [HttpPost]
        public JsonResult BuscaFornecedorAJAX(string Prefix)
        {
            List<FornecedorModel> contadoresEncontrados = CadastroDeFornecedor.RecuperarContadorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdFornecedor, Name = x.NomeFantasia });
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
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setores";

                List<FornecedorModel> model = CadastroDeFornecedor.BuscarFornecedor(form);

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
        public JsonResult DeletarFornecedor(int codigoFornecedor)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFornecedor.DeletarFornecedor(this, codigoFornecedor);

                resultado.mensagem = "Fornecedor excluído.";
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

        public ActionResult ExcluirFornecedor(int codigoFornecedor)
        {
            FornecedorModel modelFornecedor = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Fornecedor";

                CadastroDeFornecedor.DeletarFornecedor(this, codigoFornecedor);

                base.FlashMessage("Fornecedor excluído.", MessageType.Success);

                return View("Index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelFornecedor = CadastroDeFornecedor.RecuperarFornecedorPorID(Convert.ToInt32(codigoFornecedor));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelFornecedor);
            }
        }

        public ActionResult DetalhamentoFornecedor(int? codigoFornecedor)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Setor";

                FornecedorModel model = CadastroDeFornecedor.RecuperarFornecedorPorID(codigoFornecedor.HasValue ? codigoFornecedor.Value : 0);

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
        public ActionResult DetalhamentoFornecedor(FormCollection form)
        {
            FornecedorModel modelFuncionario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Fornecedor";

                modelFuncionario = CadastroDeFornecedor.SalvarFornecedor(form);

                base.FlashMessage("Fornecedor cadastrado.", MessageType.Success);
                return View(modelFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoFornecedor"]))
                    modelFuncionario = CadastroDeFornecedor.RecuperarFornecedorPorID(Convert.ToInt32(form["codigoFornecedor"]));

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
        public ActionResult SalvarContato(FormCollection form)
        {
            int codigoFornecedor = Convert.ToInt32(form["codigoFornecedorContato"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Fornecedor";

                ContatoFornecedorModel model = CadastroDeContato.salvarContatoFornecedor(form);

                base.FlashMessage("Contato cadastrado.", MessageType.Success);
                Response.Redirect($"/Fornecedor/DetalhamentoFornecedor?codigoFornecedor={codigoFornecedor}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/Fornecedor/DetalhamentoFornecedor?codigoFornecedor={codigoFornecedor}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/Fornecedor/DetalhamentoFornecedor?codigoFornecedor={codigoFornecedor}");
            }

            return null;
        }

        [HttpPost]
        public ActionResult SalvarProcedimento(FormCollection form)
        {
            int codigoFornecedor = Convert.ToInt32(form["codigoFornecedorProcedimento"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Fornecedor";

                FornecedorProcedimento model = CadastroDeFornecedor.salvarProcedimentoFornecedor(form);

                base.FlashMessage("Procedimento cadastrado.", MessageType.Success);
                Response.Redirect($"/Fornecedor/DetalhamentoFornecedor?codigoFornecedor={codigoFornecedor}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/Fornecedor/DetalhamentoFornecedor?codigoFornecedor={codigoFornecedor}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/Fornecedor/DetalhamentoFornecedor?codigoFornecedor={codigoFornecedor}");
            }

            return null;
        }

        [HttpPost]
        public JsonResult DetalharProcedimentoFornecedor(int codigoDoProcedimentoFornecedor, int codigoFornecedor)
        {
            try
            {
                FornecedorProcedimento contadoresEncontrados = CadastroDeFornecedor.recuperarFornecedorProcedimentoPorID(codigoDoProcedimentoFornecedor, codigoFornecedor);


                return Json(contadoresEncontrados, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeletarProcedimentoFornecedor(int codigoDoProcedimentoFornecedor, int codigoFornecedor)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeFornecedor.DeletarProcedimentoFornecedor(codigoDoProcedimentoFornecedor, codigoFornecedor);

                resultado.mensagem = "Procedimento excluído.";
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
    }
}