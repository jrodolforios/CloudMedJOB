using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Fornecedor;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ContatoController : BaseController
    {
        // GET: Contato
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult DeletarContato(int codigoDoContato)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeContato.DeletarContato(this, codigoDoContato);

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
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

    }
}