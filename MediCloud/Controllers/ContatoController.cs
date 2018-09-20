using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Fornecedor;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Seguranca;
using System;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ContatoController : BaseController
    {
        #region Public Methods

        [HttpPost]
        public JsonResult DeletarContato(int codigoDoContato)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeContato.DeletarContato(this, codigoDoContato);

                resultado.mensagem = "Contato excluído.";
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
        public JsonResult DeletarContatoFornecedor(int codigoDoContatoFornecedor)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeContato.DeletarContatoFornecedor(this, codigoDoContatoFornecedor);

                resultado.mensagem = "Contato excluído.";
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
        public JsonResult DetalharContato(int codigoDoContato)
        {
            try
            {
                ContatoModel contadoresEncontrados = CadastroDeContato.RecuperarContatoPorID(codigoDoContato);

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
        public JsonResult DetalharContatoFornecedor(int codigoDoContatoFornecedor)
        {
            try
            {
                ContatoFornecedorModel contadoresEncontrados = CadastroDeContato.RecuperarContatoFornecedorPorID(codigoDoContatoFornecedor);

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

        // GET: Contato
        public ActionResult Index()
        {
            return View();
        }

        #endregion Public Methods
    }
}