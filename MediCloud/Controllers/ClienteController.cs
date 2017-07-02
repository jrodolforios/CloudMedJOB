using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Fornecedor;
using MediCloud.Models.Cliente;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ClienteController : BaseController
    {
        // GET: Cliente
        public ActionResult Index()
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                return View();
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
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
                ViewBag.Title = "Clientes";

                List<ClienteModel> model = CadastroDeClientes.buscarClientes(form);

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
        public ActionResult SalvarContato(FormCollection form)
        {
            int codigoCliente = Convert.ToInt32(form["codigoClienteContato"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                ContatoModel model = CadastroDeContato.salvarContato(form);

                base.FlashMessage("Contato cadastrado.", MessageType.Success);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }

            return null;
        }

        [HttpPost]
        public ActionResult SalvarEmpresa(FormCollection form)
        {
            int codigoCliente = Convert.ToInt32(form["codigoClienteEmpresa"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                EmpresaModel model = CadastroDeClientes.SalvarEmpresa(form);

                base.FlashMessage("Empresa cadastrada.", MessageType.Success);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }

            return null;
        }

        [HttpPost]
        public JsonResult DeletarCliente(int codigoDoCliente)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeClientes.DeletarCliente(this, codigoDoCliente);

                resultado.mensagem = "Cliente excluído.";
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
        public JsonResult DeletarEmpresa(int codigoDaEmpresa)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeClientes.DeletarEmpresa(this, codigoDaEmpresa);

                resultado.mensagem = "Empresa excluída.";
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

        public ActionResult DetalhamentoCliente(int? codigoCliente)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                ClienteModel model = CadastroDeClientes.RecuperarClientePorID(codigoCliente);

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
        public ActionResult DetalhamentoCliente(FormCollection form)
        {
            ClienteModel modelUsuario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                modelUsuario = CadastroDeClientes.SalvarCliente(form);

                base.FlashMessage("Usuário cadastrado.", MessageType.Success);
                return View(modelUsuario);
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                if (!string.IsNullOrEmpty(form["codigoCliente"]))
                    modelUsuario = CadastroDeClientes.RecuperarClientePorID(Convert.ToInt32(form["codigoCliente"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelUsuario);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult ExcluirCliente(int codigoCliente)
        {
            ClienteModel modelCliente = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                CadastroDeClientes.DeletarCliente(this, codigoCliente);

                base.FlashMessage("Usuário excluído.", MessageType.Success);

                return View("index");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                modelCliente = CadastroDeClientes.RecuperarClientePorID(Convert.ToInt32(codigoCliente));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCliente);
            }
        }

        [HttpPost]
        public JsonResult BuscaClienteAJAX(string Prefix)
        {
            List<ClienteModel> contadoresEncontrados = CadastroDeClientes.RecuperarContadorPorTermo(Prefix);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdCliente, Name = x.NomeFantasia });
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
        public JsonResult DetalharEmpresa(int codigoDaEmpresa)
        {
            try
            {
                EmpresaModel empresaEncontrada = CadastroDeClientes.RecuperarEmpresaPorID(codigoDaEmpresa);


                return Json(empresaEncontrada, JsonRequestBehavior.AllowGet);
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
        public JsonResult AdicionarTabela(int codigoCliente, int codigoTabela)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeClientes.AdicionarTabela(codigoCliente, codigoTabela);

                resultado.mensagem = "Tabela adicionada.";
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
        public JsonResult DeletarTabela(int codigoCliente, int codigoTabela)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeClientes.DeletarTabelaDeCliente(codigoCliente, codigoTabela);

                resultado.mensagem = "Tabela excluída.";
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